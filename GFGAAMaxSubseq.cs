﻿using System.Collections.Generic;

namespace InterviewQuestions
{
    public static class GFGAAMaxSubseq
    {

        // Function to find the maximum number
        // number of required subsequences
        public static int maxSubsequences(int[] arr, int n)
        {

            // Dictionary to store number of
            // arrows available with
            // height of arrow as key
            Dictionary<int,
                       int> map = new Dictionary<int,
                                                 int>();

            // Stores the maximum count
            // of possible subsequences
            int maxCount = 0;

            // Stores the count of
            // possible subsequences
            int count;

            for (int i = 0; i < n; i++)
            {

                // Check if i-th element can be
                // part of any of the previous
                // subsequence
                if (map.ContainsKey(arr[i]))
                {

                    // Count  of subsequences
                    // possible with arr[i] as
                    // the next element
                    count = map[arr[i]];

                    // If more than one such
                    // subsequence exists
                    if (count > 1)
                    {

                        // Include arr[i] in a subsequence
                        map.Add(arr[i], count - 1);
                    }

                    // Otherwise
                    else
                        map.Remove(arr[i]);

                    // Increase count of subsequence possible
                    // with arr[i] - 1 as the next element
                    if (arr[i] - 1 > 0)
                        if (map.ContainsKey(arr[i] - 1))
                            map[arr[i] - 1]++;
                        else
                            map.Add(arr[i] - 1, 1);
                }
                else
                {

                    // Start a new subsequence
                    maxCount++;

                    // Increase count of subsequence possible
                    // with arr[i] - 1 as the next element
                    if (arr[i] - 1 > 0)
                        if (map.ContainsKey(arr[i] - 1))
                            map[arr[i] - 1]++;
                        else
                            map.Add(arr[i] - 1, 1);
                }
            }

            // Return the answer
            return maxCount;
        }
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