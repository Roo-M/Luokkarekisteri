using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VScommunityharjoituksia24;

// Tiedostonkäsittelyyn ja serialisointiin tarvittavat kirjastot
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace VScommunityharjoituksia24
{
    // Base class for devices
    //=======================
    [Serializable]
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
            Console.WriteLine();
            Console.WriteLine("Laitteen hankintatiedot");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Laitteen nimi: " +  this.name);
            Console.WriteLine("Ostopäivä: " + this.purchaseDate);
            Console.WriteLine("Hankinta hinta: " + this.price);
            Console.WriteLine("Takuu: " + this.warranty + " kk");
        }

        // Read device basic technical info from properties, notice: big first letter
        public void ShowBasicTechnicalInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Laitteen tekniset tiedot");
            Console.WriteLine("------------------------");
            Console.WriteLine("Koneen nimi: " + Name);
            Console.WriteLine("Prosessori: " + ProcessorType);
            Console.WriteLine("Keskusmuisti: " + AmountRAM);
            Console.WriteLine("Levytila: " + StorageCapacity);
        }

        // Lasketaan takuun päättymispäivä, huomaa ISO-standardin mukaiset päivämäärät: vuosi-kuukausi-päivä
        public void CalculateWarrantyEndingDate()
        {
            // Muutetaan päivämäärä merkkijono päivämäärä-kellonaika-muotoon
            DateTime startDate = DateTime.ParseExact(this.PurchaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            // Lisätään takuun kesto
            DateTime endDate = startDate.AddMonths(this.Warranty);

            // Muunnetaan päivämäärä ISO-standardin mukaiseen muotoon
            endDate = endDate.Date;

            string isoDate = endDate.ToString("yyyy-MM-dd");

            Console.WriteLine("Takuu päättyy: " + isoDate);
        }

    }

    // Class for computers, inherits Device class

    [Serializable]
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
            Console.WriteLine();
            Console.WriteLine("Tabletin erityitiedot");
            Console.WriteLine("---------------------");
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
            // Määritellään binääridatan muodostaja serialisointia varten
            IFormatter formatter = new BinaryFormatter();

            // Määritellään file stream tietokoneiden tietojen tallennusta vektorimuotoa varten -> huono ratkaisu
            Stream writeStream = new FileStream("ComputerData.dat", FileMode.Create, FileAccess.Write);

            // Määritelläänn toinen file streampinotallennusta varten
            Stream stackWriteStream = new FileStream("ComputerStack.dat", FileMode.Create, FileAccess.Write);


            // Luodaan vektorit ja laskurit niiden alkioille
            Computer[] computers = new Computer[10];
            Tablet[] tablets = new Tablet[10];
            int numberOfComputers = 0;
            int numberOfTablets = 0;

            // Vaihtoehtoisesti luodaan pinot laitteille
            Stack<Computer> computerStack = new Stack<Computer>();

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
                        Console.Write("Ostopäivä muodossa vvvv-kk-pp: ");
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
                            break;
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
                            break;
                        }

                        Console.Write("Tallennuskapasiteetti (GB): ");
                        string storageCapacity = Console.ReadLine();

                        try
                        {
                            computer.StorageCapacity = int.Parse(storageCapacity);
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Virheellinen tallennustilan koko, vain kokonaisluvut sallittu " + ex.Message);
                            break;
                        }

                        Console.Write("Käyttöjärjestelmä: ");
                        computer.OperatingSystem = Console.ReadLine();

                        // Näytetään olion tiedot metodien avulla
                        computer.ShowPurchaseInfo();
                        computer.ShowBasicTechnicalInfo();

                        try
                        {
                            computer.CalculateWarrantyEndingDate();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ostopäivä virheellinen " + ex.Message);
                            break;
                        }

                        // Lisätään tietokone vektoriin
                        computers[numberOfComputers] = computer;
                        Console.WriteLine("Vektorin indeksi on nyt " + numberOfComputers);
                        numberOfComputers++;
                        Console.WriteLine("Nyt syötettiin " + numberOfComputers + ". kone");

                        // Vaihtoehtoisesti lisätään tietokone pinoon
                        computerStack.Push(computer);

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
                    // Vektorissa on se määrä alkioita, jotka sille on alustuvaiheessa annettu
                    Console.WriteLine("Tietokonevektorissa on " + computers.Length + " alkiota");

                    Console.WriteLine("Pinossa on nyt " + computerStack.Count + " tietokonetta");

                    // Tallennetaan koneiden tiedot vektorina tiedostoon serialisoimalla
                    formatter.Serialize(writeStream, computers);
                    writeStream.Close();

                    // Tallennetaan koneiden tiedot pinomuodossa tiedostoon
                    formatter.Serialize(stackWriteStream, computerStack);
                    stackWriteStream.Close();

                 

                    // Määritellään file stream tietokoneiden tietojen lukemista varten
                   Stream readStream = new FileStream("ComputerData.dat", FileMode.Open, FileAccess.Read);

                    Computer[] savedComputers;

                    savedComputers = (Computer[]formatter.Deserialize(readStream);

                    readStream.Close();

                    Stream readStackStream = new FileStream("ComputerStack.dat", FileMode.Open, FileAccess.Read);

                    Stack<Computer> savedStack;
                    savedStack = (Stack<Computer>)formatter.Deserialize(readStackStream);
                    readStackStream.Close();

                    // Tulostetaan ruudulle tallennetun ensimmäisen koneen nimi
                    Console.WriteLine("Levylle on tallennettu " + savedComputers.Length + "koneen tiedot");
                    Console.WriteLine(savedComputers[0].Name);
                    savedComputers[0].CalculateWarrantyEndingDate();

                    // Jos luetaan indeksi, jossa koneen tiedot puuttuvat (null) sovellus kaatuu -> vektorin käyttö ei ole järkevää

                    // Pinoon tallennetaan vain todellisuudessa syötetyt koneet, voidaan lukea koko pino silmukassa

                    foreach (var item in savedStack)
                    {
                        Console.WriteLine("Koneen " + item.Name + " takuu päättyy");
                        item.CalculateWarrantyEndingDate();
                    }

                    break;
                }
            }


            // Leave window open until enter is pushed
            Console.ReadLine();
        }
    }
}