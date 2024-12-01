using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class UserUI
    {
        public RankManager rankMgr = new RankManager();
        public TaxiManager taxiMgr = new TaxiManager();
        public TransactionManager transactionMgr=new TransactionManager();

        public UserUI(RankManager rkMgr, TaxiManager txMgr, TransactionManager trMgr)
        {
            rankMgr = rkMgr;
            taxiMgr = txMgr;
            transactionMgr = trMgr;
        }

        public List<string> TaxiJoinsRank(int taxiNum,int rankId)
        {   List<string> result = new List<string>();
            Taxi t=taxiMgr.FindTaxi(taxiNum);
            if (t == null)
            {
                t=taxiMgr.CreateTaxi(taxiNum);
            }

            bool addSuccess=rankMgr.AddTaxiToRank(t,rankId);

            if (addSuccess == true)
            {  
                transactionMgr.RecordJoin(taxiNum,rankId);
                result.Add($"Taxi {taxiNum} has joined rank {rankId}.");
            }
            else
            {
                result.Add($"Taxi {taxiNum} has not joined rank {rankId}.");
            }

            return result;


        }
        public List<string> TaxiLeavesRank(int rankId,string destination,double agreedPrice)
        {
            List<string> result = new List<string>();
            //If destination is empty,turn it to Nowhere
            if (destination == "")
            {
                destination = "Nowhere";
            }
            Taxi t = rankMgr.FrontTaxiInRankTakesFare(rankId, destination, agreedPrice);

            if (t == null)
            {
                result.Add($"Taxi has not left rank {rankId}.");
            }
            else
            {
                //t.AddFare(destination, agreedPrice);
                transactionMgr.RecordLeave(rankId, t);
                result.Add($"Taxi {t.Number} has left rank {rankId} to take a fare to {destination} for £{agreedPrice}.");
            }

            return result;
        }

        public List<string> TaxiDropsFare(int taxiNum,bool pricePaid)
        {
            List<string> result = new List<string>();
            Taxi t = taxiMgr.FindTaxi(taxiNum);

            if((t == null) || (t.Location != Taxi.ON_ROAD) ||(t.Destination == ""))
            {
                result.Add($"Taxi {taxiNum} has not dropped its fare.");
                
            }

            else if  (pricePaid == false) 
            {
                t.DropFare(pricePaid);
                transactionMgr.RecordDrop(taxiNum, pricePaid);
                result.Add($"Taxi {t.Number} has dropped its fare and the price was not paid.");
            }
            else
            {
                t.DropFare(pricePaid);
                result.Add($"Taxi {t.Number} has dropped its fare and the price was paid.");
                transactionMgr.RecordDrop(taxiNum, pricePaid);
            }

            return result;
        }

        public List<string> ViewTaxiLocations()
        {
            List<string> result = new List<string>() { "Taxi locations", "==============" };
           
            SortedDictionary<int,Taxi> taxis = taxiMgr.GetAllTaxis();

            if (taxis.Count == 0)
            {
                
                result.Add("No taxis");
                
            }

            foreach(KeyValuePair<int,Taxi> t in taxis)
            {
                Taxi taxi = t.Value;

                if (taxi.Location==Taxi.IN_RANK)
                {
                    
                    result.Add($"Taxi {t.Key} is in rank {taxi.Rank.Id}");
                }

                else if ((taxi.Destination != "") && (taxi.Location == Taxi.ON_ROAD))
                {
                    
                    result.Add($"Taxi {t.Key} is on the road to {taxi.Destination}");
                }

                else if ((taxi.Destination == "") && (taxi.Location == Taxi.ON_ROAD))
                {
                    
                    result.Add($"Taxi {t.Key} is on the road");
                }

            }

            return result;
        }

        public List<string> ViewFinancialReport()
        {
            List<string> result = new List<string>() { "Financial report", "================" };
            

            SortedDictionary<int,Taxi> taxis = taxiMgr.GetAllTaxis();

            if (taxis.Count == 0)
            {
                result.Add("No taxis, so no money taken");
            }
            else
            {   
                double Total=0.00;

                foreach (KeyValuePair<int, Taxi> t in taxis)
                {
                    Taxi taxi = t.Value;
                    

                    Total += taxi.TotalMoneyPaid;

                    result.Add(String.Format("Taxi {0}      {1:0.00}",t.Key,taxi.TotalMoneyPaid));
                }
                result.Add("           ======");
                result.Add(String.Format("Total:       {0:0.00}",Total));
                result.Add("           ======");
            }
                return result;
        }

        public List<string> ViewTransactionLog()
        {
            List<string> result = new List<string>() { "Transaction report" , "==================" };
           

            List<Transaction> transactions = transactionMgr.GetAllTransactions();

            if(transactions.Count == 0)
            {
                result.Add("No transactions");
            }

            

            else
            {
                foreach(Transaction tr in transactions)
                {
                    
                    {
                        result.Add(tr.ToString());
                    }
                }
            }

            return result;
        }
    }
}
