/**
 * https://leetcode.com/contest/weekly-contest-338/problems/minimum-operations-to-make-all-array-elements-equal/
 */


function minOperations(nums: number[], queries: number[]): number[] {
    nums.sort((x, y) => x-y);
    
    let n = nums.length;
    let sums = getSumArr(nums);
    
    let result = [];
    
    for(let query of queries) {
        let index = findIndex(query, nums);
        
        let bkwdTotal = index === 0 ? 0 : sums[index-1]
        let fwdTotal = sums[n-1] - bkwdTotal;
        
        let total = fwdTotal - (n-index)*query + index*query - bkwdTotal;
        
        result.push(total);
    }
    
    return result;
};

function getSumArr(nums: number[]): number[] {
    let sums = [];
    let sm = 0;
    for(let num of nums) {
        sm += num;
        sums.push(sm);
    }
    
    return sums;
}

function findIndex(query: number, nums: number[]) {
    let lo = 0;
    let hi = nums.length - 1;
    
    while(lo <= hi) {
        let mid = lo + Math.floor((hi - lo)/2);
        if(nums[mid] < query) {
            lo = mid + 1;
        }
        else{
            hi = mid - 1;
        }
    }
    
    return lo;
}
