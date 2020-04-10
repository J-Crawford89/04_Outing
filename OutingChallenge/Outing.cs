using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutingChallenge
{
    public class Outing
    {
        public enum OutingType { Golf, Bowling, AmusementPark, Concert };
        public OutingType Type { get; set; }
        public int NumberAttended { get; set; }
        public DateTime EventDate { get; set; }
        public double CostPerPerson { get; set; }
        public double TotalCost => CostPerPerson * NumberAttended;
        public Outing() { }
        public Outing(OutingType type, int numberAttended, DateTime eventDate, double costPerPerson)
        {
            Type = type;
            NumberAttended = numberAttended;
            EventDate = eventDate;
            CostPerPerson = costPerPerson;
        }
        public OutingType GetOutingType()
        {
            Console.Clear();
            bool invalidResponse = true;
            while (invalidResponse)
            {
                Console.Write("Enter outing type (golf, bowling, amusement park, concert): ");
                string response = Console.ReadLine().ToLower();
                switch(response)
                {
                    case "golf":
                        return OutingType.Golf;
                    case "bowling":
                        return OutingType.Bowling;
                    case "concert":
                        return OutingType.Concert;
                    case "amusement park":
                    case "amusementpark":
                    case "amusement":
                    case "park":
                        return OutingType.AmusementPark;
                    default:
                        break;
                }
            }
            return OutingType.Golf;
        }
    }
}
