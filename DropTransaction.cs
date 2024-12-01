using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class DropTransaction:Transaction
    {
        public int taxiNum;
        public bool priceWasPaid;

        public DropTransaction(DateTime transactionDatetime,int taxinum,bool pricewaspaid):base(transactionDatetime,"Drop fare")
        {
            taxiNum = taxinum;
            priceWasPaid = pricewaspaid;
        }

        public override string ToString()
        {
            string dt = TransactionDatetime.ToString("dd/MM/yyyy HH:mm");
            if (priceWasPaid == true)
            {
                return $"{dt} Drop fare - Taxi {taxiNum}, price was paid";
            }
            else 
            {
                return $"{dt} Drop fare - Taxi {taxiNum}, price was not paid";
            }
        }
    }
}
