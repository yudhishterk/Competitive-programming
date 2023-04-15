/**
 * https://leetcode.com/problems/subarray-product-less-than-k/description
 */
 
function numSubarrayProductLessThanK(nums: number[], k: number): number {
    if (k <= 1) {
        return 0;
    }

    let prod = 1;
    let i = -1;
    let j = 0;
    let result = 0;

    while(i < nums.length){
        while(prod < k) {
            i++;
            result += i-j;
            prod *= nums[i];
        }

        while(prod >= k) {
            prod /= nums[j];
            j++;
        }
    }

    return result;
};
