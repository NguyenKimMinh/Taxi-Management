using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class TransactionManager
    {
       public List<Transaction> transactions = new List<Transaction>();

        public List<Transaction> GetAllTransactions()
        {
            return transactions;
        }

        public void RecordJoin(int taxiNum,int rankId)
        {
            transactions.Add(new JoinTransaction(DateTime.Now, taxiNum, rankId));
        }

        public void RecordLeave(int rankId,Taxi t)
        {
            transactions.Add(new LeaveTransaction(DateTime.Now, rankId, t));
        }

        public void RecordDrop(int taxiNum,bool pricePaid)
        {
            transactions.Add(new DropTransaction(DateTime.Now, taxiNum, pricePaid));
        }
    }
}
