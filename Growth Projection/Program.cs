using System;

namespace Growth_Projection
{
    class Program
    {
        static void enterAmounts(double[] amountEarned)
        {
            for (int i = 0; i < 12; ++i)
            {
                Console.WriteLine("Enter the amount earned in month {0}", i + 1);
                double monthEarned = Convert.ToDouble(Console.ReadLine());
                amountEarned[i] += monthEarned;
            }
        }

        static void Calculations(string[] percentages, double[] amountEarned, double overallPercentage, double averagePercentage, double projectedGrowth, double exponential)
        {
            for (int i = 0; i < 11; ++i)
            {
                percentages[i + 1] = (((amountEarned[i + 1] - amountEarned[i]) / amountEarned[i]) * 100).ToString("#.00");
                //Console.WriteLine(amountEarned[i]);
                //Console.WriteLine(percentages[i]);
                overallPercentage += Convert.ToInt32((amountEarned[i + 1] - amountEarned[i]) / amountEarned[i] * 100);
            }

            averagePercentage = overallPercentage / 12;

            exponential = exponential + (1 + (Convert.ToDouble(averagePercentage) / 100));

            projectedGrowth = amountEarned[11] * exponential;

            if (averagePercentage > 0)
            {
                Console.WriteLine("Your income are projected to grow by an average of {0}% to ${1}", averagePercentage.ToString("#.00"), projectedGrowth.ToString("#.00"));
            }
            else if (averagePercentage == 0)
            {
                Console.WriteLine("Your income will be the same as last year");
            }
            else
            {
                Console.WriteLine("Your incomre are projected to decay by an average of {0}% to ${1}", averagePercentage.ToString("#.00"), projectedGrowth.ToString("#.00"));
            }
        }
        static void Main(string[] args)
        {
            string[] percentages       = new string[12];
            double[] amountEarned      = new double[12];
            double overallPercentage   = 0;
            double averagePercentage   = 0;
            double projectedGrowth     = 0;
            double exponential         = 0;
            percentages[0]             = "0";
            Console.WriteLine("Growth Projector"); 
            Console.WriteLine("This program will use the average growth or decay of your income");
            Console.WriteLine("from the past year months to project your income for the next year");

            enterAmounts(amountEarned);

            Calculations(percentages, amountEarned, overallPercentage, averagePercentage, projectedGrowth, exponential);

            Console.WriteLine("January: {0}%",   percentages[0]);
            Console.WriteLine("February: {0}%",  percentages[1]);
            Console.WriteLine("March: {0}%",     percentages[2]);
            Console.WriteLine("April: {0}%",     percentages[3]);
            Console.WriteLine("May: {0}%",       percentages[4]);
            Console.WriteLine("June: {0}%",      percentages[5]);
            Console.WriteLine("July: {0}%",      percentages[6]);
            Console.WriteLine("August: {0}%",    percentages[7]);
            Console.WriteLine("September: {0}%", percentages[8]);
            Console.WriteLine("October: {0}%",   percentages[9]);
            Console.WriteLine("November: {0}%",  percentages[10]);
            Console.WriteLine("December: {0}%",  percentages[11]);
        }
    }
}
