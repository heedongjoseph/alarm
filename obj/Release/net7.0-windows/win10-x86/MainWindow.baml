   M S B A M L   `   `   `  ���� @  <alarm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:alarmalarm      alarm.MainWindow   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     %localclr-namespace:alarm     -     � Title$  アラームアプリ��$	��400��$	��250�� � WindowStartupLocation$ CenterScreen=� � Icon$ /Assets/icon.ico��.��� 
�������.+��� .+�� $��
5, 5, 5, 0q�.+��� $��タイトル :��$��
5, 5, 5, 0q��� -   $��
AlarmTitle��
����  �$�� ��$	��160��$��
5, 5, 5, 0q�� $��
5, 5, 5, 0q�.+��� -   $��Hours��
����  �$�� ��$��30��$��
5, 5, 5, 0q��� $��:��$��
0, 5, 0, 0q��� -   $��Minutes��
����  �$�� ��$��30��$��
5, 5, 5, 0q��� -   $	��130��$��
5, 5, 5, 0q�
�����F�
�������$��登録��� .+��� -   $��	AlarmList��$��10q� �� View �� .P���  �� Width$	 130��$��タイトル�� �� DisplayMemberBinding �� *
AlarmTitle+�� $ 70��$��時間�� �� *Time+�� -   $��
5, 5, 5, 0q�
�������
�������$��削除���� $H��B※ PCの時刻がずれている場合は調整してください��$��12(