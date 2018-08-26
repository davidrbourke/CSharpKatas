using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKatas
{
    public class PileOfCubes
    {
        public static double GetSum(long levels)
        {
            double currentLevel = levels;
            double total = 0;
            while(currentLevel != 0)
            {
                total += Math.Pow(currentLevel, 3);
                currentLevel -= 1;
            }

            return total;
        }

        public static long GetLevels(long area)
        {
            long currentLevel = 1;
            long total = 0;
            while (total < area)
            {
                total += currentLevel * currentLevel * currentLevel;
                currentLevel += 1;
            }

            if (total > area)
                return -1;

            return currentLevel - 1;
        }

        public static long Alt(long m)
        {
            long total = 1, i = 2;
            for (; total < m; i++) total += i * i * i;
            return total == m ? i - 1 : -1;
        }
    }
}
