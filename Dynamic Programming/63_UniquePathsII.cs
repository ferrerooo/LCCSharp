// https://leetcode.com/problems/unique-paths-ii/

public class Solution63 {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        
        int m = obstacleGrid.Length;
        int n = obstacleGrid[0].Length;
        
        int[,] path = new int[m,n];
        
        for (int i=0; i<m; i++) {
            if (obstacleGrid[i][0] == 1)
                path[i,0] = 0;
            else if (i == 0)
                path[i,0] = 1;
            else
                path[i, 0] = path[i-1,0];
                
        }
        
        for (int i=0; i<n; i++) {
            if (obstacleGrid[0][i] == 1)
                path[0, i] = 0;
            else if (i == 0)
                path[0, i] = 1;
            else
                path[0, i] = path[0, i-1];
        }
        
        for (int i=1; i<m; i++) {
            for (int j=1; j<n; j++) {
                if (obstacleGrid[i][j] == 1)
                    path[i, j] = 0;
                else
                    path[i, j] = path[i-1,j] + path[i, j-1];
            }
        }
        
        return path[m-1, n-1];
        
    }
}