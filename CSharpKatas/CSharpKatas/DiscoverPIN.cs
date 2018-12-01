using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CSharpKatas
{
    public class DiscoverPIN
    {
        /// <summary>
        /// My solution
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public string GetPIN(string[] keys)
        {
            var answer = new List<string>();

            foreach (var keySet in keys)
            {
                for (int i = 0; i < keySet.Length; i++)
                {
                    if (answer.IndexOf(keySet[i].ToString()) == -1)
                    {
                        answer.Add(keySet[i].ToString());
                    }
                }

                for (int j = 0; j < 3; j++)
                {
                    var iOfA = answer.IndexOf(keySet[0].ToString());
                    var iOfB = answer.IndexOf(keySet[1].ToString());
                    var iOfC = answer.IndexOf(keySet[2].ToString());

                    if (iOfA > iOfB)
                    {
                        Insert(answer, iOfA, iOfB);
                    }
                    if (iOfB > iOfC)
                    {
                        Insert(answer, iOfB, iOfC);
                    }
                    if (iOfA > iOfC)
                    {
                        Insert(answer, iOfA, iOfC);
                    }
                }

            }

            return string.Join("", answer);
        }

        void Insert(IList<string> answer, int lower, int upper)
        {
            string val = answer[upper];
            answer.RemoveAt(upper);
            answer.Insert(lower, val);
        }

        /// <summary>
        /// Gareth's brute force solution
        /// </summary>
        /// <param name="keyLog"></param>
        /// <returns></returns>
        public string BruteForce(string[] keyLog)
        {
            var found = false;
            var index = 10000000; // I chose this as a starting point because I can see the count of unique numbers
            var answer = "";
            while (!found)
            {
                answer = (index++).ToString();

                // The Linq All method takes advantage of short-circuit evaluation.
                // As soon as any number is matched the while will progress
                found = keyLog.All(x =>
                answer.IndexOf(x[0]) != -1 &&
                answer.IndexOf(x[1]) != -1 &&
                answer.IndexOf(x[2]) != -1 &&

                answer.IndexOf(x[0]) < answer.IndexOf(x[1]) &&
                answer.IndexOf(x[1]) < answer.IndexOf(x[2])
                );
            }

            return answer;
        }
    }
}

/*


    
 */
