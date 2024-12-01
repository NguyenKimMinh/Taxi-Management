using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class TaxiManager
    {
        public SortedDictionary<int, Taxi> taxis = new SortedDictionary<int, Taxi>();

        public SortedDictionary<int, Taxi> GetAllTaxis()
        {
            return taxis;
        }

        public Taxi FindTaxi(int taxinum)
        {   
            if(taxis.ContainsKey(taxinum))
            {
                return taxis[taxinum];
            }
            else
            {
                return null;
            }

        }

        public Taxi CreateTaxi(int taxinum)
        {
            Taxi t = FindTaxi(taxinum);
            if (t == null)
            {
                t = new Taxi(taxinum);
                taxis.Add(taxinum, t);
                return t;
            }
            else
            {
                return (t);
            }

        }

       
    }
}
