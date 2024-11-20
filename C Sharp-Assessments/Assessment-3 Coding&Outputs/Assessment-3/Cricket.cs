using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace Assesment_3

{



    public class CricketTeam

    {
        public int Matches { get; set; }

        public int Sum { get; set; }


        public string Team_name { get; set; }



        public double Average { get; set; }

        public (int, int, double) Points_Calc(int matches_count)

        {

            Sum = 0;

            for (int i = 0; i < matches_count; i++)

            {

                Console.Write($"Enter score of match {i + 1}: ");

                Sum += Convert.ToInt32(Console.ReadLine());

            }

            Matches = matches_count;

            Average = (double)Sum / matches_count;

            return (Matches, Sum, Average);

        }

    }

    class Program

    {

        static void Main()

        {

            CricketTeam teams = new CricketTeam();

            Console.WriteLine("Enter  Team Name  ");

            string T_name = Console.ReadLine();

            teams.Team_name = T_name;

            Console.WriteLine("Enter number of matches ");

            int match_countt = Convert.ToInt32(Console.ReadLine());

            var (matches, sum, average) = teams.Points_Calc(match_countt);

            Console.WriteLine($"Team: {teams.Team_name}");

            Console.WriteLine($"Matches : {matches}");

            Console.WriteLine($"Sum: {sum}");

            Console.WriteLine($"Average: {average}");

            Console.ReadLine();

        }

    }

}

