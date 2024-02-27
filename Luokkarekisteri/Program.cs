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

        // Ohjelman käynnistävä metodi
        // ---------------------------
        static void Main(string[] args)
        {
            // Ikuinen silmukka pääohjelman käynnissä pitämiseen
            while (true)
            {
                Console.WriteLine("Minkä laitteen tiedot tallennetaan?");
                Console.WriteLine("1 tietokone, 2 tabletti ");
                string type = Console.ReadLine();

                // Luodaan Switch-Case-rakenne vaihtoehdoille

                switch (type)
                {
                    case "1":   // computer
                        Console.WriteLine("Nimi: ");
                        string computerName = Console.ReadLine();
                        Computer computer = new Computer();
                        break;

                    case "2":   // tablet
                        Console.WriteLine("Nimi: ");
                        string tabletName = Console.ReadLine();
                        Tablet tablet = new Tablet();
                        break;

                    default:
                        Console.WriteLine("Virheellinen valinta, anna pelkkä numero");
                        break;
                }

                // Ohjelman sulkeminen: poistutaan ikuisesta silmukasta
                Console.WriteLine("Haluatko jatkaa K/E");
                string continueAnswer = Console.ReadLine();
                continueAnswer = continueAnswer.Trim();
                continueAnswer = continueAnswer.ToLower();
                if (continueAnswer == "e")
                {
                    break;
                }
            }


            // Leave window open until enter is pushed
            Console.ReadLine();
        }
    }
}