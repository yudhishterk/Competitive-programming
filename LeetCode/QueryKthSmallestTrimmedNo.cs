/*
https://leetcode.com/problems/query-kth-smallest-trimmed-number/
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNet_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Driver.CallerMethod();
        }
    }

    internal static class Driver
    {
        internal static void CallerMethod()
        {
            var queryKthSmallestTrimmedNoObj = new QueryKthSmallestTrimmedNo();

            var param = GetParam();

            foreach (var p in param)
            {
                Print(p);
                Print(queryKthSmallestTrimmedNoObj.SmallestTrimmedNumbers(p.Nums, p.Queries));
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        static void Print(int[] nos)
        {
            Console.WriteLine(string.Concat("Result: ", string.Join(", ", nos)));
        }

        static void Print(SmallestTrimmedNumbersParams param)
        {
            Console.WriteLine(string.Concat("Nums: ", string.Join(", ", param.Nums)));
            var stringQ = param.Queries.Select(q => string.Concat("[", string.Join(", ", q), "]"));
            Console.WriteLine(string.Concat("Queries: ", string.Join(", ", stringQ)));
        }

        static List<SmallestTrimmedNumbersParams> GetParam()
        {
            return new List<SmallestTrimmedNumbersParams>()
            {
                new SmallestTrimmedNumbersParams()
                {
                    Nums = new string[]{ "102","473","251","814" },
                    Queries = new int[][]{
                        new[] {1,1},
                        new[] {2,3},
                        new[] {4,2},
                        new[] {1,2}
                        }
                },
                new SmallestTrimmedNumbersParams()
                {
                    Nums = new string[]{ "24","37","96","04" },
                    Queries = new int[][]{
                        new[] {2,1},
                        new[] {2,2}
                        }
                }
            };
        }
    }

    internal class QueryKthSmallestTrimmedNo
    {
        public List<KeyValuePair<string, short>> CountingSort(List<KeyValuePair<string, short>> nums, int place)
        {
            var count = new int[10];

            for (int i = 0; i < nums.Count; i++)
            {
                var trimmed = nums[i].Key.Substring(0, nums[i].Key.Length - place);
                var lastDigit = Convert.ToInt32(trimmed[trimmed.Length - 1].ToString());
                count[lastDigit] += 1;
            }

            for (int i = 1; i < count.Length; i++)
                count[i] += count[i - 1];

            var output = new List<KeyValuePair<string, short>>();
            for (int i = 0; i < nums.Count; i++)
            {
                output.Add(new KeyValuePair<string, short>());
            }

            for (int i = nums.Count - 1; i >= 0; i--)
            {
                var trimmed = nums[i].Key.Substring(0, nums[i].Key.Length - place);
                var lastDigit = Convert.ToInt32(trimmed[trimmed.Length - 1].ToString());

                output[count[lastDigit] - 1] = new KeyValuePair<string, short>(nums[i].Key, nums[i].Value);

                count[lastDigit]--;
            }

            return output;
        }

        public List<List<KeyValuePair<string, short>>> RadixSort(string[] nums)
        {
            if (nums.Length == 0)
                return null;

            var result = new List<List<KeyValuePair<string, short>>>();
            result.Add(
                nums.ToList().Select((Value, Index) => new KeyValuePair<string, short>(Value, Convert.ToInt16(Index))).ToList()
            );

            int order = -1;
            while (++order < nums[0].Length)
            {
                result.Add(
                    CountingSort(result[order], order)
                );
            }
            return result;
        }

        public int[] SmallestTrimmedNumbers(string[] nums, int[][] queries)
        {
            var sortedOnOrders = RadixSort(nums);
            if (sortedOnOrders == null)
                return new int[0];

            var result = new int[queries.Length];

            for (int i = 0; i < queries.Length; i++)
            {
                result[i] = sortedOnOrders[queries[i][1]][queries[i][0] - 1].Value;
            }

            return result;
        }
    }

    #region Models
    public class SmallestTrimmedNumbersParams
    {
        internal string[] Nums;
        internal int[][] Queries;
    }
    #endregion
}
