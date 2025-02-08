using System;
using System.Collections.Generic;

namespace PresidentAtDate
{
    class StaticTermInputContainer : ITermInputContainer
    {
        public List<Term> LoadTerms()
        {
            List<Term> termList = new List<Term>();
            President p;
            Term t;

            // 1st President
            p = new President();
            p.Name = "George Washington";
            p.BirthDate = new DateTime(1732, 2, 22);
            p.DeathDate = new DateTime(1799, 12, 14);
            p.PoliticalAffiliation = PoliticalAffiliation.None;
            t = new Term(new DateTime(1789, 4, 30), new DateTime(1797, 3, 4), p);
            termList.Add(t);

            // 2nd President
            p = new President();
            p.Name = "John Adams";
            p.BirthDate = new DateTime(1735, 10, 30);
            p.DeathDate = new DateTime(1826, 7, 4);
            p.PoliticalAffiliation = PoliticalAffiliation.Federalist;
            t = new Term(new DateTime(1797, 3, 4), new DateTime(1801, 3, 4), p);
            termList.Add(t);

            // 3rd President
            p = new President();
            p.Name = "Thomas Jefferson";
            p.BirthDate = new DateTime(1743, 4, 13);
            p.DeathDate = new DateTime(1826, 7, 4);
            p.PoliticalAffiliation = PoliticalAffiliation.Federalist;
            t = new Term(new DateTime(1801, 3, 4), new DateTime(1809, 3, 4), p);
            termList.Add(t);

            // 4th President
            p = new President();
            p.Name = "James Madison";
            p.BirthDate = new DateTime(1751, 3, 16);
            p.DeathDate = new DateTime(1836, 6, 28);
            p.PoliticalAffiliation = PoliticalAffiliation.DemocraticRepublican;
            t = new Term(new DateTime(1809, 3, 4), new DateTime(1817, 3, 4), p);
            termList.Add(t);

            // 5th President
            p = new President();
            p.Name = "James Monroe";
            p.BirthDate = new DateTime(1758, 4, 28);
            p.DeathDate = new DateTime(1831, 7, 4);
            p.PoliticalAffiliation = PoliticalAffiliation.DemocraticRepublican;
            t = new Term(new DateTime(1817, 3, 4), new DateTime(1825, 3, 4), p);
            termList.Add(t);

            // 6th President
            p = new President();
            p.Name = "John Quincy Adams";
            p.BirthDate = new DateTime(1767, 7, 11);
            p.DeathDate = new DateTime(1848, 2, 23);
            p.PoliticalAffiliation = PoliticalAffiliation.Federalist;
            t = new Term(new DateTime(1825, 3, 4), new DateTime(1829, 3, 4), p);
            termList.Add(t);

            // 7th President
            p = new President();
            p.Name = "Andrew Jackson";
            p.BirthDate = new DateTime(1767, 3, 15);
            p.DeathDate = new DateTime(1845, 6, 8);
            p.PoliticalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1829, 3, 4), new DateTime(1837, 3, 4), p);
            termList.Add(t);

