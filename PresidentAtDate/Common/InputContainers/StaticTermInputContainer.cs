using System;
using System.Collections.Generic;

namespace PresidentAtDate
{
    class StaticTermInputContainer : ITermInputContainer
    {
        public List<Term> loadTerms()
        {
            List<Term> termList = new List<Term>();
            President p;
            Term t;

            // 1st President
            p = new President();
            p.name = "George Washington";
            p.birthDate = new DateTime(1732, 2, 22);
            p.deathDate = new DateTime(1799, 12, 14);
            p.politicalAffiliation = PoliticalAffiliation.None;
            t = new Term(new DateTime(1789, 4, 30), new DateTime(1797, 3, 4), p);
            termList.Add(t);

            // 2nd President
            p = new President();
            p.name = "John Adams";
            p.birthDate = new DateTime(1735, 10, 30);
            p.deathDate = new DateTime(1826, 7, 4);
            p.politicalAffiliation = PoliticalAffiliation.Federalist;
            t = new Term(new DateTime(1797, 3, 4), new DateTime(1801, 3, 4), p);
            termList.Add(t);

            // 3rd President
            p = new President();
            p.name = "Thomas Jefferson";
            p.birthDate = new DateTime(1743, 4, 13);
            p.deathDate = new DateTime(1826, 7, 4);
            p.politicalAffiliation = PoliticalAffiliation.Federalist;
            t = new Term(new DateTime(1801, 3, 4), new DateTime(1809, 3, 4), p);
            termList.Add(t);

            // 4th President
            p = new President();
            p.name = "James Madison";
            p.birthDate = new DateTime(1751, 3, 16);
            p.deathDate = new DateTime(1836, 6, 28);
            p.politicalAffiliation = PoliticalAffiliation.DemocraticRepublican;
            t = new Term(new DateTime(1809, 3, 4), new DateTime(1817, 3, 4), p);
            termList.Add(t);

            // 5th President
            p = new President();
            p.name = "James Monroe";
            p.birthDate = new DateTime(1758, 4, 28);
            p.deathDate = new DateTime(1831, 7, 4);
            p.politicalAffiliation = PoliticalAffiliation.DemocraticRepublican;
            t = new Term(new DateTime(1817, 3, 4), new DateTime(1825, 3, 4), p);
            termList.Add(t);

            // 6th President
            p = new President();
            p.name = "John Quincy Adams";
            p.birthDate = new DateTime(1767, 7, 11);
            p.deathDate = new DateTime(1848, 2, 23);
            p.politicalAffiliation = PoliticalAffiliation.Federalist;
            t = new Term(new DateTime(1825, 3, 4), new DateTime(1829, 3, 4), p);
            termList.Add(t);

            // 7th President
            p = new President();
            p.name = "Andrew Jackson";
            p.birthDate = new DateTime(1767, 3, 15);
            p.deathDate = new DateTime(1845, 6, 8);
            p.politicalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1829, 3, 4), new DateTime(1837, 3, 4), p);
            termList.Add(t);

