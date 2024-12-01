using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class Rank
    {
        public int Id;
        public int NumberOfTaxiSpaces;
        public List<Taxi> taxiSpace = new List<Taxi>();
        public Rank(int id, int numOfSpaces)
        {
            Id = id;
            NumberOfTaxiSpaces = numOfSpaces;
        }
        
        public bool AddTaxi(Taxi taxi)
        {   
            if (NumberOfTaxiSpaces > 0)
            {
                taxiSpace.Add(taxi);
                taxi.Rank = this;
                NumberOfTaxiSpaces -= 1;
                return true;
            }
            
            else
            {
                return false;
            }
        }

        public Taxi FrontTaxiTakesFare(string destination, double agreedprice)
        {

            if (taxiSpace.Count == 0)
            //if (taxiSpace[0] is null)
            {
                return null;
            }

            
                Taxi t = taxiSpace[0];


                t.AddFare(destination, agreedprice);
                taxiSpace.Remove(t);
                NumberOfTaxiSpaces += 1;
                return t;
            
            
        }
    }
}
