using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _07_SoftUni_Party
{
    class SoftUniParty
    {
        static void Main(string[] args)
        {
            string reservationNr = Console.ReadLine();

            Dictionary<string, bool> listOfGuests = new Dictionary<string, bool>();
            Dictionary<string, bool> listOfGuestsVIP = new Dictionary<string, bool>();

            while (reservationNr != "PARTY")
            {
                if (char.IsDigit(reservationNr[0]))
                {
                    listOfGuestsVIP.Add(reservationNr, false);
                }
                else
                {
                    listOfGuests.Add(reservationNr, false);
                }
                
                reservationNr = Console.ReadLine();
            }

            string commingGuest = Console.ReadLine();
            while (commingGuest != "END")
            {
                if (listOfGuests.ContainsKey(commingGuest))
                {
                    listOfGuests[commingGuest] = true;
                }

                else if (listOfGuestsVIP.ContainsKey(commingGuest))
                {
                    listOfGuestsVIP[commingGuest] = true;
                }

                commingGuest = Console.ReadLine();
            }

            var notCameGuests = new List<string>();

            foreach (var vipGuest in listOfGuestsVIP.Where(x=> x.Value == false))
            {
                notCameGuests.Add(vipGuest.Key);
            }

            foreach (var guest in listOfGuests.Where(x => x.Value == false))
            {
                notCameGuests.Add(guest.Key);
            }

            Console.WriteLine(notCameGuests.Count());
            foreach (var guest in notCameGuests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}