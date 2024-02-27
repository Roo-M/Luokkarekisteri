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

                        // Kysytään käyttäjän tietokoneen tiedot
                        // ja luodaan uusi tietokoneolio
                        // ! Laita Write jotta syötetty teksti tulee kysymyksen perään, WriteLine tekee sen kysymyksen alle !
                        Console.Write("Nimi: ");
                        string computerName = Console.ReadLine();
                        Computer computer = new Computer(computerName);
                        Console.Write("Ostopäivä: ");
                        computer.PurchaseDate = Console.ReadLine();
                        Console.Write("Hankintahinta: ");
                        string price = Console.ReadLine();

                        try
                        {
                            computer.Price = double.Parse(price);
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Virheellinen hintatieto, käytä desimalipilkkua (,) " + ex.Message);

                            break;
                        }

                        Console.Write("Takuun kesto kuukaisina: ");
                        string warranty = Console.ReadLine();

                        try
                        {
                            computer.Warranty = int.Parse(warranty);
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Virheellinen takuutieto, vain kuukausien määrä kokonaislukuina " + ex.Message);
                        }

                        Console.Write("Prosessorin tyyppi: ");
                        computer.ProcessorType = Console.ReadLine();
                        Console.Write("Keskusmuistin määrä: ");
                        string amountRAM = Console.ReadLine();

                        try
                        {
                            computer.AmountRAM = int.Parse(amountRAM);
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Virheellinen muistin määrä, vain kokonaisluvut sallittu " + ex.Message);
                        }

                        Console.Write("Tallennuskapasiteetti (GB): ");
                        string storageCapacity = Console.ReadLine();

                        try
                        {
                            computer.StorageCapacity = int.Parse(storageCapacity);
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Virheellinen tallennustilan koko, vain kokonaisluvut sallittu")
                        }

                        Console.Write("Käyttöjärjestelmä: ");
                        computer.OperatingSystem = Console.ReadLine();

                        // Näytetään olion tiedot metodien avulla
                        computer.ShowPurchaseInfo();
                        computer.ShowBasicTechnicalInfo();

                        break;

                    case "2":   // tablet
                        Console.Write("Nimi: ");
                        string tabletName = Console.ReadLine();
                        Tablet tablet = new Tablet(tabletName);
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