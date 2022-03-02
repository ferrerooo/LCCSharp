// https://leetcode.com/problems/search-a-2d-matrix/submissions/

public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            return false;
        
        int rowCount = matrix.Length;
        int colCount = matrix[0].Length;
        
        int start = 0;
        int end = rowCount * colCount - 1;
        
        while (start <= end) {
            
            int mid = start + (end - start) / 2;
            (int x, int y) = GetPosition(colCount, mid);
            
            if (target == matrix[x][y]) {
                return true;
            } else if (target < matrix[x][y]) {
                end = mid - 1;
            } else {
                start = mid + 1;
            }            
        }
        
        return false;
    }
    
    private static (int, int) GetPosition (int col, int mid) {
        
        return (mid / col, mid % col); 
        
    }
}