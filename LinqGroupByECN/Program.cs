using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqGroupByECN
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var x = new List<Ecn>()
            {
                new Ecn { EcnNo = "1", Reason = "Reason", Seq = 1, Info = "111"},
                new Ecn { EcnNo = "1", Reason = "Reason", Seq = 2, Info = "222"},
                new Ecn { EcnNo = "1", Reason = "Reason", Seq = 3, Info = "333"},
                new Ecn { EcnNo = "1", Reason = "Reason", Seq = 4, Info = "444"},
                new Ecn { EcnNo = "x1", Reason = "Reason", Seq = 1, Info = "111"},
                new Ecn { EcnNo = "x1", Reason = "Reason", Seq = 2, Info = "222"},
                new Ecn { EcnNo = "x1", Reason = "Reason", Seq = 3, Info = "333"},
                new Ecn { EcnNo = "x1", Reason = "Reason", Seq = 4, Info = "444"}
            };

            var ecns = x
                .GroupBy(x => new { x.EcnNo, x.Reason })
                .ToDictionary(x => new { x.Key.EcnNo, x.Key.Reason }, x => x.ToList());
            var AlertMsg = "";
            foreach (var ecn in ecns)
            {
                var s = AlertMsg == "" ? "" : "\\r";
                AlertMsg += $"{s}{ecn.Key.EcnNo}\\r{ecn.Key.Reason}";
                foreach (var item in ecn.Value)
                {
                    AlertMsg += $"\\r{item.Seq}.{item.Info}";
                }
            }
        }

        private class Ecn
        {
            public string EcnNo { get; set; }
            public string Reason { get; set; }
            public int Seq { get; set; }
            public string Info { get; set; }
        }
    }
}