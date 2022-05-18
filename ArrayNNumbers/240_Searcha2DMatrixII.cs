// https://leetcode.com/problems/search-a-2d-matrix-ii/

public class Solution240 {
    public bool SearchMatrix(int[][] matrix, int target) {
        
        int row = matrix.Length;
        int col = matrix[0].Length;
        
        int x = 0;
        int y = col - 1;
        
        while (x >= 0 && x < row && y >= 0 && y < col ) {
            
            if (matrix[x][y] == target)
                return true;
            else if (matrix[x][y] > target)
                y--;
            else
                x++;
            
        }
        
        return false;
    }
}