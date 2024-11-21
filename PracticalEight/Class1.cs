using PracticalEight;
using System;

namespace Pr8
{
    public class Bus : IAuto, IPassenger, ICloneable, IComparable
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
        public int CompareTo(object obj)
        {
            Bus temp = obj as Bus;
            if (temp != null) 
            {
                return this.SeatPassenger.CompareTo(temp.SeatPassenger);
            }
            return 0;
        }
        public object Clone()
        {
            return new Bus(this.ModelBus, this.SeatPassenger);
        }

    }

}
