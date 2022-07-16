using System;
using System.Collections.Generic;

namespace InterviewQuestions
{
    public class KarataInterviewOOPAddsParse
    {
        /*
The people who buy ads on our network don't have enough data about how ads are working for their business. They've asked us to find out which ads produce the most purchases on their website.

Our client provided us with a list of user IDs of customers who bought something on a landing page after clicking one of their ads:

Each user completed 1 purchase.
completed_purchase_user_ids = [
"3123122444","234111110", "8321125440", "99911063"]

And our ops team provided us with some raw log data from our ad server showing 
        every time a user clicked on one of our ads:

ad_clicks = [
#"IP_Address,Time,Ad_Text",
"122.121.0.1,2016-11-03 11:41:19,Buy wool coats for your pets",
"96.3.199.11,2016-10-15 20:18:31,2017 Pet Mittens",
"122.121.0.250,2016-11-01 06:13:13,The Best Hollywood Coats",
"82.1.106.8,2016-11-12 23:05:14,Buy wool coats for your pets",
"92.130.6.144,2017-01-01 03:18:55,Buy wool coats for your pets",
"122.121.0.155,2017-01-01 03:18:55,Buy wool coats for your pets",
"92.130.6.145,2017-01-01 03:18:55,2017 Pet Mittens",
]

//2017 Pet Mittens [3123122444, 96.3.199.11]

The client also sent over the IP addresses of all their users.

all_user_ips = [
#"User_ID,IP_Address",
"2339985511,122.121.0.155",
"234111110,122.121.0.1",
"3123122444,92.130.6.145",
"39471289472,2001:0db8:ac10:fe01:0000:0000:0000:0000",
"8321125440,82.1.106.8",
"99911063,92.130.6.144"
]

Write a function to parse this data, determine how many times each 
        ad was clicked, then return the ad text, 
        that ad's number of clicks, 
        and how many of those ad clicks were from users who made a purchase.

Expected output:

1 of 2 2017 Pet Mittens
0 of 1 The Best Hollywood Coats
3 of 4 Buy wool coats for your pets

purchases: number of purchase IDs
clicks: number of ad clicks
ips: number of IP addresses
*/
        public class Purchase
        {
            public string UserId { get; set; }
        }

        public class User
        {
            public string Ip { get; set; }
            public string UserId { get; set; }
        }

        public class AddClick
        {
            public string Ip { get; set; }
            public string AddText { get; set; }
            public string TimeStamp { get; set; }
        }

        public static List<AddClick> ParseAddClick(List<string> addClicks)
        {
            var result = new List<AddClick>();
            foreach (var addClick in addClicks)
            {
                var newClick = new AddClick();
                var addClickArray = addClick.Split(',', StringSplitOptions.RemoveEmptyEntries);
                if (addClickArray[0] != null
                    && addClickArray[1] != null
                    && addClickArray[2] != null)
                {
                    newClick.Ip = addClickArray[0];
                    newClick.AddText = addClickArray[2];
                    newClick.TimeStamp = addClickArray[1];
                }

                result.Add(newClick);
            }
            return result;
        }

        public static List<User> ParseUser(List<string> users)
        {
            var result = new List<User>();
            foreach (var user in users)
            {
                var newUser = new User();
                var userArray = user.Split(',', StringSplitOptions.RemoveEmptyEntries);
                if (userArray[0] != null
                    && userArray[1] != null)
                {
                    newUser.UserId = userArray[0];
                    newUser.Ip = userArray[1];
                }

                result.Add(newUser);
            }
            return result;
        }

        public static List<Purchase> ParsePurchase(List<string> purchases)
        {
            var result = new List<Purchase>();
            foreach (var user in purchases)
            {
                var purchase = new Purchase();
                var purchaseArray = user.Split(',', StringSplitOptions.RemoveEmptyEntries);
                if (purchaseArray[0] != null)
                {
                    purchase.UserId = purchaseArray[0];
                }

                result.Add(purchase);
            }
            return result;
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