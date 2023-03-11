/**
 * Problem - https://leetcode.com/problems/word-search
 */


/**
 * @param {character[][]} board
 * @param {string} word
 * @return {boolean}
 */
var exist = function(board, word) {
    var visited = Array(board.length).fill().map(() => Array(board[0].length).fill(false));

    for(var i=0; i<board.length; i++){
        for(var j=0; j<board[0].length; j++){
            if(recurse(board, i, j, word, 0, visited)){
                return true;
            }
        }
    }
    return false;
};

var recurse = function(matrix, i, j, word, idx, visited) {
    if(idx >= word.length){
        return true;
    }

    if(i < 0 || j < 0 || i >= matrix.length || j >= matrix[0].length){
        return false;
    }

    if(visited[i][j] || matrix[i][j] !== word[idx]){
        return false;
    }

    visited[i][j] = true;

    //Recurse in all directions.
    if(recurse(matrix, i, j+1, word, idx+1, visited)){
        return true;
    }
    if(recurse(matrix, i+1, j, word, idx+1, visited)){
        return true;
    }
    if(recurse(matrix, i, j-1, word, idx+1, visited)){
        return true;
    }
    if(recurse(matrix, i-1, j, word, idx+1, visited)){
        return true;
    }

    visited[i][j] = false;

    return false;
}
