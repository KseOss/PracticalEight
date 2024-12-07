using PracticalEight;
using System;

namespace Pr8
{
    public class Bus : IAuto, IPassenger, ICloneable, IComparable //Класс Bus реализует несколько интерфейсов
    {
        public string ModelBus {  get; set; }
        public int SeatPassenger {  get; set; }

        public Bus(string modelBus, int setaPassenger) 
        { 
            ModelBus = modelBus;
            SeatPassenger = setaPassenger;    
        }
        public string GetInfo() 
        { 
            return $"Модель автобуса - {ModelBus} и количество вмещаемых пассажиров - {SeatPassenger} ";
        }
        public int CompareTo(object obj)//реализация интерфейса
            //позволяет сравнивать объекты с другими объектами
        {
            Bus temp = obj as Bus; //Принимает объект obj, который затем приводится к типу Bus
            if (temp != null) //Елси obj не является null и успешно приводится к типу Bus, производится сравнение количества мест между текущим объектом и переданным метсом
            {
                return this.SeatPassenger.CompareTo(temp.SeatPassenger);
            }
            return 0;
            //метод возращает положительное значение, если текущий объект имеет больше мест; отрицательное, если меньше мест; ноль если количество мест одинаковое
        }
        public object Clone() //создает и возвращает новый экземпляр класса Bus, копируя значения свойство ModelBus и SeatPassanger текущего обхекта
        {
            return new Bus(this.ModelBus, this.SeatPassenger);
        }

    }

}
