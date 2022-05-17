// https://www.lintcode.com/problem/139/description

/* java solution

public class Solution {

    public int[] subarraySumClosest(int[] nums) {
        // write your code here

        Prefix[] list = new Prefix[nums.length];
        int[] result = new int[2];

        list[0] = new Prefix(nums[0], 0);
        for (int i = 1; i < nums.length; i++) {
            list[i] = new Prefix(list[i-1].sum + nums[i] ,i);
        }

        Arrays.sort(list, ((a, b) -> a.sum - b.sum));

        int min = Integer.MAX_VALUE;
        for (int i = 0;i<list.length-1; i++) {
            if (Math.abs(list[i].sum - list[i+1].sum) < min) {
                min = Math.abs(list[i].sum - list[i+1].sum);
                result[0] = Math.min(list[i].index, list[i+1].index)+1;
                result[1] = Math.max(list[i].index, list[i+1].index);
            }
        }

        for (int i = 0; i<list.length; i++) {
            if (Math.abs(list[i].sum) < min) {
                min = Math.abs(list[i].sum);
                result[0] = 0;
                result[1] = list[i].index;
            }
        }

        return result;
    }
}

class Prefix
{
    public int sum, index;
    
    public Prefix(int s, int i) {
        sum = s;
        index = i;
    }
}

*/