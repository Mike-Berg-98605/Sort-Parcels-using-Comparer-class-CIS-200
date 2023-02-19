// Program 4
// CIS 200-01
// Fall 2021
// Due: 12/2/2021
// By: Michael Bergamini

// File: DescendingOrderByZip.cs
// sorts the list of parcels in descending order by zip



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    class DescendingOrderByZip : Comparer<Parcel>
    {
        //precondition: none
        //postcondition: compares parcels if not null
        public override int Compare(Parcel x, Parcel y)
        {
            if (x == null && y == null)
                return 0;

            if (x == null)
                return -1;

            if (y == null)
                return 1;

            int xZip = x.DestinationAddress.Zip; //store zip 
            int yZip = y.DestinationAddress.Zip; //stores zip
            
            return (-1) * xZip.CompareTo(yZip); // Reverses natural order, so descending
        }
    }
}
