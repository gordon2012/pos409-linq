// Using LINQ
// Gordon Doskas
// POS/409
// July 4, 2016
// Carole Mckinney

// Program Description
// ===================
// This program reads a text file that contains cities and state abbreviations
// into a list, counts up and displays how many total cities are in the file,
// and executes and displays the results of five queries. The queries count how
// many records are in the list, sort the entries in the list in ascending
// order, finds all states starting with a specific letter, finds all cities
// that are from a given state, and sorts the list by state and then by city.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace pos409_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cities = new List<string>();
            int count = 0;

            // Read text file into list
            //
            try
            {
                using (StreamReader file = new StreamReader("input.txt"))
                {
                    string line;
                    while (!file.EndOfStream)
                    {
                        line = file.ReadLine();
                        if (!line.Equals(""))
                        { 
                            cities.Add(line);
                            count++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString() + ": " + ex.Message);
            }


            // Display count incremented while loading list
            //
            Console.WriteLine("Cities in file: " + Environment.NewLine + count + Environment.NewLine);


            // Display count using LINQ query
            //
            int linqCount = cities.Count();
            Console.WriteLine("Cities in list: " + Environment.NewLine + linqCount + Environment.NewLine);


            // Display list of cities in ascending order
            //
            List<string> ascCities = new List<string>();
            ascCities.AddRange(cities.OrderBy(i => i));
            Console.WriteLine("Cities in ascending order:");
            ascCities.ForEach(city => Console.WriteLine(city));


            // Display all states starting with a user specified letter
            //
            Console.WriteLine(Environment.NewLine + "States starting with a specified letter:");
            Console.Write("Please enter first letter of desired state" + Environment.NewLine + "> ");
            string letter = Console.ReadLine();
            List<string> states = new List<string>();
            states.AddRange(cities.Select(city => city.Split(',').ToList().Last().Trim()).Distinct());

            List<string> letterStates = new List<string>();
            letterStates.AddRange(states.Where(state => state.StartsWith(letter, StringComparison.OrdinalIgnoreCase)));
            letterStates.ForEach(c => Console.WriteLine(c));


            // Display all cities from a user specified state
            //
            Console.WriteLine(Environment.NewLine + "Cities in a specified state:");
            Console.Write("Please enter desired state" + Environment.NewLine + "> ");
            string inState = Console.ReadLine();

            List<string> citiesInState = new List<string>();
            citiesInState.AddRange(cities.Where(city => city.Split(',').ToList().Last().Trim().Equals(inState, StringComparison.OrdinalIgnoreCase)));
            citiesInState.ForEach(city => Console.WriteLine(city));


            // Custom query: All cities, ordered by State and then City
            //
            Console.WriteLine(Environment.NewLine + "Cities ordered by state and city:");
            List<string> orderedCities = new List<string>();
            orderedCities.AddRange(cities.OrderBy(city => city.Split(',').ToList().Last().Trim()).ThenBy(city => city));
            orderedCities.ForEach(city => Console.WriteLine(city));


            Console.WriteLine(Environment.NewLine + "Press enter to exit");
            Console.ReadLine();
        }
    }
}
