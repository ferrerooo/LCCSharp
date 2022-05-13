// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/

public class Solution122 {
    public int MaxProfit(int[] prices) {
        
        int profit = 0;
        int low = prices[0];
        
        for (int i = 1; i < prices.Length; i++) {
            
            if (prices[i] > low) 
                profit = profit + (prices[i] - low);
            low = prices[i];
        }
        
        return profit;
    }
}