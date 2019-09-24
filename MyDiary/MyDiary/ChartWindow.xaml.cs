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
using System.Windows.Shapes;
using System.Xml;

namespace MyDiary
{
    /// <summary>
    /// ChartWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ChartWindow : Window
    {
        public string Filepath { get; set; }
        int R { get; set; }
        int G { get; set; }
        int B { get; set; }
        public List<DiaryModel> diaryList;
        public int[] months = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public int[] days = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
        public int[] hours = new int[24] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public ChartWindow()
        {
            InitializeComponent();
        }

        public ChartWindow(string filepath, int R, int G, int B)
        {
            this.Filepath = filepath;
            this.R = R;
            this.G = G;
            this.B = B;
            InitializeComponent();
        }
        private void MyChart_Loaded(object sender, RoutedEventArgs e)
        {
            Colorit();
            LoadDiary();
            CountDiary();
            MessageBox.Show(string.Join(",", months) + '\n' + string.Join(",", days) + '\n' + string.Join(",", hours));
        }

        public void Colorit()
        {
            byte[] color_R = BitConverter.GetBytes(R);
            byte[] color_G = BitConverter.GetBytes(G);
            byte[] color_B = BitConverter.GetBytes(B);
            Color color = Color.FromRgb(color_R[0], color_G[0], color_B[0]);
            SolidColorBrush myBrush = new SolidColorBrush(color);
            this.MyChart.Background = myBrush;
        }

        public void LoadDiary()
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

        public void CountDiary()
        {
            foreach (DiaryModel d in diaryList)
            {
                //判断月份
                DateTime date = DateTime.Parse(d.Date);
                months[date.Month - 1] += 1;
                //判断星期几 0 is Sunday
                days[isWeekday(d.Weekday)] += 1;
                //判断几点
                DateTime time = DateTime.Parse(d.Time);
                hours[time.Hour] += 1;
            }
        }

        public int isWeekday(string weekday)
        {
            switch (weekday)
            {
                case "Monday":
                    return 0;
                case "Tuesday":
                    return 1;
                case "Wednesday":
                    return 2;
                case "Thursday":
                    return 3;
                case "Friday":
                    return 4;
                case "Saturday":
                    return 5;
                case "Sunday":
                    return 6;
                default:
                    return 0;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