            // 8th President
            p = new President();
            p.Name = "Martin Van Buren";
            p.BirthDate = new DateTime(1782, 12, 5);
            p.DeathDate = new DateTime(1862, 7, 24);
            p.PoliticalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1837, 3, 4), new DateTime(1841, 3, 4), p);
            termList.Add(t);

            // 9th President
            p = new President();
            p.Name = "William Henry Harrison";
            p.BirthDate = new DateTime(1773, 2, 9);
            p.DeathDate = new DateTime(1841, 4, 4);
            p.PoliticalAffiliation = PoliticalAffiliation.Whig;
            t = new Term(new DateTime(1841, 3, 4), new DateTime(1841, 4, 4), p);
            termList.Add(t);

            // 10th President
            p = new President();
            p.Name = "John Tyler";
            p.BirthDate = new DateTime(1790, 3, 29);
            p.DeathDate = new DateTime(1862, 1, 18);
            p.PoliticalAffiliation = PoliticalAffiliation.Whig;
            t = new Term(new DateTime(1841, 4, 4), new DateTime(1845, 3, 4), p);
            termList.Add(t);

            // 11th President
            p = new President();
            p.Name = "James K. Polk";
            p.BirthDate = new DateTime(1795, 11, 2);
            p.DeathDate = new DateTime(1849, 6, 15);
            p.PoliticalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1845, 3, 4), new DateTime(1849, 3, 4), p);
            termList.Add(t);

            // 12th President
            p = new President();
            p.Name = "Zachary Taylor";
            p.BirthDate = new DateTime(1784, 11, 24);
            p.DeathDate = new DateTime(1850, 7, 9);
            p.PoliticalAffiliation = PoliticalAffiliation.Whig;
            t = new Term(new DateTime(1849, 3, 4), new DateTime(1850, 7, 9), p);
            termList.Add(t);

            // 13th President
            p = new President();
            p.Name = "Millard Fillmore";
            p.BirthDate = new DateTime(1800, 1, 7);
            p.DeathDate = new DateTime(1874, 3, 8);
            p.PoliticalAffiliation = PoliticalAffiliation.Whig;
            t = new Term(new DateTime(1850, 7, 9), new DateTime(1853, 3, 4), p);
            termList.Add(t);

            // 14th President
            p = new President();
            p.Name = "Franklin Pierce";
            p.BirthDate = new DateTime(1804, 11, 23);
            p.DeathDate = new DateTime(1869, 10, 8);
            p.PoliticalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1853, 3, 4), new DateTime(1857, 3, 4), p);
            termList.Add(t);

            // 15th President
            p = new President();
            p.Name = "James Buchanan";
            p.BirthDate = new DateTime(1791, 4, 23);
            p.DeathDate = new DateTime(1868, 6, 1);
            p.PoliticalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1857, 3, 4), new DateTime(1861, 3, 4), p);
            termList.Add(t);

            // 16th President
            p = new President();
            p.Name = "Abraham Lincoln";
            p.BirthDate = new DateTime(1809, 2, 12);
            p.DeathDate = new DateTime(1865, 4, 15);
            p.PoliticalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1861, 3, 4), new DateTime(1865, 4, 15), p);
            termList.Add(t);

            // 17th President
            p = new President();
            p.Name = "Andrew Johnson";
            p.BirthDate = new DateTime(1808, 12, 29);
            p.DeathDate = new DateTime(1875, 7, 31);
            p.PoliticalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1865, 4, 15), new DateTime(1869, 3, 4), p);
            termList.Add(t);

            // 18th President
            p = new President();
            p.Name = "Ulysses S. Grant";
            p.BirthDate = new DateTime(1822, 4, 7);
            p.DeathDate = new DateTime(1885, 7, 23);
            p.PoliticalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1869, 3, 4), new DateTime(1877, 3, 4), p);
            termList.Add(t);

            // 19th President
            p = new President();
            p.Name = "Rutherford B. Hayes";
            p.BirthDate = new DateTime(1822, 10, 4);
            p.DeathDate = new DateTime(1893, 1, 7);
            p.PoliticalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1877, 3, 4), new DateTime(1881, 3, 4), p);
            termList.Add(t);

            // 20th President
            p = new President();
            p.Name = "James A. Garfield";
            p.BirthDate = new DateTime(1831, 11, 19);
            p.DeathDate = new DateTime(1881, 9, 19);
            p.PoliticalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1881, 3, 4), new DateTime(1881, 9, 19), p);
            termList.Add(t);

            // 21th President
            p = new President();
            p.Name = "Chester A. Arthur";
            p.BirthDate = new DateTime(1829, 10, 5);
            p.DeathDate = new DateTime(1886, 11, 18);
            p.PoliticalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1881, 9, 19), new DateTime(1885, 3, 4), p);
            termList.Add(t);

            // 22nd President
            p = new President();
            p.Name = "Grover Cleveland";
            p.BirthDate = new DateTime(1837, 3, 18);
            p.DeathDate = new DateTime(1908, 6, 24);
            p.PoliticalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1885, 3, 4), new DateTime(1889, 3, 4), p);
            termList.Add(t);
            t = new Term(new DateTime(1893, 3, 4), new DateTime(1897, 3, 4), p);
            termList.Add(t);

            // 23rd President
            p = new President();
            p.Name = "Benjamin Harrison";
            p.BirthDate = new DateTime(1833, 8, 20);
            p.DeathDate = new DateTime(1901, 3, 13);
            p.PoliticalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1889, 3, 4), new DateTime(1833, 3, 4), p);
            termList.Add(t);

            // 25th President
            p = new President();
            p.Name = "William McKinley";
            p.BirthDate = new DateTime(1843, 1, 29);
            p.DeathDate = new DateTime(1901, 9, 14);
            p.PoliticalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1897, 3, 4), new DateTime(1901, 9, 14), p);
            termList.Add(t);

            // 26th President
            p = new President();
            p.Name = "Theodore Roosevelt";
            p.BirthDate = new DateTime(1858, 10, 27);
            p.DeathDate = new DateTime(1919, 1, 6);
            p.PoliticalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1901, 9, 14), new DateTime(1909, 3, 4), p);
            termList.Add(t);

            // 27th President
            p = new President();
            p.Name = "William Howard Taft";
            p.BirthDate = new DateTime(1857, 9, 15);
            p.DeathDate = new DateTime(1930, 3, 8);
            p.PoliticalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1909, 3, 4), new DateTime(1913, 3, 4), p);
            termList.Add(t);

            // 28th President
            p = new President();
            p.Name = "Woodrow Wilson";
            p.BirthDate = new DateTime(1856, 12, 28);
            p.DeathDate = new DateTime(1924, 2, 3);
            p.PoliticalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1913, 3, 4), new DateTime(1921, 3, 4), p);
            termList.Add(t);

            // 29th President
            p = new President();
            p.Name = "Warren G. Harding";
            p.BirthDate = new DateTime(1865, 11, 2);
            p.DeathDate = new DateTime(1923, 8, 3);
            p.PoliticalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1921, 3, 4), new DateTime(1923, 8, 2), p);
            termList.Add(t);

            // 30th President
            p = new President();
            p.Name = "Calvin Coolidge";
            p.BirthDate = new DateTime(1872, 7, 4);
            p.DeathDate = new DateTime(1933, 1, 5);
            p.PoliticalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1923, 8, 2), new DateTime(1929, 3, 4), p);
            termList.Add(t);

            // 31st President
            p = new President();
            p.Name = "Herbert Hoover";
            p.BirthDate = new DateTime(1874, 8, 10);
            p.DeathDate = new DateTime(1964, 10, 20);
            p.PoliticalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1929, 3, 4), new DateTime(1933, 3, 4), p);
            termList.Add(t);

            // 31st President
            p = new President();
            p.Name = "Herbert Hoover";
            p.BirthDate = new DateTime(1874, 8, 10);
            p.DeathDate = new DateTime(1964, 10, 20);
            p.PoliticalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1929, 3, 4), new DateTime(1933, 3, 4), p);
            termList.Add(t);

            // 32nd President
            p = new President();
            p.Name = "Franklin D. Roosevelt";
            p.BirthDate = new DateTime(1882, 1, 30);
            p.DeathDate = new DateTime(1845, 4, 12);
            p.PoliticalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1933, 3, 4), new DateTime(1945, 4, 12), p);
            termList.Add(t);

            // 33rd President
            p = new President();
            p.Name = "Harry S. Truman";
            p.BirthDate = new DateTime(1884, 5, 8);
            p.DeathDate = new DateTime(1972, 12, 26);
            p.PoliticalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1945, 4, 12), new DateTime(1953, 1, 20), p);
            termList.Add(t);

            // 34th President
            p = new President();
            p.Name = "Dwight D. Eisenhower";
            p.BirthDate = new DateTime(1890, 10, 14);
            p.DeathDate = new DateTime(1969, 3, 28);
            p.PoliticalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1953, 1, 20), new DateTime(1961, 1, 20), p);
            termList.Add(t);

            // 35th President
            p = new President();
            p.Name = "John F. Kennedy";
            p.BirthDate = new DateTime(1917, 5, 29);
            p.DeathDate = new DateTime(1963, 11, 22);
            p.PoliticalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1961, 1, 20), new DateTime(1963, 11, 22), p);
            termList.Add(t);

            // 36th President
            p = new President();
            p.Name = "Lyndon B. Johnson";
            p.BirthDate = new DateTime(1908, 8, 27);
            p.DeathDate = new DateTime(1973, 1, 22);
            p.PoliticalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1963, 11, 22), new DateTime(1969, 1, 20), p);
            termList.Add(t);

            // 37th President
            p = new President();
            p.Name = "Richard Nixon";
            p.BirthDate = new DateTime(1913, 1, 9);
            p.DeathDate = new DateTime(1994, 4, 22);
            p.PoliticalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1969, 1, 20), new DateTime(1974, 8, 9), p);
            termList.Add(t);

            // 38th President
            p = new President();
            p.Name = "Gerald Ford";
            p.BirthDate = new DateTime(1913, 7, 14);
            p.DeathDate = new DateTime(2006, 12, 26);
            p.PoliticalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1974, 8, 9), new DateTime(1977, 1, 20), p);
            termList.Add(t);

            // 39th President
            p = new President();
            p.Name = "Jimmy Carter";
            p.BirthDate = new DateTime(1924, 10, 1);
            p.DeathDate = null;
            p.PoliticalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1977, 1, 20), new DateTime(1881, 1, 20), p);
            termList.Add(t);

            // 40th President
            p = new President();
            p.Name = "Ronald Reagan";
            p.BirthDate = new DateTime(1911, 2, 6);
            p.DeathDate = new DateTime(2004, 6, 5);
            p.PoliticalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1981, 1, 20), new DateTime(1989, 1, 20), p);
            termList.Add(t);

            // 41st President
            p = new President();
            p.Name = "George H.W. Bush";
            p.BirthDate = new DateTime(1924, 6, 12);
            p.DeathDate = null;
            p.PoliticalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1989, 1, 20), new DateTime(1993, 1, 20), p);
            termList.Add(t);

            // 42nd President
            p = new President();
            p.Name = "Bill Clinton";
            p.BirthDate = new DateTime(1946, 8, 19);
            p.DeathDate = null;
            p.PoliticalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1993, 1, 20), new DateTime(2001, 1, 20), p);
            termList.Add(t);

            // 43rd President
            p = new President();
            p.Name = "George W. Bush";
            p.BirthDate = new DateTime(1946, 7, 6);
            p.DeathDate = null;
            p.PoliticalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(2001, 1, 20), new DateTime(2009, 1, 20), p);
            termList.Add(t);

            // 44th President
            p = new President();
            p.Name = "Barack Obama";
            p.BirthDate = new DateTime(1961, 8, 4);
            p.DeathDate = null;
            p.PoliticalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(2009, 1, 20), null, p);
            termList.Add(t);

            return termList;
        }
    }
}
