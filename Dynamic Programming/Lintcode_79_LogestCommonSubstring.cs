// https://www.lintcode.com/problem/79/

using System;
using System.Collections;
using System.Collections.Generic;

namespace lintcode
{
    class Solution79L {
        /**
         * @param a: A string
         * @param b: A string
         * @return: the length of the longest common substring.
         */
        public int LongestCommonSubstring(string a, string b) {
            // write your code here

            if (a == null || b == null)
                return 0;

            int lenA = a.Length;
            int lenB = b.Length;

            var dp = new int[lenA + 1, lenB + 1];

            for (int i = 0; i <= lenB; i++)
                dp[0, i] = 0;

            for (int j = 0; j <= lenA; j++)
                dp[j, 0] = 0;
            
            for (int i = 1; i <= lenA; i++) {
                for (int j = 1; j <= lenB; j++) {
                    if (a[i-1] == b[j-1]) {
                        dp[i, j] = 1 + dp[i-1, j-1];
                    } else {
                        dp[i, j] = 0;
                    }
                }
            }

            return GetMax(dp);
        }

        private static int GetMax(int[,] dp) {
            
            int max = 0;

            int row = dp.GetLength(0);
            int col = dp.GetLength(1);

            for (int i = 0; i < row; i++) {
                for (int j = 0; j < col; j++) {
                    max = Math.Max(max, dp[i, j]);
                }
            }
            
            return max;
        }
    }
}