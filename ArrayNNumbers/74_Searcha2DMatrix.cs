// https://leetcode.com/problems/search-a-2d-matrix/

public class Solution74 {
    public bool SearchMatrix(int[][] matrix, int target) {
        
        int row = matrix.Length;
        int col = matrix[0].Length;
        int start = 0;
        int end = row * col - 1;
        
        while (start <= end) {
            
            int mid = (start + end) / 2;
            
            if (matrix[mid/col][mid%col] == target)
                return true;
            else if (matrix[mid/col][mid%col] > target)
                end = mid - 1;
            else
                start = mid + 1;
        }
        
        return false;
    }
}