/**
 * Problem - https://leetcode.com/problems/set-matrix-zeroes/description/
 */

/**
 * @param {number[][]} matrix
 * @return {void} Do not return anything, modify matrix in-place instead.
 */
var setZeroes = function(matrix) {
    var row = matrix.length;
    var col = matrix[0].length;
    var isCol1Zero = false;

    /**
     * Idea is to first identify which row's & column's element should be changed
     * by marking the first element of the row & column if the current element is zero.
     */
    for(var i=0; i<row; i++) {
        //isCol1Zero signifies weather the first column needs change.
        if(matrix[i][0] === 0){
            isCol1Zero = true;
        }
        //Identify the rows & columns which need change by marking first elements.
        for(var j=1; j<col; j++){
            if(matrix[i][j] === 0) {
                matrix[0][j] = 0;
                matrix[i][0] = 0;
            }
        }
    }
    
    for(var i=row-1; i>=0; i--){
        //Change current element value to 0 if 1st column's or 1st row's value is 0.
        for(var j=col-1; j >= 1; j--){
            if(matrix[0][j] === 0 || matrix[i][0] === 0){
                matrix[i][j] = 0;
            }
        }
        //Set 1st columns value to 0 if isCol1Zero is true.
        if(j === 0 && isCol1Zero){
            matrix[i][0] = 0;
        }
    }
};
