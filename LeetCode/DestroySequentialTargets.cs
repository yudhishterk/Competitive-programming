/**
 * https://leetcode.com/contest/biweekly-contest-90/problems/destroy-sequential-targets/
 */

public class Solution {
    public int DestroyTargets(int[] nums, int space) {
        var minSeed = int.MaxValue;
        var maxTarget = 0;
        
        /**
         * All numbers having the same remainder (by space) can be destroyed by the smallest number from the subset (which will be the min seed).
         * Here key is the remainder & value is the subset of all numbers with same remainder.
         */
        var dict = new Dictionary<int, List<int>>();
        
        for(int i=0; i<nums.Length; i++){
            var rem = nums[i]%space;
            if(!dict.ContainsKey(rem))
                dict[rem] = new List<int>();
            dict[rem].Add(nums[i]);
        }
        
        //Find minimum seed with maximum targets.
        foreach(var pair in dict){
            if(pair.Value.Count > maxTarget){
                maxTarget = pair.Value.Count;
                minSeed = pair.Value.Min();
            }
            
            if(pair.Value.Count == maxTarget){
                minSeed = Math.Min(minSeed, pair.Value.Min());
            }
        }
        
        return minSeed;
    }
}
