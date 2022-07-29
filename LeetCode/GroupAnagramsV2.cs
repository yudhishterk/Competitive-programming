/*
* https://leetcode.com/problems/group-anagrams/
*/

public class Solution {

    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var dict = new Dictionary<string, IList<string>>();
        
        foreach(string str in strs){
            var ch = str.ToArray();
            Array.Sort(ch);
            var key = new string(ch);
            
            if(!dict.ContainsKey(key))
                dict[key] = new List<string>();
            dict[key].Add(str);
        }
        return dict.Values.ToList();
    }
}
