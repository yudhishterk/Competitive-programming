/**
 * https://leetcode.com/problems/design-hashmap/
 */

///
// Using Tree
///
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
 *
 * 2nd approach - Using Hash Index with Array
 * ********************************************************
public class MyHashMap {

    private Node[] _map;
    private int size;
    private int multi;
    
    public MyHashMap() {
        size = 19997;
        multi = 12582917;
        _map = new Node[size];
    }
    
    private int GetHash(int key){
        return Convert.ToInt32(Math.Abs(key*multi) % size);
    }
    
    public void Put(int key, int value) {
        var hash = GetHash(key);                

            if(_map[hash] == null){
                _map[hash] = new Node(key, value);
            }
            else{
                var node = _map[hash];
                while(node.key != key && node.next != null)
                    node = node.next;
                if(node.key == key)
                    node.val = value;
                else
                    node.next = new Node(key, value);
            }
    }
    
    public int Get(int key) {
        var hash = GetHash(key);
        
            var node = _map[hash];
            while(node != null && node.key != key)
                node = node.next;

            if(node is null) return -1;

            return node.val;
    }
    
    public void Remove(int key) {
        var hash = GetHash(key);
        
        var node = _map[hash];
        while(node != null && node.key != key)
            node = node.next;
        
        if(node is null) return;
        
        node.val = -1;
    }
}

public class Node{
    public int key;
    public int val;
    public Node next;
    
    public Node(int key, int val){
        this.key = key;
        this.val = val;
    }
}

 */

/**
 * Your MyHashMap object will be instantiated and called as such:
 * MyHashMap obj = new MyHashMap();
 * obj.Put(key,value);
 * int param_2 = obj.Get(key);
 * obj.Remove(key);
 */
