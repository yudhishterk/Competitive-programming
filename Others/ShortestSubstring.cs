namespace ConsoleAppDotNet6.NewFolder
{
    internal class ShortestSubstring
    {
        private static int _noOfChar = 256;

        private static List<Tuple<string, string>> _testData = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("abcb", "ab"),
            new Tuple<string, string>("My Name is Fran", "rim"),
            new Tuple<string, string>("The world is yours", "rs"),
            new Tuple<string, string>("To be or not to be", "oo"),
            new Tuple<string, string>("to be or not to be", "tb"),
        };

        public static void Caller()
        {
            foreach(var test in _testData)
            {
                Console.WriteLine($"String - '{test.Item1}' should contain - {test.Item2}");
                Console.WriteLine($"Shortest substring - '{FindSubstring(test.Item1, test.Item2)}'\n");
            }
        }

        private static string FindSubstring(string s, string t)
        {
            var sCount = new int[_noOfChar];
            var tCount = new int[_noOfChar];

            for (int i = 0; i < t.Length; i++)
            {
                tCount[t[i]]++;
            }

            var count = 0;
            var start = 0;
            var startIndex = 1;
            var minLen = int.MaxValue;

            for (int i = 0; i < s.Length; i++)
            {
                sCount[s[i]]++;

                if (tCount[s[i]] != 0 && sCount[s[i]] <= tCount[s[i]])
                    count++;

                if (count == t.Length)
                {
                    while (sCount[s[start]] > tCount[s[start]] || tCount[s[start]] == 0)
                    {
                        if (sCount[s[start]] > tCount[s[start]])
                            sCount[s[start]]--;

                        start++;
                    }

                    var lenWindow = i - start + 1;

                    if (minLen > lenWindow)
                    {
                        minLen = lenWindow;
                        startIndex = start;
                    }
                }
            }

            return s.Substring(startIndex, minLen);
        }
    }
}
