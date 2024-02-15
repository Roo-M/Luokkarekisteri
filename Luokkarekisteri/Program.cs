using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VScommunityharjoituksia24;

namespace VScommunityharjoituksia24
{
    // Base class for devices
    //=======================
    class Device
    {
        // Fields
        //-------
        string name = "Uusi laite";
        string purchaseDate = "1.1.1900";
        double price = 0.00d;
        int warranty = 12;
        string processorType = "N/A";
        int amountRAM = 0;
        int storageCapacity = 0;
        string operatingSystem = "android";

        // Properties
        //-----------
        public string Name
        {
            get { return name; }
            set { name = value; }
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

        public string OperatingSystem
        {
            get { return operatingSystem; }
            set { operatingSystem = value; }
        }


        // Constructors
        //-------------

        public Device()
        {

        }
        // A constructor with on argument
        public Device(string name)
        {
            this.name = name;
        }
        // Another constructor with all arguments
        public Device(string name, string purchaseDate, double price, int warranty)
        {
            this.name = name;
            this.purchaseDate = purchaseDate;
            this.price = price;
            this.warranty = warranty;

        }

        // Other methods
        //--------------
        // Yliluokan metodit
        public void ShowPurchaseInfo()
        { 
            // Read devices purchase info from its fields, notice!: this
            Console.WriteLine("Laitteen nimi: " +  this.name);
            Console.WriteLine("Ostopäivä: " + this.purchaseDate);
            Console.WriteLine("Hankinta hinta: " + this.price);
            Console.WriteLine("Takuu: " + this.warranty + " kk");
        }

        // Read device basic technical info from properties, notice: big first letter
        public void ShowBasicTechnicalInfo()
        {
            Console.WriteLine("Koneen nimi: " + Name);
            Console.WriteLine("Prosessori: " + ProcessorType);
            Console.WriteLine("Keskusmuisti: " + AmountRAM);
            Console.WriteLine("Levytila: " + StorageCapacity);
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

        public Computer(string name) : base(name)
            { }

        // A constructor with one argument

        // Another constructor with all arguments

        // Other methods
        //--------------
        
    }

    class SmartPhone : Device
    {
        // Fields

    }

    // Tablet class inherits device class
    class Tablet : Device
    {
        // Fields

        bool stylusEnabled = false;

        // Properties

        public bool StylusEnabled
        {
            get { return stylusEnabled; }
            set { stylusEnabled = value; }
        }

        // Constructors
        // ------------
        public Tablet() : base() { }

        public Tablet(string name) : base(name) { }

        // Tablet class special methods
        // ----------------------------
        public void TabletInfo()
        {
            Console.WriteLine("Käyttöjärjestelmä: " + OperatingSystem);
            Console.WriteLine("Kynätuki: " + StylusEnabled);
        }

    }
    // Main program class, that has Program.exe
    // ========================================
    internal class Program
    {
        static void Main(string[] args)
        {
            // Let's make new computer, that inherits device class properties and methods
            Computer tietokone1 = new Computer();

            // Put processor-attribute value for first computer
            tietokone1.ProcessorType = "Intel i7";
            tietokone1.AmountRAM = 16;
            tietokone1.PurchaseDate = "15.2.2024";
            tietokone1.Price = 850.00d;
            tietokone1.Warranty = 36;

            Console.WriteLine("Tietokone 1:n hankintatiedot");
            Console.WriteLine("----------------------------");
            tietokone1.ShowPurchaseInfo();

            // Lets make new named computer with another constructor
            Computer tietokone2 = new Computer("Mikan läppäri");
            tietokone2.ProcessorType = "Intel Core i7 vPro";
            tietokone2.AmountRAM = 32;

            Console.WriteLine("Tietokone 2:n tekniset tiedot");
            Console.WriteLine("-----------------------------");
            tietokone2.ShowBasicTechnicalInfo();

            // Lets make test object for tablet

            Tablet tabletti1 = new Tablet("Mikan iPad");
            tabletti1.PurchaseDate = "1.10.2022";
            tabletti1.OperatingSystem = "iOS";
            tabletti1.StylusEnabled = true;

            // Show info with methods
            Console.WriteLine("Tabletti 1:n hankintatiedot");
            Console.WriteLine("----------------------------");
            tabletti1.ShowPurchaseInfo();

            Console.WriteLine("Tabletti 1:n tekniset tiedot");
            Console.WriteLine("-----------------------------");
            tabletti1.ShowBasicTechnicalInfo();

            Console.WriteLine("Tabletti 1:n erityistiedot");
            Console.WriteLine("----------------------------");
            tabletti1.TabletInfo();

            // Leave window open until enter is pushed
            Console.ReadLine();
        }
    }
}