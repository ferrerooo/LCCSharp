// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii/

using System;
public class Solution123 {
    public int MaxProfit(int[] prices) {
        
        int[] left = new int[prices.Length];
        int[] right = new int[prices.Length];
        
        // left to right
        left[0] = 0;
        int min = prices[0];
        for (int i = 1; i < prices.Length; i++) {
            if (prices[i] >= min) {
                left[i] = Math.Max(left[i-1], prices[i] - min);
            } else {
                min = prices[i];
                left[i] = left[i-1];
            }
        }
        
        // right to left
        right[prices.Length-1] = 0;
        int max = prices[prices.Length-1];
        for (int i = prices.Length - 2; i >= 0; i--) {
            
            if (prices[i] < max) {
                right[i] = Math.Max(right[i+1], max - prices[i]);
            } else {
                max = prices[i];
                right[i] = right[i+1];
            }
        }
        
        // scan left and right sum, find the max
        
        int maxProfit = 0;
        
        for (int i = 0; i < prices.Length; i++) {
            maxProfit = Math.Max(maxProfit, left[i] + right[i]);
        }
        
        return maxProfit;
    }
}

/* timeout solution  O(n^2)
public class Solution {
    public int MaxProfit(int[] prices) {
        
        int maxProfit = 0;
        
        for (int i = 0; i < prices.Length; i++) {
            
            int max1 = MaxProfit(prices, 0, i);
            int max2 = MaxProfit(prices, i, prices.Length - 1);
            
            maxProfit = Math.Max(maxProfit, max1 + max2);
        }
        
        return maxProfit;
    }
    
    private static int MaxProfit(int[] prices, int a , int b) {
        
        if (a >= b)
            return 0;
        
        int lowest = prices[a];
        int profit = 0;
        
        for (int i = a + 1; i <= b; i++) {
            
            if (prices[i] > lowest) {
                profit = Math.Max(profit, prices[i] - lowest);
            } else {
                lowest = prices[i];
            }
            
        }
        
        return profit;
    }
}

*/