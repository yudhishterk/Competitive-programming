//*
* https://leetcode.com/problems/design-hashmap/
*//

public class MyHashMap {

    public TreeNode root;
    
    public MyHashMap() {
        root = new TreeNode(0, -1);
    }
    
    public void Put(int key, int val) {
        var node = FindNode(root, key);
        
        if(node.key == key){
            node.val = val;
        }
        else{
            if(node.key < key)
                node.right = new TreeNode(key, val);
            else
                node.left = new TreeNode(key, val);
        }
    }
    
    public int Get(int key) {
        var node = FindNode(root, key);
        
        if(node is null || node.key != key)
            return -1;
        
        return node.val;
    }
    
    public void Remove(int key) {
        var node = FindNode(root, key);
        
        if(node is null || node.key != key)
            return;
        
        node.val = -1;
    }
    
    private TreeNode FindNode(TreeNode node, int key){
        if(node is null || node.key == key)
            return node;
        
        if(node.key < key)
            return FindNode(node.right, key) ?? node;
        return FindNode(node.left, key) ?? node;
            
    }
}

public class TreeNode{
    public int key;
    public int val;
    public TreeNode left;
    public TreeNode right;
    
    public TreeNode(int key, int val){
        this.key = key;
        this.val = val;
        this.left = null;
        this.right = null;
    }
}

/**
 * Your MyHashMap object will be instantiated and called as such:
 * MyHashMap obj = new MyHashMap();
 * obj.Put(key,value);
 * int param_2 = obj.Get(key);
 * obj.Remove(key);
 */
