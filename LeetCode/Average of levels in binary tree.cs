/**
 * Problem - https://leetcode.com/problems/average-of-levels-in-binary-tree/
 */

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    List<long[]> _ls;
    
    public Solution(){
        _ls = new List<long[]>();
    }
    
    public void AddLevel(int level){
        while(_ls.Count-1 < level){
            _ls.Add(new long[2]);
        }
    }
    
    public void Traverse(TreeNode node, int level){
        if(node is null) return;
        
        AddLevel(level);
        
        //Add node value to total level value
        _ls[level][0] += node.val;
        //increment node count for the level
        _ls[level][1]++;
        
        Traverse(node.left, level+1);
        Traverse(node.right, level+1);
    }
    
    public IList<double> AverageOfLevels(TreeNode root) {
        Traverse(root, 0);
        
        var result = new List<double>();
        
        foreach(var level in _ls){
            var avg = Math.Round((double)level[0]/level[1], 5);
            result.Add(avg);
        }
        
        return result;
    }
}
