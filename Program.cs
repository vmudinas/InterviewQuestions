namespace InterviewQuestions
{
    class Program
    {
        static void Main(string[] args)
        {

            #region FinrstUniqueChar
            //  var result = FinrstUniqueChar.firstUniqChar("ac,AASDasvgnm,fds rew,mrnwe r365iopjdfl;gm!Cc");
            #endregion
            #region Find Minimum Insertion Steps to Sort Array
            //  var list = new List<int> { 1, 2, 10, 8, 1 };
            //var test = MinInsertionStepToSortArray.solve(list);
            //Console.WriteLine(test);
            #endregion

            #region Find Addwertisments
            /*
            var completedPurchaseUsers = new List<string>() 
            { "3123122444", "234111110", "8321125440", "99911063" };

            // "IP Address, timestamp, Ad text"
            var adClicks = new List<string>() { "122.121.0.1,2016-11-03 11:41:19,Buy wool coats for your pets",
            "96.3.199.11,2016-10-15 20:18:31,2017 Pet Mittens",
            "122.121.0.250,2016-11-01 06:13:13,The Best Hollywood Coats",
            "82.1.106.8,2016-11-12 23:05:14,Buy wool coats for your pets",
            "92.130.6.144,2017-01-01 03:18:55,Buy wool coats for your pets",
            "122.121.0.155,2017-01-01 03:18:55,Buy wool coats for your pets",
            "92.130.6.145,2017-01-01 03:18:55,2017 Pet Mittens" };

            // "User ID, IP address"
            var allUserIps = new List<string>()  { "2339985511,122.121.0.155", 
                "234111110,122.121.0.1", "3123122444,92.130.6.145",
            "39471289472,2001:0db8:ac10:fe01:0000:0000:0000:0000", "8321125440,82.1.106.8",
            "99911063,92.130.6.144" };

            // Assume that one user could do multiple purcheses and would exist in user list multiple times

            //Parse add click to dictionary 
            var clicks = Karata.ParseAddClick(adClicks);
            var purchases = Karata.ParsePurchase(completedPurchaseUsers);
            var users = Karata.ParseUser(allUserIps);

            foreach (var add in clicks.GroupBy(x=>x.AddText).Select(x=>x.FirstOrDefault()))
            {
                var userIds = users.Where(x => clicks.Where(x=>x.AddText == add.AddText).Select(c=>c.Ip).Contains(x.Ip));
                var purchasesCount = purchases.Count(x => userIds.Select(u=>u.UserId).Contains(x.UserId));
                var userClickCount = clicks.Count(x => x.AddText == add.AddText);

                Console.WriteLine($"{purchasesCount} of {userClickCount} {add.AddText}");
            }
            */
            #endregion

            #region word search in Grid

            char[][] grid1 = new[] {
                  new [] {'c', 'c', 'x', 't', 'i', 'b'},
                  new [] {'c', 'c', 'a', 't', 'n', 'i'},
                  new [] {'a', 'c', 'n', 'n', 't', 't'},
                  new [] {'t', 'c', 's', 'i', 'p', 't'},
                  new [] {'a', 'o', 'o', 'o', 'a', 'a'},
                  new [] {'o', 'a', 'a', 'a', 'o', 'o'},
                  new [] {'k', 'a', 'i', 'c', 'k', 'i'}
                };

              string word1 = "catnip";
            //  string word2 = "cccc";
            //  string word3 = "s";
            //  string word4 = "bit";
            //  string word5 = "aoi";
            //  string word6 = "ki";
            //  string word7 = "aaa";
            //  string word8 = "ooo";

            var res =  WordSearchInMatrixGrid.Exist(grid1, word1);

            //  // WordSearch.Exist(grid1, word2);
            //  // WordSearch.Exist(grid1, word3);
            //  // WordSearch.Exist(grid1, word4);
            //  // WordSearch.Exist(grid1, word5);
            //  // WordSearch.Exist(grid1, word6);
            //  // WordSearch.Exist(grid1, word7);
            //  //  WordSearch.Exist(grid1, word8);

            #endregion 


            // int[]arr = { 4,3,5,4,3 };
            //var  xxx=  GFGAA.maxSubsequences(arr, arr.Count());

            // var encodedString = SimpleEncode.Encode("aaaaabbbvvvoopyppoeeeaadd");
            // Console.WriteLine(SimpleEncode.Decode(encodedString));

            //   Console.WriteLine(FinrstUniqueChar.firstUniqChar("aaaaabbbvvvoopyppoeeeaadd"));


            //  var jump = new JumpCode();
            //  var resultJumps =  jump.Jump(new int[] { 2, 8, 1, 1, 1,1,1, 1, 1 });
            //  Console.WriteLine(resultJumps);

            //var test = new WaiFair();
            //// var numbers = new int[] {  2, 7, 8, 9, 11,13,14,22,55,2223,123123 };
            //// var restult1 = test.IsTarget(numbers, 18);
            //// var result2 = test.IsTarget(numbers, 12);
            //var result = test.LongestCommonSubsequenceString("VytautasMudinasNasdasdasmasdasdhnaskldhaklweruewiotu543859", "asdasdasdwq43htry3453thyhj6u7ygtfeadfsMudinas");
            //var re = test.Multiply("2311289123789127301758904375408935794835748390", "2311289123789127301758904375408935794835748390");
            #region DNAMARCH REGEX
            //   var dnaMatch = new SmallerDNAMatch();
            // dnaMatch.GetSmallest("ABCABCABC","ABCABC");
            // var result = dnaMatch.RepeatedSubstringPattern("ABCABC");
            // dnaMatch.ArepeatedSubstringPattern("ABCAABCAABCAABCAABCA");

            #endregion
            #region SGNLRESTCALLHACKERRANK
            //string city = "Denver";

            //int maxCost = 2500;

            //List<string> result = SGNLHackerRank1.getRelevantFoodOutlets(city, maxCost);
            #endregion
            #region SGNL HackerRANK2
            #endregion
        }
    }
}
