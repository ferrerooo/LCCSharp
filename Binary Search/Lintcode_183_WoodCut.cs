// https://www.lintcode.com/problem/183/

using System;
using System.Collections;
using System.Collections.Generic;

namespace lintcode
{
    class Solution {
        /**
         * @param L: Given n pieces of wood with length L[i]
         * @param k: An integer
         * @return: The maximum length of the small pieces
         */
        public int woodCut(int[] L, int k) {
            // write your code here

            if (L.Length == 0) {
                return 0;
            }

            int longest = -1;
            foreach (var len in L) {
                longest = len > longest ? len : longest;
            }

            int start = 1;
            int end = longest;
            int result = 0;

            while (start <= end) {

                int mid = start + (end - start) / 2;
                int counter = 0;
                foreach (var len in L) {
                    counter = counter + len / mid;
                }
                
                if (counter >= k) {
                    result = mid > result ? mid : result;
                    start = mid + 1;
                } else {
                    end = mid - 1;
                }
            }

            return result;
        }
    }
}