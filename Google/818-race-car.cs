using System;

public class Solution818 {
    
    /* Greedy algorithm. But it does not work for some cases, e.g. target=5
    
    public int Racecar(int target) {
        
        return getSteps(target);
    }
    
    private int getSteps(int target) {
        
        if (target == 0)
            return 0;
        if (target == 1)
            return 1;
        if (target == 2)
            return 4;
        
        int step = 0;
        int curr = 0;
        int currNext = 1;
        int targetNext = 0;
        
        while (true) {
            
            if (curr == target)
                return step;
            
            if (currNext <= target) {
                step ++;
                curr = currNext;
                currNext = curr + (int)Math.Pow(2, step);
                continue;
            }
            
            targetNext = target - curr <= currNext - target ? target - curr : currNext - target;
            break;
        }
        
        int opt1 = step + 2 + getSteps(targetNext);
        int opt2 = step + 3 + getSteps(targetNext + 1);
        
        return Math.Min(opt1, opt2);
        //return opt2;
    }
    */
}