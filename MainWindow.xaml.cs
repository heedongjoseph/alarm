using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace alarm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        public class Alarm
        {
            public string Name { get; set; }
            public string Time { get; set; }
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // アラーム一覧の時刻を1つずつ確認していく
            foreach (Alarm item in AlarmList.Items)
            {
                // 時刻を文字列で取得
                string timeStr = item.Time.ToString() ?? "";
                // MessageBox.Show(DateTime.Now.ToString("HH:mm") + "," + timeStr);
                // 現在時刻と比較
                if (DateTime.Now.ToString("HH:mm") == timeStr)
                {
                    // アラーム一覧から該当時刻を削除
                    // AlarmList.Items.Remove(item);

                    SubWindow sub = new SubWindow(item.Name.ToString(), timeStr);
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
        private void Register(object sender, RoutedEventArgs e)
        {
            var hours = Hours.Text;
            if (Hours.Text.Length == 1) {
                hours = "0" + hours;
            }
            AlarmList.Items.Add(new Alarm { Name = Name.Text, Time = "" + hours + ":" + Minutes.Text });
            if (!_timer.IsEnabled)
            {
                _timer.Start();
            }
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
    }
}
