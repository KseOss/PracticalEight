using Pr8;
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

namespace PracticalEight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Exit_Click(object sender, RoutedEventArgs e) //Создание кнопки для меню "Справка" - выход
        {
            this.Close();
        }

        // Обработчик кнопки "О программе"
        private void About_Click(object sender, RoutedEventArgs e) //Создание кнопки для меню "Справка" - о программе
        {
            MessageBox.Show("Разработчик: Сухомяткина Ксения\nНомер работы: 8\nЗадание: Создать интерфейсы - автомобиль, пассажирский транспорт. Создать класс автобус. Класс должен включать конструктор, функцию для формирования строки информации об автобусе. Сравнение производить по вместимости пассажиров.", "О программе");
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            string modelbus = txtModel.Text;
            string seatpas = txtSeat.Text;

            //проверка на пустые значения
            if (string.IsNullOrWhiteSpace(modelbus) || string.IsNullOrEmpty(seatpas)) //Если одно из полей пустое, показываем сообщение об ошибке
            {
                MessageBox.Show("Пожалуйста заполните все поля", "ОШИБКА ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return; //выход из метода если есть ошибка
            }
            if (int.TryParse(seatpas, out int setaPassanger))
            {
                //создание нового объекта Bus с веденной моделью и количеством мест
                Bus bus = new Bus(modelbus, setaPassanger);
                string busInfo = bus.GetInfo(); //получение информации об автобусе
                txtInfoBus.Text = busInfo; //отображение информации в текстовом поле для вывода
            }
            else
            {
                //если преобразование не удалось, показываем сообщение об ошибке
                MessageBox.Show("Введите корректное количество мест","Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
