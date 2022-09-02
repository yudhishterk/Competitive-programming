/*
** Problem link - https://leetcode.com/problems/find-all-duplicates-in-an-array/
*/

public class Solution {
    public IList<int> FindDuplicates(int[] nums) {
        //Counter dict to count the number of times a integer appears in nums array.
        var counter = new Dictionary<int, int>();
        
        //Count in O(n)
        foreach(var num in nums){
            //create key if not present
            if(!counter.ContainsKey(num))
                counter[num] = 0;
            //Increment num count
            counter[num]++;
        }
        
        //Store intergers which appear more than 1 in nums.
        var result = new List<int>();
        
        foreach(var pair in counter)
            if(pair.Value > 1)
                result.Add(pair.Key);
        
        return result;
    }
}
