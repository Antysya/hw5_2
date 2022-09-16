using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace hw5_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                IFunctions p1 = new Passenger { Stamp = "Volvo", Model = "XC90", Cost = 7000000, Type = "Кроссовер", PassengerNumbers = 5 };
                IFunctions c1 = new Cargo { Stamp = "Hyundai", Model= "HD78", Cost = 2900000, Type = "Рефрижиратор", Capacity = 5 };
                IFunctions m1 = new Moto {Stamp = "Kawasaki", Model = "Z 1000SX", Cost = 1400000, Type = "Спорт-туризм", Power = 142 };

                IFunctions pl1 = new Plane { Stamp ="Zodiac", Model="CH 650", Cost =3300000, NumberEngines = 1, Distance = 925 };
                IFunctions h1 = new Helicopter {Stamp= "McDonnel-Douglas", Model="MD 900 Explorer", Cost = 75000000, NumberEngines = 2, NumberScrews = 1 };
                IFunctions a1 = new Airship { Stamp = "AY-30", Model = "AY-30", Cost = 2500000, NumberEngines = 2, FillingGas = "Гелий" };

                Park park = new Park();
                park.park = new List<IFunctions> {p1, c1, m1, pl1, h1, a1 };

                while (true)
                {
                    WriteLine("Выберете действие, которое хотите произвести:\n " +
                        "1. Распечатать весь автопарк; \n " +
                        "2. Распечатать парк наземного транспорта; \n " +
                        "3. Распечатать парк воздушного транспорта; \n " +
                        "4. Стоимость всего автопарка; \n " +
                        "5. Стоимость наземного транспорта; \n " +
                        "6. Стоимость воздушного транспорта; \n " +
                        "7. Выйти из программы.");
                    WriteLine();

                    int posnum = Convert.ToInt32(ReadLine());

                    switch (posnum)
                    {
                        case 1:
                            {
                                foreach (IFunctions item in park.park)
                                {
                                    WriteLine(item);
                                    WriteLine($"{item.IsWork()}  {item.Work()}  {item.Transfer()}");
                                };
                            }
                            break;
                        case 2:
                            {
                                WriteLine("Наземный транспорт: ");
                                foreach (IFunctions item in park.park)
                                {
                                    if (item is Ground)
                                    {
                                        WriteLine($"{item.Work()}  {item}");
                                    }
                                };
                            }
                            break;
                        case 3:
                            {
                                WriteLine("Воздушный транспорт: ");
                                foreach (IFunctions item in park.park)
                                {
                                    if (item is Air)
                                    {
                                        WriteLine($"{item.Work()}  {item}");
                                    }
                                };
                            }
                            break;
                        case 4:
                            {
                                WriteLine($"Стоимость всего наземного транспорта = {(park as IPark).Costs()}\n");
                            }
                            break;
                        case 5:
                            {
                                Park parkA = new Park();
                                parkA.park = new List<IFunctions> {};
                                foreach (IFunctions item in park.park)
                                {
                                    if (item.IsWork() == "Наземный транспорт")
                                    {
                                        parkA.park.Add(item);
                                    }
                                };
                                WriteLine($"Стоимость наземного транспорта = {(parkA as IPark).Costs()}\n");
                            }
                            break;
                        case 6:
                            {
                                Park parkV = new Park();
                                parkV.park = new List<IFunctions> { };

                                foreach (IFunctions item in park.park)
                                {
                                    if (item is Air)
                                    {
                                        parkV.park.Add(item);
                                    }
                                };
                                WriteLine($"Стоимость воздушного транспорта = {(parkV as IPark).Costs()}\n");
                            }
                            break;
                        case 7:
                            return;

                        default:
                            WriteLine("Вы выбрали несуществующий пункт меню. Выберите снова.");
                            continue;
                    }
                }
            }
        }
    }
}
