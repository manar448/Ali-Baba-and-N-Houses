using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    // *****************************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *****************************************
    public static class AliBabaAndNHouses
    {
        #region YOUR CODE IS HERE

        #region FUNCTION#1: Calculate the Value
        //Your Code is Here:
        //==================
        /// <summary>
        /// find the maximum amount of money that Ali baba can get, given the number of houses (N) and a list of the net gained value for each consecutive house (V)
        /// </summary>
        /// <param name="values">Array of the values of each given house (ordered by their consecutive placement in the city)</param>
        /// <param name="N">The number of the houses</param>
        /// <returns>the maximum amount of money the Ali Baba can get </returns>
        static public int SolveValue(int[] values, int N)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
            int[] Dynamic_P = new int[N];          
            Dynamic_P = fill_DP(values, N, true);
            if (N == 1)
            {
                return Dynamic_P[0];
            }
            else if (N > 1)
            {
                
                return Dynamic_P[N - 1];
            }
            else
            {
                return (Dynamic_P[N-1] = 0);
            }
        }
        static public int[] fill_DP(int[] values, int N, bool fun)
        {
            int[] Dynamic_P = new int[N];
            
            int index = 0;
            if(fun == true)
            {
                Dynamic_P[0] = values[0];
                for (int i = 1; i < N; i++)
                {
                    index = 0;
                    if ((i - 2) >= 0)
                    {
                        index = Dynamic_P[i - 2];
                    }
                    Dynamic_P[i] = Math.Max(Dynamic_P[i - 1], index + values[i]);

                }
            }
            else if (fun == false)
            {
                for (int j = 1; j < N; j++)
                {
                    index = 0;
                    if ((j - 2) >= 0)
                    {
                        index = Dynamic_P[j - 2];
                    }
                    Dynamic_P[j] = Math.Max(Dynamic_P[j - 1], index + values[j - 1]);
                }
            }

            return Dynamic_P;
        }
        #endregion

        #region FUNCTION#2: Construct the Solution
        //Your Code is Here:
        //==================
        /// <returns>Array of the indices of the robbed houses (1-based and ordered from left to right) </returns>
        static public int[] ConstructSolution(int[] values, int N)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
            int[] Dynamic_P = new int[N + 1];
            List<int> flags = new List<int>(); 
            Dynamic_P = fill_DP(values, N, false);
            int index = 0;
            for (int i = N; i > 0;)
            {
                index = i - 2;
                if (index < 0)
                {
                    index = 0;
                }
                if (Dynamic_P[i - 1] >= Dynamic_P[index] + values[i - 1])
                {
                    i -= 1;
                }
                else
                {
                    flags.Add(i);
                    i -= 2;
                }
            }
            flags.Reverse();
            return flags.ToArray();
        }
        #endregion

        #endregion
    }
}
