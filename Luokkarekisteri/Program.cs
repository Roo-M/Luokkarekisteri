using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VScommunityharjoituksia24;

namespace VScommunityharjoituksia24
{
    // Base class for devices

    class Device
    {
        // Fields
        //-------
        string identity = "Uusi laite";
        string purchaseDate = "1.1.1900";
        double price = 0.00d;
        int warranty = 12;

        // Properties
        //-----------
        public string Identity
        {
            get { return identity; }
            set { identity = value; }
        }
        public string PurchaseDate
        {
            get { return purchaseDate; }
            set { purchaseDate = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public int Warranty
        {
            get { return warranty; }
            set { warranty = value; }
        }

        // Constructors
        //-------------

        public Device()
        {

        }
        // A constructor with on argument
        public Device(string identity)
        {
            this.identity = identity;
        }
        // Another constructor with all arguments
        public Device(string identity, string purchaseDate, double price, int warranty)
        {
            this.identity = identity;
            this.purchaseDate = purchaseDate;
            this.price = price;
            this.warranty = warranty;

            // Other methods

        }
    }
    // Class for computers, inherits Device class
    class Computer : Device
    {
        // Fields
        //-------
        string identity;
        string purchaseDate;
        double price;
        int warranty;

        // Properties
        //-----------

        // Constructors
        //-------------

        // A constructor with one argument

        // Another constructor with all arguments

        // Other methods
        //--------------
    }
    class SmartPhone : Device
    {

    }
    class Tablet : Device
    {

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Let's create new device from Device-class
            Device device = new Device("Munkone");
            Console.WriteLine("Laitteen nimi on: " + device.Identity);
            Console.WriteLine();


            // Let's create a test object from the Device class with default constructor (0 parameters)
            Device device1 = new Device();
            Console.WriteLine(device1.Identity);

            // Let's create another Device with identity parameter
            Device device2 = new Device("Toinen laite");
            Console.WriteLine(device2.Identity);

            // Let's create one more device
            Device device3 = new Device("Kolmas kone", "8.2.2024", 150.00d, 36);

            Console.WriteLine(device3.Identity);
            Console.WriteLine(device3.Price);


            Console.ReadLine();
        }
    }
}