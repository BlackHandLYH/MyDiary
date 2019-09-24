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
using System.Xml;
using Microsoft.Win32;

namespace MyDiary
{
    public class DiaryModel
    {
        public DiaryModel()
        {  }

        public string Emotion;
        public string Color;
        public string Date;
        public string Time;
        public string Weekday;
        public string Diary;
    }

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public string original_text = "记录这一刻吧...";
        public string record_text = "";
        public string Filepath { get; set; }
        public const string respath = @"./m.resx";
        public string pword = "123456";
        public List<DiaryModel> diaryList;
        int emotion = 0;  //0-happy 1-sad 2-angry
        int win_now = 0;
        int R { get; set; }
        int G { get; set; }
        int B { get; set; }

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
                XmlDocument doc = new XmlDocument();
                doc.Load(Filepath);
                XmlNode root = doc.SelectSingleNode("MyDiary");

                XmlElement xelKey = doc.CreateElement("Record");

                XmlAttribute xaEmotion = doc.CreateAttribute("Emotion");
                xaEmotion.InnerText = this.Label_emotion.Content.ToString();
                xelKey.SetAttributeNode(xaEmotion);

                XmlAttribute xaColor = doc.CreateAttribute("Color");
                xaColor.InnerText = R.ToString("X2") + G.ToString("X2") + B.ToString("X2");
                xelKey.SetAttributeNode(xaColor);

                XmlAttribute xaDate = doc.CreateAttribute("Date");
                xaDate.InnerText = DateTime.Now.ToString("yyyy-MM-dd");
                xelKey.SetAttributeNode(xaDate);

                XmlAttribute xaTime = doc.CreateAttribute("Time");
                xaTime.InnerText = DateTime.Now.Hour.ToString("D2") + ":" + DateTime.Now.Minute.ToString("D2");
                xelKey.SetAttributeNode(xaTime);

                XmlAttribute xaWeekday = doc.CreateAttribute("Weekday");
                xaWeekday.InnerText = DateTime.Now.DayOfWeek.ToString();
                xelKey.SetAttributeNode(xaWeekday);

                XmlAttribute xaDiary = doc.CreateAttribute("Diary");
                xaDiary.InnerText = this.diaryBox.Text;
                xelKey.SetAttributeNode(xaDiary);

                root.AppendChild(xelKey);

                doc.Save(Filepath);


                #region
                /*
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
                */
                #endregion


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

            System.Resources.ResXResourceReader rr = new System.Resources.ResXResourceReader(respath);
            var dict = rr.GetEnumerator();
            while (dict.MoveNext())
            {
                if (dict.Key.ToString() == "FILEPATH")
                    Filepath = dict.Value.ToString();
                if (dict.Key.ToString() == "PASSWORD")
                    pword = dict.Value.ToString();
            }
            rr.Close();

            /*
            try
            {
                ManageReg();
            }
            catch
            {
                MessageBox.Show("请使用管理员权限打开本应用。");
                Application.Current.Shutdown();
            }
            */

            string path = System.IO.Path.GetDirectoryName(Filepath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                FileStream fs = new FileStream(Filepath, FileMode.Append);
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
        private void Label_random_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Label_random.FontSize = 24;
        }

