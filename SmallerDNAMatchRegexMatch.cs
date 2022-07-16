using System;
using System.Text.RegularExpressions;

namespace InterviewQuestions
{
    public class SmallerDNAMatchRegexMatch
    {
        public SmallerDNAMatchRegexMatch()
        {
            string pt = @"^(.+?)(?=\1*$)";
            // Create a Regex  
            Regex rgp = new Regex(pt);
            MatchCollection matchedAuthors = rgp.Matches("CATGCATGCATGCATG");
            MatchCollection matchedAuthors2 = rgp.Matches("CATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATG");

                var tempSecondaryString = "CATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATGCATG";
                    while (tempSecondaryString.Length >= "CATGCATGCATGCATG".Length)
                    {
                        tempSecondaryString = tempSecondaryString.Replace("CATGCATGCATGCATG", "");
                        Console.WriteLine(tempSecondaryString);
                    }

            Console.WriteLine(tempSecondaryString);
        }
   

    }
}
