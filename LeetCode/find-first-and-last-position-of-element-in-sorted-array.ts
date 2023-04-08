
/**
 * https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/description
 */
 
function searchRange(nums: number[], target: number): number[] {
    let lo = 0;
    let hi = nums.length -1;

    let result: number[] = [];

    while(lo <= hi) {
        let mid = lo + Math.floor((hi - lo)/2);

        if(nums[mid] < target) {
            lo = mid + 1;
        }
        else{
            hi = mid - 1;
        }
    }
    result.push(lo);

    lo = 0;
    hi = nums.length -1;

    while(lo <= hi) {
        let mid = lo + Math.floor((hi - lo)/2);

        if(nums[mid] > target) {
            hi = mid - 1;
        }
        else{
            lo = mid + 1;
        }
    }
    result.push(hi);

    return nums[result[0]] !== target || nums[result[1]] !== target ? [-1, -1] : result;
};
