using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OutingChallenge.Outing;

namespace OutingChallenge
{
    public class OutingRepository
    {
        private List<Outing> _outingDirectory = new List<Outing>();
        public void ShowAllOutings()
        {
            Console.WriteLine($"{"Outing Type", -14}|{"Number Attended", -16}|{"Date", -11}|{"Cost Per Person", -16}|{"Total Cost", -11}\n" +
                $"------------------------------------------------------------------------");
            foreach(Outing outing in _outingDirectory)
            {
                Console.WriteLine($"{outing.Type, -14}|{outing.NumberAttended, -16}|{outing.EventDate.Date.ToString("d"), -11}|{outing.CostPerPerson, -16}|{outing.TotalCost, -11}");
            }
            Console.ReadLine();
        }
        public bool AddToDirectory(Outing outingToAdd)
        {
            int startingCount = _outingDirectory.Count;
            _outingDirectory.Add(outingToAdd);
            return startingCount < _outingDirectory.Count;
        }
        public double GetTotalCost()
        {
            double totalCost = 0.00;
            foreach(Outing outing in _outingDirectory)
            {
                totalCost += outing.TotalCost;
            }
            return totalCost;
        }
        public double GetTotalCostByType(OutingType type)
        {
            double totalCost = 0.00;
            foreach(Outing outing in _outingDirectory)
            {
                if(outing.Type == type)
                {
                    totalCost += outing.TotalCost;
                }
            }
            return totalCost;
        }
    }
}
