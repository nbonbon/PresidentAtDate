using System;
using System.Collections.Generic;

namespace PresidentAtDate
{
    public class President
    {
        public string name { get; set; }
        public DateTime birthDate { get; set; }
        public DateTime? deathDate { get; set; }
        public PoliticalAffiliation politicalAffiliation { get; set; }
        public List<int> presidentNumbers { get; set; }
        public string imageUri
        {
            get
            {
                // picture is numbered for first term
                return "p" + presidentNumbers[0];
            }
        }

        public President()
        {
            presidentNumbers = new List<int>();
        }
    }
}
