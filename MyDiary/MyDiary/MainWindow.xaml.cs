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

namespace MyDiary
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public string original_text = "Record This Moment NOW...";
        public string record_text = "";
        public string filepath = "D:/diary.txt";
        int emotion = 0;  //0-happy 1-sad 2-angry
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
                MessageBox.Show("At least write something...OK?", "Oops...", MessageBoxButton.OK, MessageBoxImage.Information);
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
                record += "\n";

                byte[] data = new UTF8Encoding().GetBytes(record);
                //开始写入
                fs.Write(data, 0, data.Length);
                //清空缓冲区、关闭流
                fs.Flush();
                fs.Close();

                MessageBox.Show("You Have Recorded This Moment. :)");
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
            base.DragMove();
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
            string help_msg = "";
            help_msg += "MyDiary By BlackHand\n";
            help_msg += "o : Open Diary By Notepad++\n";
            help_msg += "c : Change Background Color\n";
            help_msg += "×: Exit";
            MessageBox.Show(help_msg, "Help", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        private void Label_open_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Label_open.FontSize = 16;
        }

        private void Label_open_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
            Info.FileName = "Notepad++.exe";
            Info.Arguments = filepath;
            System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
        }
    }
}
