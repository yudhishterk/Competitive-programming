/**
* https://leetcode.com/problems/combination-sum/
**/

public class Solution {
    private IList<IList<int>> _result = new List<IList<int>>();
    private int[] _candidates;
    private int _target;
    
    private void Recurse(int startIdx, List<int> cur, int sum){
        if(sum == _target){
            _result.Add(new List<int>(cur));
            return;
        }
        
        if(sum > _target) return;
        
        for(int i=startIdx; i<_candidates.Length; i++){
            cur.Add(_candidates[i]);
            Recurse(i, cur, sum+_candidates[i]);
            cur.RemoveAt(cur.Count - 1);
        }
    }
    
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        Array.Sort(candidates);
        _candidates = candidates;
        _target = target;
        
        Recurse(0, new List<int>(), 0);
        
        return _result;
    }
}
