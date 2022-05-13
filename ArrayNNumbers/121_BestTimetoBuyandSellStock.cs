// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/

using System;
public class Solution121 {
    public int MaxProfit(int[] prices) {
        
        int lowest = prices[0];
        int profit = 0;
        
        for (int i = 1; i< prices.Length; i++) {
            
            if (prices[i] > lowest) {
                
                profit = Math.Max(profit, prices[i] - lowest);
                
            } else {
                
                lowest = Math.Min(lowest, prices[i]);
                
            }
            
        }
        
        return profit;
    }
}

