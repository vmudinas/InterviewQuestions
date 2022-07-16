using System;
using System.Linq;
using System.Text;

namespace InterviewQuestions
{
    public class WaiFairLongestCommonSubsequence
    {
        #region An array of weights and a target weight
        public bool IsTarget(int[] numbers, int target)
        {
            //var result = from item in numbers.Select((n1, idx) =>
            //     new { n1, shortList = numbers.Take(idx) })
            //             from n2 in item.shortList
            //             where item.n1 + n2 == target
            //             select new { n1 = item.n1, n2 };

            //return result.Any();
            var result = from num in numbers
                         where numbers.Contains(target - num)
                         select num;
            if (result.Count() > 0)
                return true;

            return false;
        }
        bool sortTest(int[] numbers, int target)
        {
            Array.Sort(numbers);
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = numbers.Length - 1; j > i; j--)
                {
                    if (numbers[i] + numbers[j] == target)
                        return true;
                }
            }
            return false;
        }
        #endregion
        #region Longest Common Substring
        public int LongestCommonSubsequence(string text1, string text2)
        {
            var n1 = text1.Length;
            var n2 = text2.Length;

            var dp = new int[n1, n2];

            var global = 0;

            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < n2; j++)
                {
                    if (text1[i] == text2[j])
                    {
                        if (i > 0 && j > 0)
                        {
                            dp[i, j] = dp[i - 1, j - 1] + 1;
                        }
                        else
                        {
                            dp[i, j] = 1;
                        }
                    }
                    else
                    {
                        dp[i, j] = Math.Max(i > 0 ? dp[i - 1, j] : 0, j > 0 ? dp[i, j - 1] : 0);
                    }

                    global = Math.Max(global, dp[i, j]);
                }
            }

            return global;
        }

        //Time Complexity: O(m*n) 
        //Auxiliary Space: O(n)
        public string LongestCommonSubsequenceString(string X, string Y)
        {
            // Find length of both the Strings.
            int m = X.Length;
            int n = Y.Length;

            // Variable to store length of longest
            // common subString.
            int result = 0;

            // Variable to store ending point of
            // longest common subString in X.
            int end = 0;

            // Matrix to store result of two
            // consecutive rows at a time.
            int[,] len = new int[2, m];

            // Variable to represent which row of
            // matrix is current row.
            int currRow = 0;

            // For a particular value of i and j,
            // len[currRow][j] stores length of longest
            // common subString in String X[0..i] and Y[0..j].
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        len[currRow, j] = 0;
                    }
                    else if (X[i - 1] == Y[j - 1])
                    {
                        len[currRow, j] = len[1 - currRow, j - 1] + 1;
                        if (len[currRow, j] > result)
                        {
                            result = len[currRow, j];
                            end = i - 1;
                        }
                    }
                    else
                    {
                        len[currRow, j] = 0;
                    }
                }

                // Make current row as previous row and
                // previous row as new current row.
                currRow = 1 - currRow;
            }

            // If there is no common subString, print -1.
            if (result == 0)
            {
                return "-1";
            }

            // Longest common subString is from index
            // end - result + 1 to index end in X.
            return X.Substring(end - result + 1, result);
        }
        #endregion
        #region Multiply Numbers from strings
        public string Multiply(string num1, string num2)
        {
            int m = num1.Length;
            int n = num2.Length;

            int[] ans = new int[m + n];

            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                  // var test1 = (num1[i] - '0');
                  //  var test2 = (num2[j] - '0');
                    int multiply = (num1[i] - '0') * (num2[j] - '0');
                    int sum = multiply + ans[i + j + 1];
                    var a = multiply;
                    var b = sum % 10;
                    var c = sum / 10;
                    var d = ans[i + j] + sum / 10;
                    ans[i + j + 1] = sum % 10;
                    ans[i + j] += sum / 10;
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (var p in ans)
            {
                if (!(p == 0 && sb.Length == 0))
                {
                    sb.Append(p);
                }
            }

            return (sb.Length == 0) ? "0" : sb.ToString();

        }
        #endregion
    }
}
/*
 * /*

You're developing a system for scheduling advising meetings with students in a Computer Science program. Each meeting should be scheduled when a student has completed 50% of their academic program.

Each course at our university has at most one prerequisite that must be taken first. No two courses share a prerequisite. There is only one path through the program.

Write a function that takes a list of (prerequisite, course) pairs, and returns the name of the course that the student will be taking when they are halfway through their program. (If a track has an even number of courses, and therefore has two "middle" courses, you should return the first one.)

Sample input 1: (arbitrarily ordered)
prereqs_courses1 = [
	["Foundations of Computer Science", "Operating Systems"],
	["Data Structures", "Algorithms"],
	["Computer Networks", "Computer Architecture"],
	["Algorithms", "Foundations of Computer Science"],
	["Computer Architecture", "Data Structures"],
	["Software Design", "Computer Networks"]
]

In this case, the order of the courses in the program is:
	Software Design
	Computer Networks
	Computer Architecture
	Data Structures
	Algorithms
	Foundations of Computer Science
	Operating Systems

Sample output 1:
	"Data Structures"

Sample input 2:
prereqs_courses2 = [
    ["Algorithms", "Foundations of Computer Science"],
    ["Data Structures", "Algorithms"],
    ["Foundations of Computer Science", "Logic"],
    ["Logic", "Compilers"],
    ["Compilers", "Distributed Systems"],
]

Sample output 2:
	"Foundations of Computer Science"

Sample input 3:
prereqs_courses3 = [
	["Data Structures", "Algorithms"],
]

Sample output 3:
	"Data Structures"

Complexity analysis variables:

n: number of pairs in the input



using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    static void Main(String[] args)
    {
        string[][] prereqsCourses1 = new[] {
            new [] {"Foundations of Computer Science", "Operating Systems"},
            new [] {"Data Structures", "Algorithms"},
            new [] {"Computer Networks", "Computer Architecture"},
            new [] {"Algorithms", "Foundations of Computer Science"},
            new [] {"Computer Architecture", "Data Structures"},
            new [] {"Software Design", "Computer Networks"}
        };

        string[][] prereqsCourses2 = new[] {
            new [] {"Algorithms", "Foundations of Computer Science"},
            new [] {"Data Structures", "Algorithms"},
            new [] {"Foundations of Computer Science", "Logic"},
            new [] {"Logic", "Compilers"},
            new [] {"Compilers", "Distributed Systems"},
        };

        string[][] prereqsCourses3 = new[] {
            new [] {"Data Structures", "Algorithms"}
        };
    }
    public static Dictionary<string, int> GenerateMasterList(string[][] prereqsCourses)
    {
        var masterList = new Dictionary<string, int>();
        var firstCourse = GetFirstCourse(prereqsCourses);
        masterList.Add(firstCourse, 1);
        foreach (var child in prereqsCourses)
        {
            if (!masterList.Keys.Contains(child[1]))
            {

            }
        }
        return masterList;
    }

    public static string GetChild(string parent, string[][] prereqsCourses)
    {
        var child = prereqsCourses.FirstOrDefault(x => x[0] == parent);
        return child;
    }

    public static string GetFirstCourse(string[][] prereqsCourses)
    {
        //var resultDictionary = new Dictionary<int, string>();
        var hasParrent = false;
        var result = "";

        foreach (var value in prereqsCourses)
        {
            foreach (var secondValue in prereqsCourses)
            {
                if (value[0] == secondValue[1])
                {
                    // This course has parent
                    hasParrent = true;
                }
                if (!hasParrent)
                {
                    return result;
                }
            }
        }

        return result;
    }
}

*/
/*
 * O(N) c#, by rephrasing the equation to a[i] + b[i] = a[j] + b[j], and start count=n, becuse when i=j, equation true for all indices.
Given two arrays of integers a and b of the same length, find the number of pairs (i, j) such that i <=j
and a[i] - b[j] = a[j] - b[i].
public static int GetTotalPairs(int[] a, int[] b)
    {
        int n = a.Length;
        Dictionary<int, int> seenSums = new Dictionary<int, int>();
        int count = n;
        for(int i=0; i<n; i++){
            int x = a[i] + b[i];
            if(!seenSums.ContainsKey(x))
                seenSums.Add(x, 0);
            count += seenSums[x];
            seenSums[x]++;
        }
        return count;
    }
 */ 