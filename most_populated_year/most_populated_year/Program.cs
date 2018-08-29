using System;

namespace most_populated_year
{
    class Program
    {
        static void Main(string[] args)
        {

            //read the file into a string
            string data = System.IO.File.ReadAllText(@"data.txt");

            //parse the initial string into lines; one line for each person
            string[] unrefined_people = data.Split('\n');

            //create required variables
            string[,] refined_data = new string[unrefined_people.Length, 4];
            int[] birth_years = new int[unrefined_people.Length];
            int[] death_years = new int[unrefined_people.Length];

            //loop through data to parse the desired information 
            for (int i = 0; i < unrefined_people.Length; ++i)
            {
                string[] holder = unrefined_people[i].Split(' ','-');
                birth_years[i] = Int32.Parse(holder[2]);
                death_years[i] = Int32.Parse(holder[3]);
            }

            //count the number of people alive in each year
            int[] pop_count = new int[101];
            int counter = 0;
            for (int i = 0; i < 101; ++i)
            {
                for (int j = 0; j < unrefined_people.Length; ++j)
                {
                    if (birth_years[j] == i + 1900) ++counter;
                    if (death_years[j] == i + 1900) --counter;
                }
                //tells the number of people in each year
                //formated with the index being years after 1900
                pop_count[i] = counter;
            }

            //find the max number of people alive and the corresponding year
            int max = 0;
            int max_year = 0; 
            for (int i = 0; i < 101; ++i)
            {
                if (pop_count[i] > max)
                {
                    max = pop_count[i];
                    max_year = i + 1900;
                }
            }

            //display the results
            Console.WriteLine("The year with the most individuals alive in a single year is " + max_year);
            Console.WriteLine("In " + max_year + " there were " + max + " people alive.");

            //leave the results up until they aren't needed.
            Console.WriteLine("Press any key to exit.");



            System.Console.ReadKey();
        }
    }
}
