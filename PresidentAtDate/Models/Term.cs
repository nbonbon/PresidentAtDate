using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace PresidentAtDate
{
    public class Term : IComparable<Term>
    {
        public int Number { get; set; }
        public Portrait TermPortrait { get; set; }
        public President TermPresident { get; set; }
        public DateTime StartDateInOffice { get; set; }
        public DateTime? EndDateInOffice { get; set; }
        public PoliticalAffiliation[] PoliticalAffiliations { get; set; }
        public String[] VicePresidents { get; set; }
        public String[] ElectionYears { get; set; }

        public Term() { }

        public Term(DateTime startDate, DateTime? endDate)
        {
            this.StartDateInOffice = startDate;
            this.EndDateInOffice = endDate;
        }

        public Term(DateTime startDate, DateTime? endDate, President president)
        {
            this.StartDateInOffice = startDate;
            this.EndDateInOffice = endDate;
            this.TermPresident = president;
        }

        internal bool isInRange(DateTime dateToTest)
        {
            bool result = false;

            if (this.EndDateInOffice == null)
            {
                result = dateToTest >= StartDateInOffice;
            }
            else
            {
                result = StartDateInOffice <= dateToTest && EndDateInOffice >= dateToTest;
            }

            return result;
        }

        public int CompareTo(Term other)
        {
            return StartDateInOffice.CompareTo(other.StartDateInOffice);
        }
    }
}