using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace 自动六学
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<char, string> _sixLearnDictionary = new Dictionary<char, string>();

        private static readonly string[] sixLearn =
        {
            "孙悟空", "师傅唐僧", "猪八戒",
            "大闹天宫","观音菩萨"
        };

        private static readonly Tuple<string, string>[] sixlearnTuples = {
            new Tuple<string, string>("行者", "孙行者"),
            new Tuple<string, string>("十", "八十一难"),
            new Tuple<string, string>("白龙马","白龙马"),
            new Tuple<string, string>("沙","沙僧"),
            new Tuple<string, string>("西取经","西天取经"),
            new Tuple<string, string>("吴承恩","作者吴承恩"),
            new Tuple<string, string>("圣","齐天大圣孙悟空"),
            new Tuple<string, string>("骨精晶","三打白骨精")
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            foreach (var str in sixLearn)
            {
                foreach (var cha in str)
                {
                    _sixLearnDictionary.Add(cha, str);
                }
            }

            foreach (var tuple in sixlearnTuples)
            {
                foreach (var cha in tuple.Item1)
                {
                    _sixLearnDictionary.Add(cha, tuple.Item2);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string ans = "";
            if (Textbox1.Text.Contains("白骨精"))
                ans = "白骨精";
            else
            {
                foreach (var cha in Textbox1.Text)
                {
                    if (_sixLearnDictionary.ContainsKey(cha))
                    {
                        ans = _sixLearnDictionary[cha];
                        break;
                    }
                }
            }


            if (ans != string.Empty)
            {
                Rtb.Text =
                    $"说起{Textbox1.Text}，我就想到了西游记中的{ans}。今年下半年，中美合拍的西游记即将正式开机，我继续扮演美猴王孙悟空，" +
                    "我会用美猴王艺术形象努力创造一个正能量的形象，文体两开花，弘扬中华文化，希望大家能多多关注。";
            }
            else
            {
                Rtb.Text =
                    $"说起{Textbox1.Text}，我就想到了西游精神。今年下半年，中美合拍的西游记即将正式开机，我继续扮演美猴王孙悟空，" +
                    "我会用美猴王艺术形象努力创造一个正能量的形象，文体两开花，弘扬中华文化，希望大家能多多关注。";
            }
        }
    }
}
