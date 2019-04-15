using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
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
using Microsoft.Win32;

namespace MyDiary
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public string original_text = "记录这一刻吧...";
        public string record_text = "";
        public string filepath = "D:/MyDiary/diary.txt"; 
        public string pword = "123456";
        int emotion = 0;  //0-happy 1-sad 2-angry
        int win_now = 0;
        int R, G, B;

        public void UpdateEmotion()
        {
            switch (emotion)
            {
                case 0:
                    Label_emotion.Content = "Happy";
                    break;
                case 1:
                    Label_emotion.Content = "Sad";
                    break;
                case 2:
                    Label_emotion.Content = "Angry";
                    break;
                default:
                    Label_emotion.Content = "Happy";
                    break;
            }
        }

        public void Finish()
        {
            if (this.diaryBox.Text == original_text || this.diaryBox.Text == "")
            {
                MessageBox.Show("好歹记录点儿什么嘛...", "Oops...", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                FileStream fs = new FileStream(filepath, FileMode.Append);
                string record = "";
                string color = "#" + R.ToString("X2") + G.ToString("X2") + B.ToString("X2");
                record += DateTime.Now.ToString("yyyy-MM-dd");
                record += "\t";
                record += DateTime.Now.Hour.ToString("D2");
                record += ":";
                record += DateTime.Now.Minute.ToString("D2");
                record += "\t";
                record += DateTime.Now.DayOfWeek.ToString();
                record += "\t";
                if (DateTime.Now.DayOfWeek.ToString() == "Monday"
                    || DateTime.Now.DayOfWeek.ToString() == "Tuesday"
                    || DateTime.Now.DayOfWeek.ToString() == "Friday"
                    || DateTime.Now.DayOfWeek.ToString() == "Sunday")
                    record += "\t";
                record += this.Label_emotion.Content.ToString();
                record += "\t";
                if (this.Label_emotion.Content.ToString() == "Sad")
                    record += "\t";
                record += color;
                record += "\t\t";
                record += this.diaryBox.Text;
                record += "\r\n";

                byte[] data = new UTF8Encoding().GetBytes(record);
                //开始写入
                fs.Write(data, 0, data.Length);
                //清空缓冲区、关闭流
                fs.Flush();
                fs.Close();

                MessageBox.Show("你已经记录下这一刻。 :)");
                this.diaryBox.Text = original_text;
                this.Label_emotion.Focus();
            }
        }

        public void Colorit()
        {
            Random rd = new Random();
            R = rd.Next(0, 255);
            G = rd.Next(0, 255);
            B = rd.Next(0, 255);
            byte[] color_R = BitConverter.GetBytes(R);
            byte[] color_G = BitConverter.GetBytes(G);
            byte[] color_B = BitConverter.GetBytes(B);
            Color color = Color.FromRgb(color_R[0], color_G[0], color_B[0]);
            SolidColorBrush myBrush = new SolidColorBrush(color);
            this.MyDiary.Background = myBrush;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MyDiary_Loaded(object sender, RoutedEventArgs e)
        {
            Colorit();
            string date_string = DateTime.Now.ToString("yyyy-MM-dd");
            string weekday_string = DateTime.Now.DayOfWeek.ToString();
            this.Label_time.Content = date_string + " " + weekday_string;
            this.diaryBox.Text = original_text;

            WinChange(0);
            
            string help_msg = "";
            help_msg += "MyDiary By BlackHand\n";
            help_msg += "o : 打开日记\n";
            help_msg += "c : 更换颜色\n";
            help_msg += "×: 退出";
            Label_helptext.Content = help_msg;

            try
            {
                ManageReg();
            }
            catch
            {
                MessageBox.Show("请使用管理员权限打开本应用。");
                Application.Current.Shutdown();
            }

            string path = System.IO.Path.GetDirectoryName(filepath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                FileStream fs = new FileStream(filepath, FileMode.Append);
                fs.Close();            
            }

        }

        private void DiaryBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if(this.diaryBox.Text == original_text)
            {
                this.diaryBox.Text = "";
            }
        }

        private void DiaryBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if(this.diaryBox.Text == "")
            {
                this.diaryBox.Text = original_text;
                record_text = "";
            }
            else
            {
                record_text = this.diaryBox.Text;
            }
        }

        private void Image_happy_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            emotion = 0;
            UpdateEmotion();
        }

        private void Image_sad_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            emotion = 1;
            UpdateEmotion();
        }

        private void Image_angry_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            emotion = 2;
            UpdateEmotion();
        }

        private void DiaryBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter) 
                Finish();
            //这一部分有问题 不能生效
            if(e.Key == Key.Up)
            {
                switch(emotion)
                {
                    case 0:
                        emotion = 1;
                        break;
                    case 1:
                        emotion = 2;
                        break;
                    case 2:
                        emotion = 0;
                        break;
                }
                UpdateEmotion();
            }
            if (e.Key == Key.Down)
            {
                switch (emotion)
                {
                    case 0:
                        emotion = 2;
                        break;
                    case 1:
                        emotion = 0;
                        break;
                    case 2:
                        emotion = 1;
                        break;
                }
                UpdateEmotion();
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Label_close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Label_close_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Label_close.FontSize = 36;
        }

        private void Label_close_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Label_close.FontSize = 22;
        }

        private void Label_open_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Label_open.FontSize = 22;
        }

        private void Label_change_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Label_change.FontSize = 24;
        }

        private void Label_change_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Label_change.FontSize = 18;
        }

        private void Label_change_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Colorit();
        }

        private void Label_help_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Label_help.FontSize = 22;
        }

        private void Label_help_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Label_help.FontSize = 16;
        }

        private void Label_help_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switch (win_now)
            {
                case 0:
                    WinChange(2);
                    break;
                case 1:
                    WinChange(2);
                    break;
                case 2:
                    WinChange(0);
                    break;
                case 3:
                    WinChange(2);
                    break;
                default:
                    WinChange(0);
                    break;
            }
        }

        private void PwBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if(PwBox.Password == pword)
                {
                    WinChange(0);
                    System.Diagnostics.Process.Start(filepath);
                }
                else
                {
                    PwBox.Password = "";
                    MessageBox.Show("密码错误！", "Wrong!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Label_open_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Label_open.FontSize = 16;
        }

        private void Label_open_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switch(win_now)
            {
                case 0:
                    WinChange(1);
                    break;
                case 1:
                    WinChange(0);
                    break;
                case 2:
                    WinChange(1);
                    break;
                case 3:
                    WinChange(1);
                    break;
                default:
                    WinChange(0);
                    break;
            }
        }

        /// <summary>
        /// 选择当前有效窗口
        /// </summary>
        /// <param name="win_id">0-ui 1-pw 2-help</param>
        public void WinChange(int win_id)
        {
            PwBox.Password = "";
            OldPwBox.Password = "";
            NewPwBox.Password = "";
            if (win_id == 0)
            {
                win_now = 0;
                Grid_ui.IsEnabled = true;
                Grid_ui.Visibility = Visibility.Visible;
                Grid_pw.IsEnabled = false;
                Grid_pw.Visibility = Visibility.Hidden;
                Grid_help.IsEnabled = false;
                Grid_help.Visibility = Visibility.Hidden;
                Grid_changepw.IsEnabled = false;
                Grid_changepw.Visibility = Visibility.Hidden;
            }
            else if(win_id == 1)
            {
                this.PwBox.Focus();
                win_now = 1;
                Grid_ui.IsEnabled = false;
                Grid_ui.Visibility = Visibility.Hidden;
                Grid_pw.IsEnabled = true;
                Grid_pw.Visibility = Visibility.Visible;
                Grid_help.IsEnabled = false;
                Grid_help.Visibility = Visibility.Hidden;
                Grid_changepw.IsEnabled = false;
                Grid_changepw.Visibility = Visibility.Hidden;
            }
            else if(win_id == 2)
            {
                win_now = 2;
                Grid_ui.IsEnabled = false;
                Grid_ui.Visibility = Visibility.Hidden;
                Grid_pw.IsEnabled = false;
                Grid_pw.Visibility = Visibility.Hidden;
                Grid_help.IsEnabled = true;
                Grid_help.Visibility = Visibility.Visible;
                Grid_changepw.IsEnabled = false;
                Grid_changepw.Visibility = Visibility.Hidden;
            }
            else if(win_id == 3)
            {
                win_now = 3;
                Grid_ui.IsEnabled = false;
                Grid_ui.Visibility = Visibility.Hidden;
                Grid_pw.IsEnabled = false;
                Grid_pw.Visibility = Visibility.Hidden;
                Grid_help.IsEnabled = false;
                Grid_help.Visibility = Visibility.Hidden;
                Grid_changepw.IsEnabled = true;
                Grid_changepw.Visibility = Visibility.Visible;
            }
        }

        private void Label_changepw_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switch (win_now)
            {
                case 0:
                    WinChange(3);
                    break;
                case 1:
                    WinChange(3);
                    break;
                case 2:
                    WinChange(3);
                    break;
                case 3:
                    WinChange(0);
                    break;
                default:
                    WinChange(0);
                    break;
            }
        }

        private void Label_changepwenter_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ChangePW();
        }

        public void ManageReg()
        {
            RegistryKey key = Registry.LocalMachine;
            RegistryKey key_md;
            if (!IsExistReg("SOFTWARE", "MyDiary"))
                key_md = key.CreateSubKey("SOFTWARE\\MyDiary");
            else
                key_md = key.OpenSubKey("SOFTWARE\\MyDiary", true);
            if(IsExistRegValue("SOFTWARE\\MyDiary", "FILEPATH"))
            {
                filepath = key_md.GetValue("FILEPATH").ToString();
            }
            else
            {
                key_md.SetValue("FILEPATH", filepath, RegistryValueKind.String);
            }
            if (IsExistRegValue("SOFTWARE\\MyDiary", "PASSWORD"))
            {
                pword = key_md.GetValue("PASSWORD").ToString();
            }
            else
            {
                key_md.SetValue("PASSWORD", pword, RegistryValueKind.String);
            }
            key_md.Close();
        }

        public bool IsExistReg(string path, string keyword)
        {
            string[] subkeyNames;
            RegistryKey hkml = Registry.LocalMachine;
            RegistryKey software = hkml.OpenSubKey(path);
            subkeyNames = software.GetSubKeyNames();
            //取得该项下所有子项的名称的序列，并传递给预定的数组中  
            foreach (string keyName in subkeyNames)
            //遍历整个数组  
            {
                if (keyName == keyword)
                //判断子项的名称  
                {
                    hkml.Close();
                    return true;
                }
            }
            hkml.Close();
            return false;
        }

        private void NewPwBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ChangePW();
            }
        }

        public bool IsExistRegValue(string path, string keyvalue)
        {
            string[] subkeyNames;
            RegistryKey hkml = Registry.LocalMachine;
            RegistryKey software = hkml.OpenSubKey(path);
            //RegistryKey software = hkml.OpenSubKey("SOFTWARE\\test", true);
            subkeyNames = software.GetValueNames();
            //取得该项下所有键值的名称的序列，并传递给预定的数组中
            foreach (string keyName in subkeyNames)
            {
                if (keyName == keyvalue) //判断键值的名称
                {
                    hkml.Close();
                    return true;
                }

            }
            hkml.Close();
            return false;
        }

        public void ChangePW()
        {
            if (OldPwBox.Password == "" || NewPwBox.Password == "")
            {
                MessageBox.Show("密码不能为空！");
                return;
            }
            else if (OldPwBox.Password != pword)
            {
                MessageBox.Show("原密码错误！");
                return;
            }
            else
            {
                pword = NewPwBox.Password;
                RegistryKey key = Registry.LocalMachine;
                RegistryKey key_md = key.OpenSubKey("SOFTWARE\\MyDiary", true);
                key_md.SetValue("PASSWORD", pword);
                MessageBox.Show("修改成功");
                WinChange(2);
                key_md.Close();
            }
        }
    }
}
