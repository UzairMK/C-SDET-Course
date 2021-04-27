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
using CalculatorLib;
using System.IO;

namespace Lab__11_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _num1 = 0;
        private int _num2 = 0;
        private string _operator = "";
        private string _history = "";
        private Queue<string> _historyQueue = new Queue<string>();
        private bool _compactHistoryEnabled = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Equals(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            _operator = button.Content.ToString();
            bool num1Bool = int.TryParse(TextBoxNum1.Text, out _num1);
            bool num2Bool = int.TryParse(TextBoxNum2.Text, out _num2);

            if (!num1Bool || !num2Bool)
            {
                LabelResult.Content = "Invalid Input";
                return;
            }

            try
            {
                switch (_operator)
                {
                    case "+":
                        LabelResult.Content = Calculator.Add(_num1, _num2);
                        break;
                    case "-":
                        LabelResult.Content = Calculator.Subtract(_num1, _num2);
                        break;
                    case "x":
                        LabelResult.Content = Calculator.Multiply(_num1, _num2);
                        break;
                    case "/":
                        LabelResult.Content = Calculator.Divide(_num1, _num2);
                        break;
                    case "%":
                        LabelResult.Content = Calculator.Modulo(_num1, _num2);
                        break;
                    default:
                        break;
                }

                string historyItem = $"{_num1} {_operator} {_num2}\n= {LabelResult.Content}\n";
                _historyQueue.Enqueue(historyItem);
                AddToHistory(historyItem);
                ScrollViewerHistory.Content = _history;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Calculator Error");
            }
        }

        private void ButtonClearHistory_Click(object sender, RoutedEventArgs e)
        {
            _history = "";
            ScrollViewerHistory.Content = _history;
            _historyQueue.Clear();
        }

        private void ButtonCompactHistory_Click(object sender, RoutedEventArgs e)
        {
            if (_compactHistoryEnabled)
            {
                ButtonCompactHistory.Content = "S";
                _compactHistoryEnabled = false;
            }
            else
            {
                ButtonCompactHistory.Content = "C";
                _compactHistoryEnabled = true;
            }

            RemakeHistory();
        }

        public async void ExportHistory(object sender, RoutedEventArgs e)
        {
            //File.WriteAllText(@"Int32CalcHistory.txt", $"{DateTime.Now.ToString("###[dd/MM/yyyy]###[HH:mm:ss]###")}\n" + _history);
            using StreamWriter file = new("Int32CalcHistory.txt", append: true);
            await file.WriteLineAsync(DateTime.Now.ToString("###[dd/MM/yyyy]###[HH:mm:ss]###"));
            await file.WriteLineAsync(_history);
        }

        private void AddToHistory(string historyItem)
        {
            if (_compactHistoryEnabled)
                _history = historyItem + _history;
            else
                _history = historyItem + "\n" + _history;
        }

        private void RemakeHistory()
        {
            _history = "";

            foreach (var item in _historyQueue)
            {
                AddToHistory(item);
            }

            ScrollViewerHistory.Content = _history;
        }

        private void ButtonResultToNum1_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(LabelResult.Content.ToString(), out _num1))
                return;
            TextBoxNum1.Text = LabelResult.Content.ToString();
            TextBoxNum2.Text = "";
            LabelResult.Content = "";
        }
    }
}