            // 8th President
            p = new President();
            p.name = "Martin Van Buren";
            p.birthDate = new DateTime(1782, 12, 5);
            p.deathDate = new DateTime(1862, 7, 24);
            p.politicalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1837, 3, 4), new DateTime(1841, 3, 4), p);
            termList.Add(t);

            // 9th President
            p = new President();
            p.name = "William Henry Harrison";
            p.birthDate = new DateTime(1773, 2, 9);
            p.deathDate = new DateTime(1841, 4, 4);
            p.politicalAffiliation = PoliticalAffiliation.Whig;
            t = new Term(new DateTime(1841, 3, 4), new DateTime(1841, 4, 4), p);
            termList.Add(t);

            // 10th President
            p = new President();
            p.name = "John Tyler";
            p.birthDate = new DateTime(1790, 3, 29);
            p.deathDate = new DateTime(1862, 1, 18);
            p.politicalAffiliation = PoliticalAffiliation.Whig;
            t = new Term(new DateTime(1841, 4, 4), new DateTime(1845, 3, 4), p);
            termList.Add(t);

            // 11th President
            p = new President();
            p.name = "James K. Polk";
            p.birthDate = new DateTime(1795, 11, 2);
            p.deathDate = new DateTime(1849, 6, 15);
            p.politicalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1845, 3, 4), new DateTime(1849, 3, 4), p);
            termList.Add(t);

            // 12th President
            p = new President();
            p.name = "Zachary Taylor";
            p.birthDate = new DateTime(1784, 11, 24);
            p.deathDate = new DateTime(1850, 7, 9);
            p.politicalAffiliation = PoliticalAffiliation.Whig;
            t = new Term(new DateTime(1849, 3, 4), new DateTime(1850, 7, 9), p);
            termList.Add(t);

            // 13th President
            p = new President();
            p.name = "Millard Fillmore";
            p.birthDate = new DateTime(1800, 1, 7);
            p.deathDate = new DateTime(1874, 3, 8);
            p.politicalAffiliation = PoliticalAffiliation.Whig;
            t = new Term(new DateTime(1850, 7, 9), new DateTime(1853, 3, 4), p);
            termList.Add(t);

            // 14th President
            p = new President();
            p.name = "Franklin Pierce";
            p.birthDate = new DateTime(1804, 11, 23);
            p.deathDate = new DateTime(1869, 10, 8);
            p.politicalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1853, 3, 4), new DateTime(1857, 3, 4), p);
            termList.Add(t);

            // 15th President
            p = new President();
            p.name = "James Buchanan";
            p.birthDate = new DateTime(1791, 4, 23);
            p.deathDate = new DateTime(1868, 6, 1);
            p.politicalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1857, 3, 4), new DateTime(1861, 3, 4), p);
            termList.Add(t);

            // 16th President
            p = new President();
            p.name = "Abraham Lincoln";
            p.birthDate = new DateTime(1809, 2, 12);
            p.deathDate = new DateTime(1865, 4, 15);
            p.politicalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1861, 3, 4), new DateTime(1865, 4, 15), p);
            termList.Add(t);

            // 17th President
            p = new President();
            p.name = "Andrew Johnson";
            p.birthDate = new DateTime(1808, 12, 29);
            p.deathDate = new DateTime(1875, 7, 31);
            p.politicalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1865, 4, 15), new DateTime(1869, 3, 4), p);
            termList.Add(t);

            // 18th President
            p = new President();
            p.name = "Ulysses S. Grant";
            p.birthDate = new DateTime(1822, 4, 7);
            p.deathDate = new DateTime(1885, 7, 23);
            p.politicalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1869, 3, 4), new DateTime(1877, 3, 4), p);
            termList.Add(t);

            // 19th President
            p = new President();
            p.name = "Rutherford B. Hayes";
            p.birthDate = new DateTime(1822, 10, 4);
            p.deathDate = new DateTime(1893, 1, 7);
            p.politicalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1877, 3, 4), new DateTime(1881, 3, 4), p);
            termList.Add(t);

            // 20th President
            p = new President();
            p.name = "James A. Garfield";
            p.birthDate = new DateTime(1831, 11, 19);
            p.deathDate = new DateTime(1881, 9, 19);
            p.politicalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1881, 3, 4), new DateTime(1881, 9, 19), p);
            termList.Add(t);

            // 21th President
            p = new President();
            p.name = "Chester A. Arthur";
            p.birthDate = new DateTime(1829, 10, 5);
            p.deathDate = new DateTime(1886, 11, 18);
            p.politicalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1881, 9, 19), new DateTime(1885, 3, 4), p);
            termList.Add(t);

            // 22nd President
            p = new President();
            p.name = "Grover Cleveland";
            p.birthDate = new DateTime(1837, 3, 18);
            p.deathDate = new DateTime(1908, 6, 24);
            p.politicalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1885, 3, 4), new DateTime(1889, 3, 4), p);
            termList.Add(t);
            t = new Term(new DateTime(1893, 3, 4), new DateTime(1897, 3, 4), p);
            termList.Add(t);

            // 23rd President
            p = new President();
            p.name = "Benjamin Harrison";
            p.birthDate = new DateTime(1833, 8, 20);
            p.deathDate = new DateTime(1901, 3, 13);
            p.politicalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1889, 3, 4), new DateTime(1833, 3, 4), p);
            termList.Add(t);

            // 25th President
            p = new President();
            p.name = "William McKinley";
            p.birthDate = new DateTime(1843, 1, 29);
            p.deathDate = new DateTime(1901, 9, 14);
            p.politicalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1897, 3, 4), new DateTime(1901, 9, 14), p);
            termList.Add(t);

            // 26th President
            p = new President();
            p.name = "Theodore Roosevelt";
            p.birthDate = new DateTime(1858, 10, 27);
            p.deathDate = new DateTime(1919, 1, 6);
            p.politicalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1901, 9, 14), new DateTime(1909, 3, 4), p);
            termList.Add(t);

            // 27th President
            p = new President();
            p.name = "William Howard Taft";
            p.birthDate = new DateTime(1857, 9, 15);
            p.deathDate = new DateTime(1930, 3, 8);
            p.politicalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1909, 3, 4), new DateTime(1913, 3, 4), p);
            termList.Add(t);

            // 28th President
            p = new President();
            p.name = "Woodrow Wilson";
            p.birthDate = new DateTime(1856, 12, 28);
            p.deathDate = new DateTime(1924, 2, 3);
            p.politicalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1913, 3, 4), new DateTime(1921, 3, 4), p);
            termList.Add(t);

            // 29th President
            p = new President();
            p.name = "Warren G. Harding";
            p.birthDate = new DateTime(1865, 11, 2);
            p.deathDate = new DateTime(1923, 8, 3);
            p.politicalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1921, 3, 4), new DateTime(1923, 8, 2), p);
            termList.Add(t);

            // 30th President
            p = new President();
            p.name = "Calvin Coolidge";
            p.birthDate = new DateTime(1872, 7, 4);
            p.deathDate = new DateTime(1933, 1, 5);
            p.politicalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1923, 8, 2), new DateTime(1929, 3, 4), p);
            termList.Add(t);

            // 31st President
            p = new President();
            p.name = "Herbert Hoover";
            p.birthDate = new DateTime(1874, 8, 10);
            p.deathDate = new DateTime(1964, 10, 20);
            p.politicalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1929, 3, 4), new DateTime(1933, 3, 4), p);
            termList.Add(t);

            // 31st President
            p = new President();
            p.name = "Herbert Hoover";
            p.birthDate = new DateTime(1874, 8, 10);
            p.deathDate = new DateTime(1964, 10, 20);
            p.politicalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1929, 3, 4), new DateTime(1933, 3, 4), p);
            termList.Add(t);

            // 32nd President
            p = new President();
            p.name = "Franklin D. Roosevelt";
            p.birthDate = new DateTime(1882, 1, 30);
            p.deathDate = new DateTime(1845, 4, 12);
            p.politicalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1933, 3, 4), new DateTime(1945, 4, 12), p);
            termList.Add(t);

            // 33rd President
            p = new President();
            p.name = "Harry S. Truman";
            p.birthDate = new DateTime(1884, 5, 8);
            p.deathDate = new DateTime(1972, 12, 26);
            p.politicalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1945, 4, 12), new DateTime(1953, 1, 20), p);
            termList.Add(t);

            // 34th President
            p = new President();
            p.name = "Dwight D. Eisenhower";
            p.birthDate = new DateTime(1890, 10, 14);
            p.deathDate = new DateTime(1969, 3, 28);
            p.politicalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1953, 1, 20), new DateTime(1961, 1, 20), p);
            termList.Add(t);

            // 35th President
            p = new President();
            p.name = "John F. Kennedy";
            p.birthDate = new DateTime(1917, 5, 29);
            p.deathDate = new DateTime(1963, 11, 22);
            p.politicalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1961, 1, 20), new DateTime(1963, 11, 22), p);
            termList.Add(t);

            // 36th President
            p = new President();
            p.name = "Lyndon B. Johnson";
            p.birthDate = new DateTime(1908, 8, 27);
            p.deathDate = new DateTime(1973, 1, 22);
            p.politicalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1963, 11, 22), new DateTime(1969, 1, 20), p);
            termList.Add(t);

            // 37th President
            p = new President();
            p.name = "Richard Nixon";
            p.birthDate = new DateTime(1913, 1, 9);
            p.deathDate = new DateTime(1994, 4, 22);
            p.politicalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1969, 1, 20), new DateTime(1974, 8, 9), p);
            termList.Add(t);

            // 38th President
            p = new President();
            p.name = "Gerald Ford";
            p.birthDate = new DateTime(1913, 7, 14);
            p.deathDate = new DateTime(2006, 12, 26);
            p.politicalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1974, 8, 9), new DateTime(1977, 1, 20), p);
            termList.Add(t);

            // 39th President
            p = new President();
            p.name = "Jimmy Carter";
            p.birthDate = new DateTime(1924, 10, 1);
            p.deathDate = null;
            p.politicalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1977, 1, 20), new DateTime(1881, 1, 20), p);
            termList.Add(t);

            // 40th President
            p = new President();
            p.name = "Ronald Reagan";
            p.birthDate = new DateTime(1911, 2, 6);
            p.deathDate = new DateTime(2004, 6, 5);
            p.politicalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1981, 1, 20), new DateTime(1989, 1, 20), p);
            termList.Add(t);

            // 41st President
            p = new President();
            p.name = "George H.W. Bush";
            p.birthDate = new DateTime(1924, 6, 12);
            p.deathDate = null;
            p.politicalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(1989, 1, 20), new DateTime(1993, 1, 20), p);
            termList.Add(t);

            // 42nd President
            p = new President();
            p.name = "Bill Clinton";
            p.birthDate = new DateTime(1946, 8, 19);
            p.deathDate = null;
            p.politicalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(1993, 1, 20), new DateTime(2001, 1, 20), p);
            termList.Add(t);

            // 43rd President
            p = new President();
            p.name = "George W. Bush";
            p.birthDate = new DateTime(1946, 7, 6);
            p.deathDate = null;
            p.politicalAffiliation = PoliticalAffiliation.Republican;
            t = new Term(new DateTime(2001, 1, 20), new DateTime(2009, 1, 20), p);
            termList.Add(t);

            // 44th President
            p = new President();
            p.name = "Barack Obama";
            p.birthDate = new DateTime(1961, 8, 4);
            p.deathDate = null;
            p.politicalAffiliation = PoliticalAffiliation.Democrat;
            t = new Term(new DateTime(2009, 1, 20), null, p);
            termList.Add(t);

            return termList;
        }
    }
}
