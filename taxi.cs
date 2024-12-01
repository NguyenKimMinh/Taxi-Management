using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class Taxi
    {
        public const string ON_ROAD = "on the road";
        public const string IN_RANK = "in rank";
        public int Number;
        public double CurrentFare = 0;
        public string Destination { get; private set; } = "";
        public string Location = ON_ROAD;
        public double TotalMoneyPaid = 0;
        private Rank rank = null;

        public Rank Rank
        {
            get
            {
                return rank;
            }
            set
            {
                if (value is null)
                {
                    throw new Exception("Rank cannot be null");
                }

                else if (Destination.Length > 0)
                {
                    throw new Exception("Cannot join rank if fare has not been dropped");
                }
                else
                {
                    rank = value;
                    Location = IN_RANK;
                }








            }
        }
        public Taxi(int num)
        {


            Number = num;
            //    if (Destination.Length==0)
            //{
            //    Location = IN_RANK;
            //}

            //else
            //{
            //    Location = ON_ROAD;
            //}

        }



        public  void AddFare(string destination, double agreedprice)
        {
            Destination = destination;
            CurrentFare = agreedprice;
            Location = ON_ROAD;
            rank = null;
        }

        public void DropFare(bool priceWasPaid)
        {
            Destination = "";
            if (priceWasPaid == true)
            {
                
                TotalMoneyPaid =TotalMoneyPaid+CurrentFare;
                
            }
            CurrentFare = 0;

        }
    }
}



