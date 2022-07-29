/*
* https://leetcode.com/problems/jump-game-ii/
*/

public class Solution {
    public int Jump(int[] nums) {
        
        int idx = 0;
        int count = 0;
        while(nums.Length > 1){
            count++;
            
            if(idx+nums[idx] >= nums.Length-1) break;
            
            int j = 1;
            int mx = nums[idx+nums[idx]];
            int mxId = idx+nums[idx];
            for(int i = idx+nums[idx]-1; i>=idx+1; i--){
                if(mx < nums[i]-j){
                    mx = nums[i]-j;
                    mxId = i;
                }
                j++;
            }
            idx = mxId;
        }
        return count;
    }
}
