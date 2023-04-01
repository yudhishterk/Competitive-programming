/**
 * https://leetcode.com/problems/prime-subtraction-operation/description/
 */
 
function primeSubOperation(nums: number[]): boolean {
    for(let i=nums.length-2; i>=0; i--) {
        var reduceBy = nums[i] - nums[i+1] + 1;
        
        if(reduceBy <= 0){
            continue;
        }
        
        nums[i] -= getNextPrime(reduceBy);
        
        if(nums[i] < 1) {
            return false;
        }
    }
    
    return true;
};

function getNextPrime(n: number) {
    for(let i=n; i <= 2*n; i++){
        if(isPrime(i)){
            return i;
        }
    }
    
    return 0;
}

function isPrime(n: number){
    if(n <= 1){
        return false;
    }
    if(n <= 3){
        return true;
    }
    
    if(n%2 === 0 || n%3 === 0){
        return false;
    }
    
    let i = 5;
    
    while(i*i <= n){
        if(n % i === 0 || n %(i+2) === 0){
            return false;
        }
        i+=6;
    }
    
    return true;
}
