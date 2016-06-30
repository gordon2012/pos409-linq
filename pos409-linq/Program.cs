/*

 [X] The first step is to read a text file into the program. The file should be a list of cities and state abbreviations. Each line should look as follows: Chicago, IL. Read each
 city/state into a list. You do not need to separate the city and state into separate fields. As you read each line of the file, count up how many total cities are in the file
 and then present the total to the end user.
 
The next step is to develop a set of queries and present the results to the end user. In total you will do five Linq queries:

 [X] Execute a Linq query to count how many records are in the list and present the total to the end user.

 [X] Execute a Linq query to sort the entries in the list in ascending order and present the list of cities to the end user, in order.

 [ ] Execute a Linq query to find all states starting with a specific letter. Prompt the user for the letter they want to look for, then present those that start with that
 letter to them. There is no need at this time to validate that they entered a letter.

 [ ] Execute a Linq query to find all cities that are from a given state. Prompt the user for the state they want to look for, then present those that are from that state to
 them. Again there is no need to validate that they entered a valid state.

 [ ] Last, design your own Linq query and present the results to the end user. Be creative!

 [ ] Please note that you may need to do some research on MSDN to find Linq methods to handle some of the queries. In addition, you are not going to find answers by searching
 for things like "how to handle user input with Linq". You are going to need to use your analysis skills to figure out the steps to accomplish these requirements using logic,
 the skills you have built over the last few weeks, and what you have learned about Linq.

*/
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

            // Display contents of list
            //
            cities.ForEach(city => Console.WriteLine(city));
            
            // Display count incremented while loading list
            //
            Console.WriteLine(count);

            // Display count using LINQ query
            //
            int linqCount = cities.Count();
            Console.WriteLine(linqCount);

            // Display list of cities in ascending order
            //
            List<string> ascCities = new List<string>();
            ascCities.AddRange(cities.OrderBy(i => i));
            ascCities.ForEach(city => Console.WriteLine(city));



            Console.ReadLine();
        }
    }
}
