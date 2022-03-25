// https://leetcode.com/problems/minimum-path-sum/

using System;

public class Solution64 {
    public int MinPathSum(int[][] grid) {
        
        int row = grid.Length;
        int column = grid[0].Length;

        int[][] dp = new int[row][];
        
        for (int i = 0; i < row; i++) {
            dp[i] = new int[column];
        }

        dp[0][0] = grid[0][0];
        
        for (int i = 1; i < column; i++) {
            dp[0][i] = dp[0][i-1] + grid[0][i];
        }

        for (int i = 1; i < row; i++) {
            dp[i][0] = dp[i-1][0] + grid[i][0];
        }

        for (int i = 1; i < row; i++) {
            for (int j = 1; j < column; j++) {
                int current = grid[i][j];
                dp[i][j] = Math.Min(dp[i - 1][j] + current, dp[i][j - 1] + current); 
            }
        }

        return dp[row - 1][column - 1];        
    }
}