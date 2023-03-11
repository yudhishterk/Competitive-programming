/**
 * Problem - https://leetcode.com/problems/decode-ways/description/
 */

/**
 * @param {string} s
 * @return {number}
 */
var numDecodings = function(s) {
    var codes = new Set();
    for(var i=1; i<=26; i++){
        codes.add(i.toString());
    }

    var len = s.length;
    ways = Array(len).fill(0);

    if(codes.has(s[len-1])){
        ways[len-1] += 1;
    }
    if(codes.has(s[len-2])){
        ways[len-2] += ways[len-1];
    }
    if(codes.has(s.substring(len-2, len))){
        ways[len-2] += 1;
    }


    for(var i=len-3; i>=0; i--){
        if(codes.has(s[i])){
            ways[i] += ways[i+1];
        }
        if(codes.has(s.substring(i, i+2))){
            ways[i] += ways[i+2];
        }
    }

    return ways[0];
};
