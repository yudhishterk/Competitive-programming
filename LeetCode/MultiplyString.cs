/*
* https://leetcode.com/problems/multiply-strings/
*/

public class Solution {
    public string Multiply(string num1, string num2) {
        if(num1.Length > num2.Length){
            string temp = num1;
            num1 = num2;
            num2 = temp;
        }
        
        var dict = new Dictionary<char, string>();
        dict['0'] = "0";
        
        var keys = num2.ToArray().Distinct();
        foreach(char key in keys)
            dict[key] = num1.Multiply(key);
        
        var stringLs = new List<string>();
        for(int i=num2.Length-1; i>=0; i--){
            if(dict[num2[i]]=="0") continue;
            stringLs.Add(dict[num2[i]].AppendRight('0',num2.Length-1-i));
        }
        
        if(stringLs.Count == 0)
            return "0";
        
        int mxLen = stringLs.Max(x => x.Length);
        for(int i=0; i<stringLs.Count; i++){
            stringLs[i] = stringLs[i].PadLeft('0', mxLen);
        }
        
        return stringLs.Sum();
    }
}

public static class Extension{
    public static string Multiply(this string num1, char charNum2){
        var sb = new StringBuilder();
        int carry = 0;
        int num2 = Convert.ToInt32(charNum2.ToString());
        
        for(int i=num1.Length-1; i>=0; i--){
            var temp = Convert.ToInt32(num1[i].ToString())*num2;
            if(i == 0){
                sb.Insert(0,temp+carry);
            }
            else{            
                sb.Insert(0,(temp+carry)%10);
                carry = (temp+carry)/10;
            }
        }
        return sb.ToString();
    }
    
    public static string PadLeft(this string num1, char ch, int len){
        var i = len-num1.Length;
        if(i<=0)
            return num1;
        
        return new string(ch,i) + num1;
    }
    
    public static string AppendRight(this string num1, char ch, int len){
        return num1 + new string(ch,len);
    }
    
    public static string Sum(this List<string> strLst){
        if(strLst.Count == 0)
            return "";
        if(strLst.Count == 1)
            return strLst[0];
        
        var sb = new StringBuilder();
        
        int carry = 0;
        for(int i=strLst[0].Length-1;i>=0;i--){
            var sm = 0;
            for(int j=0; j<strLst.Count;j++){
                sm += Convert.ToInt32(strLst[j][i].ToString());
            }
            if(i==0){
                sb.Insert(0,sm+carry);
            }
            else{
                sb.Insert(0, (sm+carry)%10);
                carry = (sm+carry)/10;
            }
        }
        return sb.ToString();
    }
}
