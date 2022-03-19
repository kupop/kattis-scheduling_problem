using System;

namespace kattis_scheduling_problem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] splitInputValues = input.Split(new char[] { ' ' }, StringSplitOptions.None);
            int q = Int32.Parse(splitInputValues[0]); // time needed to complete the longer batches
            int m = Int32.Parse(splitInputValues[1]); // the number of machines
            int s = Int32.Parse(splitInputValues[2]); // number of 1-second time slots purchased (s-jobs)
            int l = Int32.Parse(splitInputValues[3]); // number of q-second time slots purchased
            int totalTimeOfQJobs = 0;
            int remainderOfQJobs = 0;
            int remainderOfSJobs = s;
            int totalTimeOfSJobs = 0;

            // calculate q-jobs total time
            totalTimeOfQJobs = (l / m) * q;

            remainderOfQJobs = (l % m);
            if (remainderOfQJobs != 0)// if existing, handle remainder
            {
                // add time for remainder of q-jobs
                totalTimeOfQJobs += q;

                // calculate number of idle computers
                int idleComputers = m - (remainderOfQJobs);

                // fill up idle computers with s-jobs
                int roomForOneJobs = idleComputers * q;

                if (roomForOneJobs > s)//end of calculations
                {
                    Console.WriteLine(totalTimeOfQJobs); 
                    Environment.Exit(0);
                }
                else
                    remainderOfSJobs -= roomForOneJobs;
            }

            // fill computers with remainder of s-jobs
            totalTimeOfSJobs = remainderOfSJobs / m;

            if (remainderOfSJobs % m != 0)// if remainder exists, handle
                totalTimeOfSJobs += 1;
            
            Console.WriteLine(totalTimeOfQJobs + totalTimeOfSJobs);
        }
    }
}
