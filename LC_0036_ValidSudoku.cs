using System.Collections.Generic;

public class Solution0036 {
    public bool IsValidSudoku(char[][] board) {
        
        for(int row=0;row<9;row++) {
            HashSet<char> hashset = new HashSet<char>();
            for (int col = 0; col<9;col++) {
                if (hashset.Contains(board[row][col]) && board[row][col] != '.')
                    return false;
                else
                    hashset.Add(board[row][col]);
            }
        }
        
        for(int col=0;col<9;col++) {
            HashSet<char> hashset = new HashSet<char>();
            for (int row = 0; row<9;row++) {
                if (hashset.Contains(board[row][col]) && board[row][col] != '.')
                    return false;
                else
                    hashset.Add(board[row][col]);
            }
        }
        
        for (int row = 0; row <9; row = row+3) {
            for (int col = 0; col < 9; col = col+3) {
                HashSet<char> hashset = new HashSet<char>();
                for (int i=0;i<3;i++) {
                    for (int j=0;j<3; j++) {
                        if (hashset.Contains(board[row+i][col+j]) && board[row+i][col+j] != '.')
                            return false;
                        else
                            hashset.Add(board[row+i][col+j]);
                    }
                }
                
            }
        }
        
        return true;
    }
}