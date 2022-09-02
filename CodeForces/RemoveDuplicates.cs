/*
** Problem - https://codeforces.com/problemset/problem/978/A
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class Program{
	
	public static List<int> GetFirstRightOccurrence(int[] nums) {
        	var marked = new HashSet<int>();
		var result = new List<int>();
		
		for(int i=nums.Length-1; i>=0; i--){
			if(marked.Contains(nums[i])) continue;
			marked.Add(nums[i]);
			result.Add(nums[i]);
		}
		result.Reverse();
		return result.ToList();
    }
	
	public static void Main(string[] args){
		int n = Convert.ToInt32(Console.ReadLine());
		var nums = Array.ConvertAll(Console.ReadLine().Split().ToArray(), int.Parse);
		
		var result = GetFirstRightOccurrence(nums);
		
		Console.WriteLine(result.Count);
		Console.WriteLine(string.Join(" ", result));
	}
}
