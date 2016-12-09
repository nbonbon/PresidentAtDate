using System;

namespace PresidentAtDate
{
    public class Term : IComparable<Term>
    {
        public President termPresident { get; set; }
        public DateTime startDateInOffice { get; set; }
        public DateTime? endDateInOffice { get; set; }

        public Term(DateTime startDate, DateTime? endDate)
        {
            this.startDateInOffice = startDate;
            this.endDateInOffice = endDate;
        }

        public Term(DateTime startDate, DateTime? endDate, President president)
        {
            this.startDateInOffice = startDate;
            this.endDateInOffice = endDate;
            this.termPresident = president;
        }

        internal bool isInRange(DateTime dateToTest)
        {
            bool result = false;

            if (this.endDateInOffice == null)
            {
                result = dateToTest >= startDateInOffice;
            }
            else
            {
                result = startDateInOffice <= dateToTest && endDateInOffice >= dateToTest;
            }

            return result;
        }

        public int CompareTo(Term other)
        {
            return startDateInOffice.CompareTo(other.startDateInOffice);
        }
    }
}