using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutingChallenge
{
    class ProgramUI
    {
        OutingRepository _outingRepo = new OutingRepository();
        public void Run()
        {
            SeedOutings();
            RunMenu();
        }
        public void SeedOutings()
        {
            Outing outingOne = new Outing(Outing.OutingType.AmusementPark, 12, new DateTime(2019, 07, 20), 33.72);
            Outing outingTwo = new Outing(Outing.OutingType.Concert, 23, new DateTime(2019, 11, 16), 21.12);
            _outingRepo.AddToDirectory(outingOne);
            _outingRepo.AddToDirectory(outingTwo);
        }
        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Please select a number.\n" +
                    "1. Show all outings.\n" +
                    "2. Add outing.\n" +
                    "3. Calculate costs.\n" +
                    "4. Exit\n\n");
                string response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        Console.Clear();
                        _outingRepo.ShowAllOutings();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        bool wasAdded = AddOuting();
                        if(wasAdded)
                        { Console.WriteLine("Outing added"); }
                        else { Console.WriteLine("Unable to add. Please try again"); }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        Calculations();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public bool AddOuting()
        {
            Outing newOuting = new Outing();
            newOuting.Type = newOuting.GetOutingType();
            Console.Write("How many people attended? ");
            newOuting.NumberAttended = Convert.ToInt32(Console.ReadLine());
            Console.Write("When was this event (Month date year)? ");
            newOuting.EventDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("What was the cost per person (XX.XX): ");
            newOuting.CostPerPerson = Convert.ToDouble(Console.ReadLine());
            return _outingRepo.AddToDirectory(newOuting);
        }
        public void Calculations()
        {
            Console.WriteLine("What would you like to calculate? Please select a number:\n" +
                "1. Total cost by type\n" +
                "2. Total cost of all outings\n" +
                "3. Exit\n\n");
            string response = Console.ReadLine();
            bool incorrectResponse = true;
            while(incorrectResponse)
            {
                switch(response)
                {
                    case "1":
                        incorrectResponse = false;
                        Console.Clear();
                        Outing newOuting = new Outing();
                        Console.WriteLine(_outingRepo.GetTotalCostByType(newOuting.GetOutingType()));
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "2":
                        incorrectResponse = false;
                        Console.Clear();
                        Console.WriteLine(_outingRepo.GetTotalCost());
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "3":
                        incorrectResponse = false;
                        Console.Clear();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
