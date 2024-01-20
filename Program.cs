
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Threading;

namespace exerciseCountries
{
    internal class Program
    {
        public class Land
        {
            private string Name { get; set; }
            private string Capital { get; set; }
            private int Surface { get; set; }
            private int Inhabitant { get; set; }

            public static List<Land> LandLista = new List<Land>();

            public Land(string name, string capital, int surface, int inhabitant)
            {
                Name = name;
                Capital = capital;
                Surface = surface;
                Inhabitant = inhabitant;
            }

            public void AddInfo()
            {
                Console.WriteLine("Add info about the country!");

                string name;
                do
                {
                    Console.WriteLine("Enter name of the country:");
                    name = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(name) || name.Any(char.IsDigit));

                string capital;
                do
                {
                    Console.WriteLine("Enter capital of the country:");
                    capital = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(capital) || capital.Any(char.IsDigit));

                int surface;
                while (true)
                {
                    Console.WriteLine("Enter size of the surface:");
                    if (int.TryParse(Console.ReadLine(), out surface) && surface > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a positive integer for surface size.");
                    }
                }

                int inhabitant;
                while (true)
                {
                    Console.WriteLine("Enter how many inhabitants live in the country:");
                    if (int.TryParse(Console.ReadLine(), out inhabitant) && inhabitant > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a positive integer for the number of inhabitants.");
                    }
                }

                Land land = new Land(name, capital, surface, inhabitant);
                Land.LandLista.Add(land);

                Console.WriteLine("\nCountry information added successfully!");
                Thread.Sleep(1000);
            }

            public void ShowInfoAndInhabitant()
            {
                foreach (Land land in LandLista)
                {
                    Console.WriteLine($"Country: {land.Name}, Capital: {land.Capital}, Surface: {land.Surface}, Inhabitants: {land.Inhabitant}");
                }
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }

            public void CalculatePopulationDensity()
            {
                Console.WriteLine("The population density for each country:");
                foreach (Land land in LandLista)
                {
                    //double populationDensity = (double)land.Inhabitant / land.Surface;
                    //Console.WriteLine($"Country: {land.Name}, Density: {populationDensity}");
                    Console.WriteLine($"Country: {land.Name}, Density: {land.Inhabitant / land.Surface}");
                }
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }

            public void SortCountry()
            {
                LandLista.Sort((country1, country2) =>
                {
                    int density1 = (int)country1.Inhabitant / country1.Surface;
                    int density2 = (int)country2.Inhabitant / country2.Surface;
                    return density1.CompareTo(density2);
                });

                Console.WriteLine("Countries sorted by population density:");
                foreach (var country in LandLista)
                {
                    int density = (int)country.Inhabitant / country.Surface;
                    Console.WriteLine($"{country.Name}: Population Density - {density} inhabitants per square unit");
                }
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }

            public void ShowSmallestDensityCountry()
            {
                Land smallestDensityCountry = LandLista.Aggregate((minDensityCountry, nextCountry) =>
                {
                    int minDensity = (int)minDensityCountry.Inhabitant / minDensityCountry.Surface;
                    int nextDensity = (int)nextCountry.Inhabitant / nextCountry.Surface;

                    return minDensity < nextDensity ? minDensityCountry : nextCountry;
                });

                int smallestDensity = (int)smallestDensityCountry.Inhabitant / smallestDensityCountry.Surface;

                Console.WriteLine($"Country with the smallest population density:");
                Console.WriteLine($"{smallestDensityCountry.Name}: Population Density - {smallestDensity} inhabitants per square unit");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }

            public void Text(string text)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(text);
                Console.ResetColor();
                Thread.Sleep(3000);
            }

        }


        static void Main(string[] args)
        {
            Land.LandLista.Add(new Land("USA", "Washington D.C.", 9834000, 331002651));
            Land.LandLista.Add(new Land("China", "Beijing", 9597000, 1444216107)); 
            Land.LandLista.Add(new Land("Sweden", "Stockholm", 450295, 10099265)); 
            Land.LandLista.Add(new Land("Germany", "Berlin", 357022, 83149300)); 
            Land.LandLista.Add(new Land("India", "New Delhi", 3287263, 1380004385));
            Land.LandLista.Add(new Land("Brazil", "Brasília", 8515767, 212559417));
            Land.LandLista.Add(new Land("Australia", "Canberra", 7692024, 25499884));

            Land land = new Land("Sweden", "Stockholm", 450295, 10099265);
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("------------------------------------");
                Console.WriteLine("              Welcome.");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("[1] - Add country.");
                Console.WriteLine("[2] - Show countries.");
                Console.WriteLine("[3] - Calculate population density.");
                Console.WriteLine("[4] - Sort countries by density.");
                Console.WriteLine("[5] - Show the smallest country.");
                Console.WriteLine("[6] - Exit program.");

                Int32.TryParse(Console.ReadLine(), out int input);

                if (input == 1)
                {
                    land.AddInfo();
                }
                else if (input == 2)
                {
                    land.ShowInfoAndInhabitant();
                }
                else if (input == 3)
                {
                    land.CalculatePopulationDensity();
                }
                else if (input == 4)
                {
                    land.SortCountry();
                }
                else if (input == 5)
                {
                    land.ShowSmallestDensityCountry();
                }
                else if (input == 6)
                {
                    land.Text("Shutting down... Goodbye!");
                    return;
                }
                else { land.Text("Wrong input.."); }
            }
        }
    }

}
