using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Runtime.Versioning;

namespace PresidentAtDate.Common.InputContainers
{
    [SupportedOSPlatform("windows")]
    class ExcelOleDbTermpInputContainer : ITermInputContainer
    {
        private const string PATH = @"Data\Presidents.xlsx";
        private const string CONNECTION_STRING = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + PATH + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";

        public List<Term> LoadTerms()
        {
            List<Term> termList = new List<Term>();

            President presidentBeingParsed;
            List<Term> currentPresidentTermList;
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                connection.Open();

                OleDbCommand rowCountCommand = new OleDbCommand("SELECT COUNT(*) from [Sheet1$]", connection);
                int rowCount = (int) rowCountCommand.ExecuteScalar();

                OleDbCommand command = new OleDbCommand("SELECT * FROM [Sheet1$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        presidentBeingParsed = new President();
                        currentPresidentTermList = new List<Term>();

                        int colCount = dr.FieldCount;
                        if(RowIsEmpty(dr, colCount))
                        {
                            break;
                        }

                        for (int i = 0; i < colCount; i++)
                        {
                            string currentValue = dr[i].ToString();
                            switch ((PresidentDataColumn) i)
                            {
                                case PresidentDataColumn.Name:
                                    if (!string.IsNullOrEmpty(currentValue))
                                    {
                                        presidentBeingParsed.Name = currentValue;
                                    }
                                    else
                                    {
                                        throw new Exception("President name cannnot be null.");
                                    }
                                    break;
                                case PresidentDataColumn.Terms:
                                    if (!string.IsNullOrEmpty(currentValue))
                                    {
                                        currentPresidentTermList = ParseExcelTermStringToTermList(currentValue);
                                    }
                                    else
                                    {
                                        throw new Exception("President terms cannot be null.");
                                    }
                                    break;
                                case PresidentDataColumn.Born:
                                    if (!string.IsNullOrEmpty(currentValue))
                                    {
                                        presidentBeingParsed.BirthDate = Convert.ToDateTime(currentValue);
                                    }
                                    else
                                    {
                                        throw new Exception("President birth date cannnot be null.");
                                    }
                                    break;
                                case PresidentDataColumn.Died:
                                    if (!string.IsNullOrEmpty(currentValue))
                                    {
                                        presidentBeingParsed.DeathDate = Convert.ToDateTime(currentValue);
                                    }
                                    else
                                    {
                                        // President death date can be null if they are still alive
                                        presidentBeingParsed.DeathDate = null;
                                    }
                                    break;
                                case PresidentDataColumn.Party:
                                    if (!string.IsNullOrEmpty(currentValue))
                                    {
                                        presidentBeingParsed.PoliticalAffiliation = (PoliticalAffiliation)EnumUtil.GetEnumFromDescription(typeof(PoliticalAffiliation), currentValue);
                                    }
                                    else
                                    {
                                        presidentBeingParsed.PoliticalAffiliation = PoliticalAffiliation.None;
                                    }
                                    break;
                            }
                        }

                        foreach (Term t in currentPresidentTermList)
                        {
                            t.TermPresident = presidentBeingParsed;
                        }

                        termList.AddRange(currentPresidentTermList);
                    }
                }
            }

            return termList;
        }

        private bool RowIsEmpty(OleDbDataReader dr, int numberOfColumns)
        {
            bool isEmpty = true;
            for (int i = 0; i < numberOfColumns; i++)
            {
                if (!string.IsNullOrEmpty(dr[i].ToString()))
                {
                    return false;
                }
            }
            return isEmpty;
        }

        private List<Term> ParseExcelTermStringToTermList(string excelTermString)
        {
            List<Term> termList = new List<Term>();
            Term t;

            string[] stringTerms = excelTermString.Split(',');
            foreach (string stringTerm in stringTerms)
            {
                t = null;

                string[] stringDates = stringTerm.Split('-');
                if (stringDates.Length > 2 || stringDates.Length < 1)
                {
                    throw new FormatException("Invalid term string format.");
                }

                if (stringDates[1] == "")
                {
                    // if the President is still in office the last term will not have an end date
                    t = new Term(Convert.ToDateTime(stringDates[0]), null);
                }
                else
                {
                    t = new Term(Convert.ToDateTime(stringDates[0]), Convert.ToDateTime(stringDates[1]));
                }

                termList.Add(t);
            }

            return termList;
        }
    }
}
