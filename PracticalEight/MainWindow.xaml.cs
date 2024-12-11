using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PRNINE;
using static PRNINE.Class1;

namespace PrNine
{
    public partial class MainWindow : Window
    {
        private Participant[] participant; //массив участников забега
        private int participantCount;
        public MainWindow()
        {
            InitializeComponent();
            participant = new Participant[8]; //можно заполнить в масив максимум 8 участников
            participantCount = 0; //счетчик участников забега начинается с нуля
        }
        //Кнопка о программе
        private void About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: Сухомяткина Ксения ИСП-34\nНомер работы: 9\nЗадание: Заполнить таблицу участников забега на 100 метров на 8 человек с полями: ФИО, номер, результат. Вывести результат на экран. Вывести средний результат.", "❗ О программе");
        }
        //Кнопка выхода
        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //Кнопка добавления участников
        private void AddPeople(object sender, RoutedEventArgs e)
        {
           
            if (participantCount < 8)
            {
                string fio = fio_TB.Text;
                if (int.TryParse(num_TB.Text, out int number) && double.TryParse(res_TB.Text,out double result))
                {
                    participant[participantCount] = new Participant(fio,number,result);
                    participantCount++;
                    //очистка полей ввода
                    fio_TB.Clear();
                    num_TB.Clear();
                    res_TB.Clear();

                    DisplayResults();
                }
                else
                {
                    MessageBox.Show("Пожалуста, введите корректные данные для номера и результат", "ОШИБКА ВВОДА");
                }
            }
            else
            {
                MessageBox.Show("Достигнуто максимальное количество участников","");
            }
        }
        private void DisplayResults()
        {
            
            DataTable dt = new DataTable();
            dt.Columns.Add("ФИО");
            dt.Columns.Add("Номер");
            dt.Columns.Add("Результат (сек)");
            double _result = 0;

            for (int i = 0; i < participantCount; i++)
            {
                dt.Rows.Add(participant[i].FIO, participant[i].Number, participant[i].Result);
                _result += participant[i].Result;
            }
            double AVG = _result / participantCount; //средний рузельтат
            ResultsDataGrid.ItemsSource = dt.DefaultView;
            AvgResults.Text = ($"Средний результат: {AVG:F2} секунд");


        }
    }
}
