// Program 1A
// CIS 200-01
// Fall 2020
// Due: 9/21/2020
// By: Mike Bergamini
// File: TestParcels.cs
// This is a simple, console application designed to exercise the Parcel hierarchy.
// It creates several different Parcels and prints them.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace Prog1
{
    class TestParcels
    {
        // Precondition:  None
        // Postcondition: Parcels have been created and displayed
        static void Main(string[] args)
        {
            // Test Data - Magic Numbers OK
            Address a1 = new Address("  John Smith  ", "   123 Any St.   ", "  Apt. 45 ",
                "  Louisville   ", "  KY   ", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.",
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 14101); // Test Address 4
            Address a5 = new Address("John John", "678 Paul Gasol Place", "Apt. 7",
                "Portland", "ME", 54101); // Test Address 4

            Letter letter1 = new Letter(a1, a2, 3.95M);                            // Letter test object
            GroundPackage gp1 = new GroundPackage(a3, a4, 14, 10, 5, 12.5);        // Ground test object
            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a3, 25, 15, 15,    // Next Day test object
                85, 7.50M);
            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a4, a5, 46.5, 39.5, 28.0, // Two Day test object
                80.5, TwoDayAirPackage.Delivery.Saver);
            Letter letter2 = new Letter(a1, a3, 4.95M);
            Letter letter3 = new Letter(a1, a2, 5.95M);
            Letter letter4 = new Letter(a2, a5, 6.95M);
            Letter letter5 = new Letter(a2, a3, 7.95M);
            Letter letter6 = new Letter(a2, a4, 8.95M);
            Letter letter7 = new Letter(a3, a1, 9.95M);



            List<Parcel> parcels;      // List of test parcels

            parcels = new List<Parcel>();

            parcels.Add(letter1); // Populate list
            parcels.Add(gp1);
            parcels.Add(ndap1);
            parcels.Add(tdap1);
            parcels.Add(letter2);
            parcels.Add(letter3);
            parcels.Add(letter4);
            parcels.Add(letter5);
            parcels.Add(letter6);
            parcels.Add(letter7);
             
            WriteLine("Original List:");
            WriteLine("====================");
            foreach (Parcel p in parcels)
            {
                Write("Sender: ");
                WriteLine(p.OriginAddress.Name);
                Write("Reciever: ");
                WriteLine(p.DestinationAddress.Name);
                WriteLine("====================");
            }
            Pause();

            //precondition: none
            //postcondition: parcels are sorted ascending
            parcels.Sort();
            WriteLine("Sorted By Cost Ascending:");
            WriteLine("====================");
            foreach (Parcel p in parcels)
            {
                WriteLine(p.CalcCost().ToString("C"));
                WriteLine("====================");
            }
            Pause();

            //precondition: none
            //postocondition: parcels are sorted descending by zip
            parcels.Sort(new DescendingOrderByZip());

            WriteLine("Sorted By Zip Descending");
            WriteLine("====================");
            foreach (Parcel p in parcels)
            {
                WriteLine(p.DestinationAddress.Zip);
                WriteLine("====================");
            }
            Pause();


            //precondition: none
            //postcondition: parcels are sorted by type then cost descending
            parcels.Sort(new SortByTypeAndCost());

            WriteLine("Sorted By Type and Cost(Descending)");
            WriteLine("====================");
            foreach (Parcel p in parcels)
            {
                WriteLine($"{p.GetType().ToString()}\t{p.CalcCost().ToString("C")}");
                WriteLine("====================");
            }
            Pause();
        }

        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and
        //                then clears the screen
        public static void Pause()
        {
            WriteLine("Press Enter to Continue...");
            ReadLine();

            Console.Clear(); // Clear screen
        }
    }
}
