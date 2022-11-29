using System.Collections.Generic;

public class HitCounter {
    
    private IList<int> list;

    public HitCounter() {
        list = new List<int>();
    }
    
    public void Hit(int timestamp) {
        list.Add(timestamp);
    }
    
    public int GetHits(int timestamp) {
        
        int count = 0;
        
        for (int i = list.Count-1; i>=0; i--) {
            if (list[i] > (timestamp - 300))
                count ++;
        }
        
        return count;
    }
}

/**
 * Your HitCounter object will be instantiated and called as such:
 * HitCounter obj = new HitCounter();
 * obj.Hit(timestamp);
 * int param_2 = obj.GetHits(timestamp);
 */