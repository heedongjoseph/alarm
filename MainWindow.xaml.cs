using System;
using System.Windows;
using System.Windows.Threading;
using System.ComponentModel;
using System.Windows.Input;

namespace alarm
{
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        public class Alarm
        {
            public string AlarmTitle { get; set; }
            public string Time { get; set; }
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // アラーム一覧の時刻を1つずつ確認していく
            foreach (Alarm item in AlarmList.Items)
            {
                // 時刻を文字列で取得
                string timeStr = item.Time.ToString() ?? "";

                // 現在時刻と比較
                if (DateTime.Now.ToString("HH:mm") == timeStr)
                {
                    SubWindow sub = new SubWindow(item.AlarmTitle.ToString(), timeStr);
                    sub.Topmost = true;
                    sub.Show();
                    sub.Activate();

                    break;
                }
            }

            if (AlarmList.Items.IsEmpty)
            {
                // アラーム一覧が空ならタイマー停止
                _timer.Stop();
            }
        }
        private void resetTimer() {
            // イベント発生間隔の設定
            _timer.Interval = TimeSpan.FromMilliseconds(10000);
            // イベント登録
            _timer.Tick += new EventHandler(dispatcherTimer_Tick);
        }
        public MainWindow()
        {
            InitializeComponent();
            resetTimer();
        }
        private void RegisterProcess()
        {
            var hours = Hours.Text;
            if (Hours.Text.Length == 1) {
                hours = "0" + hours;
            }

            var alarmTime = "";
            try {
                alarmTime = DateTime.Parse(hours + ":" + Minutes.Text).ToString("HH:mm");
            } catch {
                return;
            }

            AlarmList.Items.Add(new Alarm { AlarmTitle = AlarmTitle.Text, Time = alarmTime });

            AlarmList.Items.SortDescriptions.Add(
                new SortDescription("Time", ListSortDirection.Ascending)
            );

            if (!_timer.IsEnabled)
            {
                _timer.Start();
            }

            AlarmTitle.Text = "";
            Hours.Text = "";
            Minutes.Text = "";

            AlarmTitle.Focus();
        }
        private void Register(object sender, RoutedEventArgs e)
        {
            RegisterProcess();
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            /// 項目を削除します
            // 選択項目がない場合は処理をしない
            if (AlarmList.SelectedItems.Count == 0)
                return;

            // 選択された項目を削除
            AlarmList.Items.RemoveAt(AlarmList.SelectedIndex);
        }
        private void EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key  == Key.Return)
            {
                RegisterProcess();
            }
        }
        protected virtual void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBoxResult.Yes != MessageBox.Show("画面を閉じます。よろしいですか？", "確認", MessageBoxButton.YesNo, MessageBoxImage.Information))
            {
                e.Cancel = true;
                return;
            }
        }
    }
}
