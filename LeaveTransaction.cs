using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    
    public class LeaveTransaction:Transaction
    {
        public int taxiNum;
        public int rankId;
        public string destination;
        public double agreedPrice;

        public LeaveTransaction(DateTime transactionDatetime,int rankid,Taxi t):base(transactionDatetime,"Leave")
        {
            rankId = rankid;
            destination = t.Destination;
            taxiNum = t.Number;
            agreedPrice = t.CurrentFare;
        }

        public override string ToString()
        {
            string dt = TransactionDatetime.ToString("dd/MM/yyyy HH:mm");
            return $"{dt} Leave     - Taxi {taxiNum} from rank {rankId} to {destination} for £{agreedPrice}";
        }
    }
}
