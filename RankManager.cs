



















































































































































using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class RankManager
    {
        public Dictionary<int, Rank> ranks = new Dictionary<int, Rank>();

        public RankManager()
        {
            Rank r1 = new Rank(1, 5);
            ranks.Add(1, r1);
            Rank r2 = new Rank(2, 2);
            ranks.Add(2, r2);
            Rank r3 = new Rank(3, 4);
            ranks.Add(3, r3);
        }

        public Rank FindRank(int rankid)
        {
            if (ranks.ContainsKey(rankid))
            {
                Rank r = ranks[rankid];
                return r;
            }
            else
            {
                return null;
            }
        }
        public bool AddTaxiToRank(Taxi t, int rankid)
        {
            Rank rank =FindRank(rankid);
             
            if (t.Rank == rank)
            {
                return false;
            }

            else if (t.Rank != null)
            {
                return false;
            }

            else if (rank == null)
            {
                return false;
            }

            else if (t.Destination != "")
            {
                return false;
            }

            else if (rank.NumberOfTaxiSpaces ==0)
            {
                return false;
            }

           
            else
            {
                rank.AddTaxi(t);
                return true;
            }
        }

        public Taxi FrontTaxiInRankTakesFare(int rankid,string destination,double agreedprice)
        {
            Rank rank = FindRank(rankid);
            if (rank == null)
            {
                return null;
            }
            Taxi taxi= rank.FrontTaxiTakesFare(destination, agreedprice);

            if (taxi == null)
            {
                return null;
            }
            else
            {
                return taxi;
            }
        }
    }

}
