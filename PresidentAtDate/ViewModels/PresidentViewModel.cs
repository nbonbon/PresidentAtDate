using PresidentAtDate.Common.InputContainers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Versioning;
using System.Windows.Media.Imaging;

namespace PresidentAtDate.ViewModels
{
    [SupportedOSPlatform("windows")]
    class PresidentViewModel : INotifyPropertyChanged
    {
        private List<Term> termList = new List<Term>();

        private string presidentDescription = string.Empty;

        public string PresidentDescription
        {
            get
            {
                return presidentDescription;
            }
            set
            {
                presidentDescription = value;
                OnPropertyChanged(nameof(PresidentDescription));
            }
        }

        private BitmapImage presidentImage = null;
        public BitmapImage PresidentImage
        {
            get
            {
                return presidentImage;
            }
            set
            {
                presidentImage = value;
                OnPropertyChanged(nameof(PresidentImage));
            }
        }

        private DateTime? selectedDate;
        public DateTime? SelectedDate
        {
            get
            {
                return selectedDate;
            }
            set
            {
                selectedDate = value;
                GetApplicablePresident();
                OnPropertyChanged(nameof(SelectedDate));
            }
        }

        public PresidentViewModel()
        {
            // Set default date value to today
            selectedDate = DateTime.Now;

            PopulateTermList();
            CalculatePresidentialNumbers();

            // Default the president selection the current president
            UpdateDisplayedPresident(FindCurrentPresident());
            
        }

        /// <summary>
        /// Finds the current president of the USA. The current president will
        /// have a term will a null end date.
        /// </summary>
        /// <returns>The current President of the USA</returns>
        private President FindCurrentPresident()
        {
            President result = null;
            foreach (Term t in termList)
            {
                if (t.EndDateInOffice == null)
                {
                    result = t.TermPresident;
                }
            }
            return result;
        }

        /// <summary>
        /// Finds the president that was in office during the selected date. If the date is an
        /// inauagral date for one president and the last day in office for the other the President
        /// that it will find will be the president that was inaugarated on the selected date.
        /// </summary>
        private void GetApplicablePresident()
        {
            DateTime now = DateTime.Now;
            DateTime initial = new DateTime(1789, 4, 30);

            if (selectedDate > now)
            {
                PresidentDescription = "Selected date cannot be in the future.";
                PresidentImage = new BitmapImage(DetermineUri(null));
            }
            else if (selectedDate < initial)
            {
                PresidentDescription = "There was no President of the United States of America prior to " + initial.ToShortDateString() + ".";
                PresidentImage = new BitmapImage(DetermineUri(null));
            }
            else
            {
                foreach (Term t in termList)
                {
                    if (selectedDate.HasValue && t.isInRange(selectedDate.Value))
                    {
                        UpdateDisplayedPresident(t.TermPresident); ;
                    }
                }
            }
        }

        /// <summary>
        /// Create the President description to be displayed and determine the applicable Presidents image.
        /// </summary>
        /// <param name="p">The President to display</param>
        private void UpdateDisplayedPresident(President p)
        {
            // If the date selected was this presidents inaugral day mention that

            // Update text
            PresidentDescription = "Name: " + p.Name + Environment.NewLine;
            PresidentDescription += "Born: " + p.BirthDate.ToShortDateString() + Environment.NewLine;
            PresidentDescription += "Died: " + (p.DeathDate == null ? "Still living" : p.DeathDate.Value.ToShortDateString()) + Environment.NewLine;
            PresidentDescription += "Party: " + EnumUtil.GetEnumDescription(p.PoliticalAffiliation) + Environment.NewLine;
            PresidentDescription += "Presidential Number: " + DisplayPresidentalNumbers(p) + Environment.NewLine;

            // Update image
            PresidentImage = new BitmapImage(DetermineUri(p));
        }

        /// <summary>
        /// Creates the string that respresents the presidents term  number(s)
        /// </summary>
        /// <param name="p">President to determine the term numbers</param>
        /// <returns>String that respresents the presidents term  number(s)</returns>
        private string DisplayPresidentalNumbers(President p)
        {
            string result = "";
            foreach (int num in p.PresidentNumbers)
            {
                if (result == "")
                {
                    result = GetOrdinalStringFromInt(num);
                }
                else
                {
                    result += " and " + GetOrdinalStringFromInt(num);
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the ordinal string representation of the integer passed in.
        /// </summary>
        /// <param name="num">Number to determne ordinal string representation</param>
        /// <returns>Ordinal string representation of the integer passed in</returns>
        private string GetOrdinalStringFromInt(int num)
        {
            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }

            switch (num % 10)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }
        }

        /// <summary>
        /// Determines the Uri of the image for the President.
        /// </summary>
        /// <param name="p">President to find the image Uri of</param>
        /// <returns>The Uri of the President p</returns>
        private Uri DetermineUri(President p)
        {
            Uri uri;
            if (p == null)
            {
                uri = new Uri("pack://application:,,,/Images/us_flag.jpg");
            }
            else
            {
                uri = new Uri("pack://application:,,,/Images/" + p.imageUri + ".jpg");
            }
            return uri;
        }

        /// <summary>
        /// Loads in presidential data into the termList
        /// </summary>
        private void PopulateTermList()
        {
            ExcelOleDbTermpInputContainer inputContainer = new ExcelOleDbTermpInputContainer();
            termList = inputContainer.LoadTerms();
        }

        /// <summary>
        /// Calculates the presidential numbers of all the presidents
        /// </summary>
        private void CalculatePresidentialNumbers()
        {
            termList.Sort();

            for (int i = 0; i < termList.Count; i++)
            {
                termList[i].TermPresident.PresidentNumbers.Add(i + 1);
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
