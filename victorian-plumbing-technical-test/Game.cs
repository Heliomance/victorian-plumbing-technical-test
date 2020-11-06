using Org.Openaq.Ap.Openaq.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace confirma_pay_technical_test
{
    class Game
    {
        private Random r;

        private List<ICountry> countries;
        private List<ILocation> locations;

        private Dictionary<char, int> guessDict = new Dictionary<char, int> {{'1', 0}, {'2', 1}};

        public Game(List<ICountry> countries, List<ILocation> locations)
        {
            r = new Random();
            this.countries = countries;
            this.locations = locations;
        }

        public bool Play()
        {
            var targets = GetNextTargets();
            // TODO: Pick a particular parameter that exists on both locations
            Console.WriteLine("Which do you think has the better air quality?");
            Console.WriteLine(
                $"(1): {targets[0].Locations}, {targets[0].City}, {countries.Find(c => c.Code == targets[0].Country).Name}");
            Console.WriteLine(
                $"(2): {targets[1].Locations}, {targets[1].City}, {countries.Find(c => c.Code == targets[1].Country).Name}");

            char response = Utils.GetInput(guessDict.Keys.ToArray());

            // TODO: Get the values of a particular parameter from the two chosen locations to compare. Replace this r.Next with an actual comparison
            if (r.Next(0, 2) > 0)
            {
                Console.WriteLine("Congratulations!");
                return true;
            }

            Console.WriteLine("Uh-oh! Unfortunately, you were wrong - you lose!");
            return false;
        }

        private ILocation[] GetNextTargets()
        {
            int i, j;
            i = r.Next(1, locations.Count + 1);
            do
            {
                j = r.Next(1, locations.Count + 1);
            } while (i == j);

            return new[] {locations[i], locations[j]};
        }
    }
}