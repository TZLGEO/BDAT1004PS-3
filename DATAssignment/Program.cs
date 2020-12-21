using DATAssignment;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            //T = number of test cases
            //N = number of students
            //K = threshold
            //N = arrival time for number of students as array
            //Non positive arrival times indicates on time
            //1 ≤ 𝑡 ≤ 10
            //1 ≤ 𝑛 ≤ 1000
            //1 ≤ 𝑘 ≤ 𝑛
            //−100 ≤ 𝑎[𝑖] ≤ 100 𝑤ℎ𝑒𝑟𝑒 𝑖 ∈ [1, … 𝑛]
            //Output Yes or No

            int loops = 0;
            List<EvaluationCriteria> evaluationCriterias = new List<EvaluationCriteria>();
            Console.WriteLine("Please enter number of Test cases");

            int numberOfTestCases = Int32.Parse(Console.ReadLine());

            step2: Console.WriteLine("Please enter number of students");

            int numberOfStudents = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Please enter threshold.");

            int threshold = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Please enter students arrival times. Each value must be separated by space.");

            var rawArrivalTimes = Console.ReadLine().Trim();

            string[] splittedRawArrivalTimes = rawArrivalTimes.Split(' ');
            int[] convertedArrivalTimes = new int[splittedRawArrivalTimes.Length];

            for (int i = 0; i < splittedRawArrivalTimes.Length; i++)
            {
                convertedArrivalTimes[i] = Int32.Parse(splittedRawArrivalTimes[i]);
            }

            var criteria = new EvaluationCriteria
            {
                Threshold = threshold,
                NumerOfStudents = numberOfStudents,
                ArrivalTimes = convertedArrivalTimes
            };

            evaluationCriterias.Add(criteria);
            loops++;

            if (loops < numberOfTestCases)
            {
                goto step2;
            }

            foreach (var item in evaluationCriterias)
            {
                Console.WriteLine(AngryProfessor(numberOfTestCases, item.NumerOfStudents, item.Threshold, item.ArrivalTimes));
            }

            Console.ReadKey();
            //Press enter on terminal after the first function finishes to run the question 2

            Console.WriteLine("Answer for secnd question below.");


            var arrayA = new int[2] { 2, 4 };
            var arrayb = new int[3] { 16, 32, 96 };
            var result = GetTotalX.GetTotalx(arrayA, arrayb);

            Console.WriteLine(result);



        }


        
        public static string AngryProfessor(int numberOfCases, int numberOfStudents, int threshold, int[] arrivalTimes)
        {
            var arrivedEarlyCounter = 0;
            var arrivedLateCounter = 0;

            //Non positive arrival times indicates on time
            //1 ≤ 𝑡 ≤ 10
            //1 ≤ 𝑛 ≤ 1000
            //1 ≤ 𝑘 ≤ 𝑛
            //−100 ≤ 𝑎[𝑖] ≤ 100 𝑤ℎ𝑒𝑟𝑒 𝑖 ∈ [1, … 𝑛]

            if (numberOfCases > 10 || numberOfCases < 1
                || numberOfStudents < 1 || numberOfStudents > 1000 ||
                threshold < 1 || threshold > numberOfStudents ||
                Array.Exists(arrivalTimes, el => el < -100 || el > 100))
            {
                Console.WriteLine("One or more inputs are invalid - Unable to process date.");
                return "YES";
            }

            for (int i = 0; i < numberOfStudents; i++)
            {
                if (arrivalTimes[i] <= 0)
                {
                    //arrived early
                    arrivedEarlyCounter++;
                }
                else
                {
                    //arrived late
                    arrivedLateCounter++;
                }

            }

            if (arrivedEarlyCounter == threshold)
            {
                return "NO";
            }
            else
            {
                return "YES";
            }
        }

    }

    public class EvaluationCriteria
    {
        public int NumerOfStudents { get; set; }
        public int Threshold { get; set; }
        public int[] ArrivalTimes { get; set; }
    }
}
