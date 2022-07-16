using System;
using System.Linq;

public class FoundConsecutivesSortArrays
{
    public FoundConsecutivesSortArrays()

        {
            // Here's what I came up with
            string[] userSelect = { "/start", "/pink", "/register", "/orange", "/red", "a" };
            string[] original = { "/start", "/green", "/blue", "/pink", "/register", "/orange", "/one/two" };

            var matches =
                (from l in userSelect.Select((s, i) => new { s, i })
                 join r in original.Select((s, i) => new { s, i })
                 on l.s equals r.s
                 group l by r.i - l.i into g
                 from m in g.Select((l, j) => new { l.i, j = l.i - j, k = g.Key })
                 group m by new { m.j, m.k } into h
                 select h.Select(t => t.i).ToArray())
                .ToArray();
            var result = matches.OrderByDescending(x => x.Length).FirstOrDefault();

            Console.WriteLine(result.ToString());
        }

}