        private void Label_random_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Label_random.FontSize = 18;
        }

        private void Label_random_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Random rd = new Random();
            int count = diaryList.Count();
            int now = rd.Next(0, count - 1);
            DiaryModel diary = diaryList[now];

            diaryViewerBox.Text = diary.Diary;

            Label_emotionviewer.Content = diary.Emotion;

            Label_timeviewer.Content = diary.Date + " " + diary.Weekday + " " + diary.Time;

            R = Convert.ToInt32(diary.Color.Substring(0, 2), 16);
            G = Convert.ToInt32(diary.Color.Substring(2, 2), 16);
            B = Convert.ToInt32(diary.Color.Substring(4, 2), 16);
            byte[] color_R = BitConverter.GetBytes(R);
            byte[] color_G = BitConverter.GetBytes(G);
            byte[] color_B = BitConverter.GetBytes(B);
            Color color = Color.FromRgb(color_R[0], color_G[0], color_B[0]);
            SolidColorBrush myBrush = new SolidColorBrush(color);
            this.MyDiary.Background = myBrush;
        }

        public void loadDiary()
        {
            diaryList = new List<DiaryModel>();

            XmlDocument doc = new XmlDocument();

            doc.Load(Filepath);

            XmlNode xn = doc.SelectSingleNode("MyDiary");
            XmlNodeList xnl = xn.ChildNodes;

            foreach (XmlNode node in xnl)
            {
                DiaryModel diary = new DiaryModel();
                XmlElement xe = (XmlElement)node;
                diary.Emotion = xe.GetAttribute("Emotion").ToString();
                diary.Color = xe.GetAttribute("Color").ToString();
                diary.Date = xe.GetAttribute("Date").ToString();
                diary.Time = xe.GetAttribute("Time").ToString();
                diary.Weekday = xe.GetAttribute("Weekday").ToString();
                diary.Diary = xe.GetAttribute("Diary").ToString();
                diaryList.Add(diary);
            }
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
                case 4:
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
                    WinChange(4);
                    
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
                    PwBox.Focus();
                    break;
                case 1:
                    WinChange(0);
                    break;
                case 2:
                    WinChange(1);
                    PwBox.Focus();
                    break;
                case 3:
                    WinChange(1);
                    PwBox.Focus();
                    break;
                case 4:
                    WinChange(0);
                    break;
                default:
                    WinChange(0);
                    break;
            }
        }

        /// <summary>
        /// 选择当前有效窗口
        /// </summary>
        /// <param name="win_id">0-ui 1-pw 2-help 3-changepw 4-viewer</param>
        public void WinChange(int win_id)
        {
            PwBox.Password = "";
            OldPwBox.Password = "";
            NewPwBox.Password = "";
            if (win_id == 0)
            {
                Label_open.Content = "o";
                Label_open.ToolTip = "Open Diary";
                win_now = 0;
                Grid_ui.IsEnabled = true;
                Grid_ui.Visibility = Visibility.Visible;
                Grid_pw.IsEnabled = false;
                Grid_pw.Visibility = Visibility.Hidden;
                Grid_help.IsEnabled = false;
                Grid_help.Visibility = Visibility.Hidden;
                Grid_changepw.IsEnabled = false;
                Grid_changepw.Visibility = Visibility.Hidden;
                Grid_viewer.IsEnabled = false;
                Grid_viewer.Visibility = Visibility.Hidden;
                Label_change.IsEnabled = true;
                Label_change.Visibility = Visibility.Visible;
                Label_random.IsEnabled = false;
                Label_random.Visibility = Visibility.Hidden;
            }
            else if(win_id == 1)
            {
                Label_open.Content = "o";
                Label_open.ToolTip = "Open Diary";
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
                Grid_viewer.IsEnabled = false;
                Grid_viewer.Visibility = Visibility.Hidden;
                Label_change.IsEnabled = true;
                Label_change.Visibility = Visibility.Visible;
                Label_random.IsEnabled = false;
                Label_random.Visibility = Visibility.Hidden;
            }
            else if(win_id == 2)
            {
                Label_open.Content = "o";
                Label_open.ToolTip = "Open Diary";
                win_now = 2;
                Grid_ui.IsEnabled = false;
                Grid_ui.Visibility = Visibility.Hidden;
                Grid_pw.IsEnabled = false;
                Grid_pw.Visibility = Visibility.Hidden;
                Grid_help.IsEnabled = true;
                Grid_help.Visibility = Visibility.Visible;
                Grid_changepw.IsEnabled = false;
                Grid_changepw.Visibility = Visibility.Hidden;
                Grid_viewer.IsEnabled = false;
                Grid_viewer.Visibility = Visibility.Hidden;
                Label_change.IsEnabled = true;
                Label_change.Visibility = Visibility.Visible;
                Label_random.IsEnabled = false;
                Label_random.Visibility = Visibility.Hidden;
            }
            else if(win_id == 3)
            {
                Label_open.Content = "o";
                Label_open.ToolTip = "Open Diary";
                win_now = 3;
                Grid_ui.IsEnabled = false;
                Grid_ui.Visibility = Visibility.Hidden;
                Grid_pw.IsEnabled = false;
                Grid_pw.Visibility = Visibility.Hidden;
                Grid_help.IsEnabled = false;
                Grid_help.Visibility = Visibility.Hidden;
                Grid_changepw.IsEnabled = true;
                Grid_changepw.Visibility = Visibility.Visible;
                Grid_viewer.IsEnabled = false;
                Grid_viewer.Visibility = Visibility.Hidden;
                Label_change.IsEnabled = true;
                Label_change.Visibility = Visibility.Visible;
                Label_random.IsEnabled = false;
                Label_random.Visibility = Visibility.Hidden;
            }
            else if(win_id == 4)
            {
                win_now = 4;
                Label_open.Content = "←";
                Label_open.ToolTip = "Back";
                loadDiary();
                Grid_ui.IsEnabled = false;
                Grid_ui.Visibility = Visibility.Hidden;
                Grid_pw.IsEnabled = false;
                Grid_pw.Visibility = Visibility.Hidden;
                Grid_help.IsEnabled = false;
                Grid_help.Visibility = Visibility.Hidden;
                Grid_changepw.IsEnabled = false;
                Grid_changepw.Visibility = Visibility.Hidden;
                Grid_viewer.IsEnabled = true;
                Grid_viewer.Visibility = Visibility.Visible;
                Label_change.IsEnabled = false;
                Label_change.Visibility = Visibility.Hidden;
                Label_random.IsEnabled = true;
                Label_random.Visibility = Visibility.Visible;
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
                case 4:
                    WinChange(3);
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

        #region
        /*
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
        */
        #endregion


        private void Label_Chart_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Label_Chart.FontSize = 24;
        }

        private void Label_Chart_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Label_Chart.FontSize = 18;
        }

        private void Label_Chart_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ChartWindow cwindow = new ChartWindow(Filepath, R, G, B);
            cwindow.Show();
        }

        private void NewPwBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ChangePW();
            }
        }

        #region
        /*
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
        */
        #endregion

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
                System.Resources.ResXResourceWriter rw = new System.Resources.ResXResourceWriter(respath);
                rw.AddResource("PASSWORD", pword);
                rw.Close();
                MessageBox.Show("修改成功!");
                WinChange(2);
            }
        }
    }
}
