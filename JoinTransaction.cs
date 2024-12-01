using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementAssignment
{
    public class JoinTransaction:Transaction
    {
        public int taxiNum;
        public int rankId;
        public JoinTransaction(DateTime transactionDatetime, int taxinum, int rankid):base(transactionDatetime,"Join")
        {
            taxiNum = taxinum;
            rankId = rankid;
        }

        public override  string ToString()
        {
            string dt = TransactionDatetime.ToString("dd/MM/yyyy HH:mm");
            return $"{dt} Join      - Taxi {taxiNum} in rank {rankId}";
        }

    }
}
