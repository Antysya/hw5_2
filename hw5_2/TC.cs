using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace hw5_2
{
    abstract class TC
    {
        public string Stamp { get; set; }
        public string Model { get; set; }
        public int Cost { get; set; }
        public override string ToString()
        {
            return $"\nМарка: {Stamp} Модель: {Model} Стоимость: {Cost} руб.";
        }
    }

    abstract class Ground : TC
    {
        public string Type { get; set; }
        public override string ToString()
        {
            return base.ToString()+$" Тип: {Type}";
        }
    }
    abstract class Air : TC
    {
        public int NumberEngines { get; set; }
        public override string ToString()
        {
            return base.ToString() + $" Вид: {NumberEngines}";
        }
    }

    interface IFunctions
    {
        string IsWork();
        string Work();
        string Transfer(); //перевожу
    }

    interface IPark
    {
        List<IFunctions> park { get; set; }
        int Costs();
    }

    class Passenger : Ground, IFunctions
    {
        public int PassengerNumbers { get; set; }
        public string IsWork()
        {
            return "Наземный транспорт"; 
        }

        public string Transfer()
        {
            return "Перевожу пассажиров. ";
        }
        public string Work()
        {
            return "Легковой. ";
        }
        public override string ToString()
        {
            return base.ToString() + $" Количество пассажиров: {PassengerNumbers} чел.";
        }

    }

    class Cargo : Ground, IFunctions
    {
        public int Capacity { get; set; }
        public string IsWork()
        { 
            return "Наземный транспорт"; 
        }
        public string Transfer()
        {
            return "Перевожу грузы. ";
        }
        public string Work()
        {
            return "Грузовой. ";
        }
        public override string ToString()
        {
            return base.ToString() + $" Грузоподъемность: {Capacity} т";
        }
        
    }

    class Moto : Ground, IFunctions
    {
        public int Power { get; set; }

        public string IsWork()
        {
            return "Наземный транспорт";
        }

        public string Transfer()
        {
            return "Катаю по красивым местам. ";
        }
        public string Work()
        {
            return "Мотоцикл. ";
        }
        public override string ToString()
        {
            return base.ToString() + $" Мощность: {Power} л.с.";
        }      
    }

    class Plane : Air, IFunctions
    {
        public int Distance { get; set; }
        public string IsWork()
        {
            return "Воздушный транспорт";
        }
        
        public string Transfer()
        {
            return "Перевожу пассажиров на другие континенты. ";
        }
        public string Work()
        {
            return "Самолет. ";
        }
        public override string ToString()
        {
            return base.ToString() + $" Дальность: {Distance} км";
        }
        
    }

    class Helicopter : Air, IFunctions
    {
        public int NumberScrews { get; set; }
        public string IsWork()
        {
            return "Воздушный транспорт";
        }

        public string Transfer()
        {
            return "Перевожу грузы на другие континенты. ";
        }
        public string Work()
        {
            return "Вертолет. ";
        }
        
        public override string ToString()
        {
            return base.ToString() + $" Количество несущих винтов: {NumberScrews}";
        }
    }

    class Airship : Air, IFunctions
    {
        public string FillingGas { get; set; }
        public string IsWork()
        {
            return "Воздушный транспорт"; 
        }

        public string Transfer()
        {
            return "Несу рекламу на борту. ";
        }
        public string Work()
        {
            return "Дирижабль. ";
        }
        public override string ToString()
        {
            return base.ToString() + $" Заполняющий газ: {FillingGas}";
        }   
    }

    class Park : TC, IPark
    {
        public List<IFunctions> park { get; set; }

        int IPark.Costs()
        {
            int sum = 0;
            foreach ( TC item in park)
            {
                sum += item.Cost;
            }
            return sum;
        }
    }
}
