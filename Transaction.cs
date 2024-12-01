using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementAssignment
{
    public abstract class Transaction
    {
        public DateTime TransactionDatetime;
        public string TransactionType;

        public Transaction(DateTime dt,string type)
        {
            TransactionType = type;
            TransactionDatetime = dt;
        }

        public  abstract string ToString(); 
    }
}
