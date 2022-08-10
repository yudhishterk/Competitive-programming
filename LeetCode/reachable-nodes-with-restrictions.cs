/*
** https://leetcode.com/problems/reachable-nodes-with-restrictions/
*/

public class Solution {
    public int ReachableNodes(int n, int[][] edges, int[] restricted) {
        var tree = new Tree(n, edges, restricted.ToHashSet());
        return tree.CountVisit(0);
    }
}

public class Tree{
    private int _nodes;
    private List<List<int>> _adjList;
    private bool[] _visited;
    private HashSet<int> _restrictedNodes;
    
    public Tree(int n, int[][] edges, HashSet<int> restrictedNodes){
        _nodes = n;
        _restrictedNodes = restrictedNodes;
        _visited = new bool[_nodes];
        CreateAdjList(edges);
    }
    
    public int CountVisit(int node){
        if(_visited[node] || _restrictedNodes.Contains(node))
            return 0;
        _visited[node] = true;
        var count = 1;
        foreach(var child in _adjList[node])
            count += CountVisit(child);
        return count;
    }
    
    private void CreateAdjList(int[][] edges){
        _adjList = new List<List<int>>();
        for(int _=0; _<_nodes; _++)
            _adjList.Add(new List<int>());
        
        foreach(var edge in edges){
            _adjList[edge[0]].Add(edge[1]);
            _adjList[edge[1]].Add(edge[0]);
        }
    }
}
