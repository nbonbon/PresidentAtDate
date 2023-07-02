using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace PresidentAtDate
{
    class ExcelInteropTermInputContainer : ITermInputContainer
    {
        //private const string presidentWorkbookFileName = "pack://application:,,,/Data/Presidents.xls";
        private const string presidentWorkbookFileName = @"C:\Users\1108157\Documents\Visual Studio 2015\Projects\PresidentAtDate\PresidentAtDate\Data\Presidents.xlsx";

        public List<Term> loadTerms()
        {
            List<Term> termList = new List<Term>();
            List<Term> currentPresidentTermList;

            President presidentBeingParsed;

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(presidentWorkbookFileName, Type.Missing, true);
            Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            
            // Ensures that formatting changes in 'empty' cells will not count as a cell being occupied
            xlWorksheet.Columns.ClearFormats();
            xlWorksheet.Rows.ClearFormats();

            Excel.Range xlRange = (Excel.Range)xlWorksheet.UsedRange;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            //Object[,] xlPresidentValues = (Object[,])xlWorksheet.Range[xlWorksheet.Cells[rowDataStart, colDataStart], xlWorksheet.Cells[rowCount, colCount]].Cells.Value2;

            // Start at 2 because the first row is the header row (and Excel indexing is NOT zero based)
            for (int i = 2; i <= rowCount; i++)
            {
                presidentBeingParsed = new President();
                currentPresidentTermList = new List<Term>();

                for (int j = 1; j <= colCount; j++)
                {
                    switch ((PresidentDataColumn)j)
                    {
                        case PresidentDataColumn.Name:
                            if (xlRange.Cells[i, j].Text != "")
                            {
                                presidentBeingParsed.name = xlRange.Cells[i, j].Text;
                            }
                            else
                            {
                                throw new Exception("President name cannnot be null.");
                            }
                            break;
                        case PresidentDataColumn.Terms:
                            if (xlRange.Cells[i, j].Text != "")
                            {
                                currentPresidentTermList = parseExcelTermStringToTermList(xlRange.Cells[i, j].Text);
                            }
                            else
                            {
                                throw new Exception("President terms cannot be null.");
                            }
                            break;
                        case PresidentDataColumn.Born:
                            if (xlRange.Cells[i, j].Text != "")
                            {
                                //string temp = (string) xlPresidentValues[i, j];
                                presidentBeingParsed.birthDate = Convert.ToDateTime(xlRange.Cells[i, j].Text);
                            }
                            else
                            {
                                throw new Exception("President birth date cannnot be null.");
                            }
                            break;
                        case PresidentDataColumn.Died:
                            if (xlRange.Cells[i, j].Text != "")
                            {
                                presidentBeingParsed.deathDate = Convert.ToDateTime(xlRange.Cells[i, j].Text);
                            }
                            else
                            {
                                // President death date can be null if they are still alive
                                presidentBeingParsed.deathDate = null;
                            }
                            break;
                        case PresidentDataColumn.Party:
                            if (xlRange.Cells[i, j].Text != "")
                            {
                                presidentBeingParsed.politicalAffiliation = (PoliticalAffiliation) EnumUtil.GetEnumFromDescription(typeof(PoliticalAffiliation), xlRange.Cells[i, j].Text);
                            }
                            else
                            {
                                presidentBeingParsed.politicalAffiliation = PoliticalAffiliation.None;
                            }
                            break;
                    }
                }

                foreach (Term t in currentPresidentTermList)
                {
                    t.termPresident = presidentBeingParsed;
                }

                // Add currentPresidentTermList to termList
                termList.AddRange(currentPresidentTermList);
            }

            // Cleanup of interop objects
            GC.Collect();
            GC.WaitForPendingFinalizers();

            xlWorkbook.Close(false, null, null);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);
            Marshal.ReleaseComObject(xlWorkbook);
            Marshal.ReleaseComObject(xlApp);

            return termList;
        }

        private List<Term> parseExcelTermStringToTermList(string excelTermString)
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
