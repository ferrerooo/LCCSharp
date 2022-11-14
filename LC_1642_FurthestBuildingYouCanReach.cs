using System.Collections.Generic;

public class Solution_LC1642 {
    public int FurthestBuilding(int[] heights, int bricks, int ladders) {
        
        int result = 0;
        PriorityQueue<int, int> qp = new PriorityQueue<int, int>();
        
        for (int i = 1 ; i < heights.Length; i++) {
            
            if (heights[i] <= heights[i-1]) {
                result = i;
                continue;
            }
            
            int gap = heights[i] - heights[i-1];
            
            if (ladders > 0) {
                ladders = ladders - 1;
                qp.Enqueue(gap, gap);
                result = i;
                continue;
            }
            
            if (qp.Count == 0 || qp.Peek() >= gap) {
                if (bricks >= gap) {
                    bricks = bricks - gap;
                    result = i;
                    continue;
                } else {
                    result = i - 1;
                    break;
                }
            } else {
                
                if (bricks >= qp.Peek()) {
                    bricks = bricks - qp.Peek();
                    qp.Dequeue();
                    qp.Enqueue(gap, gap);
                    result = i;
                    continue;
                } else {
                    result = i - 1;
                    break;
                }
                
            }
            
            
        }
        
        return result;
        
    }
}