// Program 4
// CIS 200-01
// Fall 2021
// Due: 12/2/2021
// By: Michael Bergamini

// File: SortbyTypeAndCost.cs
// sorts the list of parcels by type then by cost descending

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    class SortByTypeAndCost : Comparer<Parcel>
    {

        //precondition: none
        //postcondition: parcels are compared if not null
        public override int Compare(Parcel x, Parcel y)
        {
            if (x == null && y == null)
                return 0;

            if (x == null)
                return -1;

            if (y == null)
                return 1;

            string typeX = x.GetType().ToString();//stores object name 
            string typeY = y.GetType().ToString();//stores object name
            decimal costX = x.CalcCost();//stores object cost
            decimal costY = y.CalcCost();//stores object cost

            if (typeX != typeY)
                return typeX.CompareTo(typeY); 

            return (-1) * costX.CompareTo(costY); //displays list in descending order

        }
    }
}
