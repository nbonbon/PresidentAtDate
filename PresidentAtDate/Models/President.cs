using System;
using System.Collections.Generic;

namespace PresidentAtDate
{
    public class President
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public PoliticalAffiliation PoliticalAffiliation { get; set; }
        public List<int> PresidentNumbers { get; set; }
        public string imageUri
        {
            get
            {
                // picture is numbered for first term
                return "p" + PresidentNumbers[0];
            }
        }

        public President()
        {
            PresidentNumbers = new List<int>();
        }
    }
}
