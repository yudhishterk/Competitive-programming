/*
* https://leetcode.com/problems/group-anagrams/
*/

public class Solution {

    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var dict = new Dictionary<string, IList<string>>();
        
        var counter = new AlphabetCounter();
        
        foreach(string str in strs){
            foreach(char s in str)
                counter.AddChar(s);
            
            if(!dict.ContainsKey(counter.StringKey))
                dict[counter.StringKey] = new List<string>();
            dict[counter.StringKey].Add(str);
            
            counter.Reset();
        }
        return dict.Values.ToList();
    }
}

public class AlphabetCounter{
    
    private static int _aAscii = Convert.ToInt32('a');
    private string _stringKey;
    
    public int[] Counter;
    
    public string StringKey{
        get{
            if(_stringKey == default(string))
                _stringKey = string.Join(".",Counter);
            return _stringKey;
        }
        set{
            _stringKey = value;
        }
    }
    
    public AlphabetCounter(){
        Counter = new int[26];
    }
    
    public void Reset(){
        StringKey = default(string);
        for(int i=0; i<Counter.Length; i++)
            Counter[i] = 0;
    }
    
    public void AddChar(char ch){
        Counter[Convert.ToInt32(ch)-_aAscii] += 1;
    }
}
