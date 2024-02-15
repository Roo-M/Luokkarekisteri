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
        string processorType = "N/A";
        int amountRAM = 0;
        int storageCapacity = 0;

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

        
        public string ProcessorType
        {
            get { return processorType; }
            set { processorType = value; }
        }
        
        public int AmountRAM
        {
            get { return amountRAM; }
            set { amountRAM = value; }
        }
        
        public int StorageCapacity
        {
            get { return storageCapacity; }
            set { storageCapacity = value; }
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
        // Fields and properties
        //----------------------
        //string identity;
        //string purchaseDate;
        //double price;
        //int warranty;

        
        // Constructors
        //-------------
        public Computer() : base()
            { }

        public Computer(string identity) : base(identity)
            { }

        // A constructor with one argument

        // Another constructor with all arguments

        // Other methods
        //--------------
        public void ShowInfo()
        {
            Console.WriteLine("Koneen nimi: " + Identity);
            Console.WriteLine("Prosessori: " +  ProcessorType);
            Console.WriteLine("Keskusmuisti: " +  AmountRAM);
            Console.WriteLine("Levytila: " +  StorageCapacity);
        }
    }

    class SmartPhone : Device
    {

    }

    // Tablet class inherits device class
    class Tablet : Device
    {
        // Fields
        string operatingSystem;
        bool stylusEnabled = false;

        // Properties
        public string OperatingSystem
        {
            get { return operatingSystem; }
            set { operatingSystem = value; }
        }
        public bool StylusEnabled
        {
            get { return stylusEnabled; }
            set { stylusEnabled = value; }
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Let's create new device from Device-class
            Device device = new Device("Munkone");
            Console.WriteLine("Laitteen nimi on: " + device.Identity);
            Console.WriteLine("Ostopäivä oli: " + device.PurchaseDate);


            // Let's create a test object from the Device class with default constructor (0 parameters)
            //Device device1 = new Device();
            //Console.WriteLine(device1.Identity);

            // Let's create another Device with identity parameter
            //Device device2 = new Device("Toinen laite");
            //Console.WriteLine(device2.Identity);

            // Let's create one more device
            //Device device3 = new Device("Kolmas kone", "8.2.2024", 150.00d, 36);

            //Console.WriteLine(device3.Identity);
            //Console.WriteLine(device3.Price);


            // Let's make new computer, that inherits device class properties and methods
            Computer tietokone1 = new Computer();

            // Put processor-attribute value
            tietokone1.ProcessorType = "Intel i7";
            tietokone1.AmountRAM = 16;

            Console.WriteLine("Uuden tietokoneen nimi on: " + tietokone1.Identity + " ja siinä on " + tietokone1.ProcessorType + " -prosessori ja " + tietokone1.AmountRAM + " GB keskusmuistia");

            // Lets make new named computer with another constructor
            Computer tietokone2 = new Computer("Mikan läppäri");
            tietokone2.ProcessorType = "Intel Core i7 vPro";
            tietokone2.AmountRAM = 32;
            tietokone2.ShowInfo();

            // Leave window open until enter is pushed
            Console.ReadLine();
        }
    }
}