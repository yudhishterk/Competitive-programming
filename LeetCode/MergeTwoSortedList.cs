/*
 * https://leetcode.com/problems/merge-two-sorted-lists/
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet_Console
{
    public static class MergeTwoSortedListDriver
    {
        public static void CallerMethod()
        {
            var obj = new Solution();
            var input = new List<Tuple<ListNode, ListNode>>()
            {
                new Tuple<ListNode, ListNode>(CreateListNode(0,1,2,3), CreateListNode(0,1,3,4)),
                new Tuple<ListNode, ListNode>(CreateListNode(0,-100,-50,0,40,41,89), 
                    CreateListNode(0,-100,-40,0,1,2,3,50,87,99,100,150,200))
            };

            foreach(var node in input)
            {
                Console.WriteLine(string.Join("List1: ", node.Item1.NodeToString()));
                Console.WriteLine(string.Join("List2: ", node.Item2.NodeToString()));
                var result = obj.MergeTwoLists(node.Item1, node.Item2);
                Console.WriteLine(string.Join("Result: ", result.NodeToString()));
            }
        }

        public static string NodeToString(this ListNode node)
        {
            StringBuilder stringBuilder = new StringBuilder();

            while(node != null)
            {
                stringBuilder.Append(node.val.ToString());
                if (node.next != null)
                    stringBuilder.Append(", ");
                node = node.next;
            }

            return stringBuilder.ToString();
        }

        private static ListNode CreateListNode(int index, params int[] values)
        {
            if (index >= values.Length) return null;

            var result = new ListNode(values[index]);
            result.next = CreateListNode(index + 1, values);

            return result;
        }
    }

    public class Solution
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null) return list2;
            if (list2 == null) return list1;

            if (list1.val < list2.val)
            {
                list1.next = MergeTwoLists(list1.next, list2);
                return list1;
            }
            else
            {
                list2.next = MergeTwoLists(list1, list2.next);
                return list2;
            }
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
