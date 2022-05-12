// https://www.lintcode.com/problem/1790/

using System;
using System.Collections;
using System.Collections.Generic;

namespace lintcode
{
    class Solution1790L {
        /**
         * @param str: An array of char
         * @param left: a left offset
         * @param right: a right offset
         * @return: return a rotate string
         */
        public string RotateString2(string str, int left, int right) {
            
            if (left == right)
                return str;

            char[] ch = new char[str.Length]; 
            for (int i = 0; i < str.Length; i++) { 
                ch[i] = str[i]; 
            }

            int splitIndex = 0;
            if (left > right)
                splitIndex = (left - right) % str.Length;
            else
                splitIndex = str.Length - (right - left) % str.Length;
            
            Reverse(ch, 0, splitIndex - 1);
            Reverse(ch, splitIndex, str.Length - 1);
            Reverse(ch, 0, str.Length - 1);

            return new String(ch);
        }

        private static void Reverse(char[] ch, int start, int end) {
            
            while(start < end) {
                char temp = ch[start];
                ch[start] = ch[end];
                ch[end] = temp;
                start++;
                end--;
            }

        }
    }
}