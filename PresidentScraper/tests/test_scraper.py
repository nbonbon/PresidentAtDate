import unittest
from unittest.mock import Mock
import requests
from bs4 import BeautifulSoup

from president_scraper.scraper import Scraper

class ScraperTest(unittest.TestCase):
    def setUp(self):
        content = """<table class="wikitable sortable sticky-header" style="text-align:center"><caption><style data-mw-deduplicate="TemplateStyles:r1152813436">.mw-parser-output .sr-only{border:0;clip:rect(0,0,0,0);clip-path:polygon(0 0,0 0,0 0);height:1px;margin:-1px;overflow:hidden;padding:0;position:absolute;width:1px;white-space:nowrap}</style><span class="sr-only">List of presidents of the United States from 1789 – till date.</span></caption><tbody><tr><th scope="col"><abbr title="Number">No.</abbr><sup id="cite_ref-16" class="reference"><a href="#cite_note-16"><span class="cite-bracket">&#91;</span>a<span class="cite-bracket">&#93;</span></a></sup></th><th scope="col" class="unsortable">Portrait</th><th scope="col">Name<br><span style="font-size:85%">(birth–death)</span></th><th scope="col" class="unsortable">Term<sup id="cite_ref-FOOTNOTELOCwhitehouse.gov_17-0" class="reference"><a href="#cite_note-FOOTNOTELOCwhitehouse.gov-17"><span class="cite-bracket">&#91;</span>16<span class="cite-bracket">&#93;</span></a></sup></th><th scope="col" colspan="2">Party<sup id="cite_ref-18" class="reference"><a href="#cite_note-18"><span class="cite-bracket">&#91;</span>b<span class="cite-bracket">&#93;</span></a></sup><sup id="cite_ref-FOOTNOTE&#39;&#39;Guide_to_U.S._Elections&#39;&#39;2010257–258_19-0" class="reference"><a href="#cite_note-FOOTNOTE&#39;&#39;Guide_to_U.S._Elections&#39;&#39;2010257–258-19"><span class="cite-bracket">&#91;</span>17<span class="cite-bracket">&#93;</span></a></sup></th><th scope="col" class="unsortable">Election</th><th scope="col" class="unsortable">Vice President<sup id="cite_ref-FOOTNOTELOC_20-0" class="reference"><a href="#cite_note-FOOTNOTELOC-20"><span class="cite-bracket">&#91;</span>18<span class="cite-bracket">&#93;</span></a></sup></th></tr><tr><th scope="row"><a href="/wiki/Presidency_of_George_Washington" title="Presidency of George Washington">1</a></th><td><span class="mw-default-size" typeof="mw:File/Frameless"><a href="/wiki/File:Gilbert_Stuart_Williamstown_Portrait_of_George_Washington_(cropped)(2).jpg" class="mw-file-description"><img alt="Painting of George Washington" src="//upload.wikimedia.org/wikipedia/commons/thumb/d/d6/Gilbert_Stuart_Williamstown_Portrait_of_George_Washington_%28cropped%29%282%29.jpg/110px-Gilbert_Stuart_Williamstown_Portrait_of_George_Washington_%28cropped%29%282%29.jpg" decoding="async" width="110" height="134" class="mw-file-element" srcset="//upload.wikimedia.org/wikipedia/commons/thumb/d/d6/Gilbert_Stuart_Williamstown_Portrait_of_George_Washington_%28cropped%29%282%29.jpg/165px-Gilbert_Stuart_Williamstown_Portrait_of_George_Washington_%28cropped%29%282%29.jpg 1.5x, //upload.wikimedia.org/wikipedia/commons/thumb/d/d6/Gilbert_Stuart_Williamstown_Portrait_of_George_Washington_%28cropped%29%282%29.jpg/220px-Gilbert_Stuart_Williamstown_Portrait_of_George_Washington_%28cropped%29%282%29.jpg 2x" data-file-width="4168" data-file-height="5088"></a></span></td><td data-sort-value="Washington, George"><b><a href="/wiki/George_Washington" title="George Washington">George Washington</a></b><br><span style="font-size:85%">(1732–1799)</span><br><sup id="cite_ref-FOOTNOTEMcDonald2000_21-0" class="reference"><a href="#cite_note-FOOTNOTEMcDonald2000-21"><span class="cite-bracket">&#91;</span>19<span class="cite-bracket">&#93;</span></a></sup></td><td><span data-sort-value="000000001789-04-30-0000" style="white-space:nowrap">April 30, 1789</span><br>–<br><span data-sort-value="000000001797-03-04-0000" style="white-space:nowrap">March 4, 1797</span></td><td style="background-color:#dcdcdc"></td><td><i>Unaffiliated</i></td><td class="nowrap"><a href="/wiki/1788%E2%80%9389_United_States_presidential_election" title="1788–89 United States presidential election">1788–89</a><hr><a href="/wiki/1792_United_States_presidential_election" title="1792 United States presidential election">1792</a></td><td><a href="/wiki/John_Adams" title="John Adams">John Adams</a><sup id="cite_ref-23" class="reference"><a href="#cite_note-23"><span class="cite-bracket">&#91;</span>c<span class="cite-bracket">&#93;</span></a></sup></td></tr></tbody></table>"""

        requestReturn = Mock()
        requestReturn.content = content

        self.mockRequester = Mock()
        self.mockRequester.wikipedia_president_request.return_value = requestReturn

    def test_scrapeShouldParseTheCorrectNumberOfPresidents(self):
        scraper = Scraper(self.mockRequester)
        result = scraper.scrape()
        
        self.assertEqual(len(result), 1)

        self.assertEqual(result[0].number, 1)
        self.assertEqual(result[0].portrait.online_uri, "//upload.wikimedia.org/wikipedia/commons/thumb/d/d6/Gilbert_Stuart_Williamstown_Portrait_of_George_Washington_%28cropped%29%282%29.jpg/110px-Gilbert_Stuart_Williamstown_Portrait_of_George_Washington_%28cropped%29%282%29.jpg")
        self.assertEqual(result[0].president.name, "George Washington")
        self.assertEqual(result[0].president.birth_date, "1732")
        self.assertEqual(result[0].president.death_date, "1799")
        self.assertEqual(result[0].start_date, "April 30, 1789")
        self.assertEqual(result[0].end_date, "March 4, 1797")
        self.assertEqual(len(result[0].political_affiliations), 1)
        self.assertEqual(result[0].political_affiliations[0], "Unaffiliated")
        self.assertEqual(len(result[0].election_years), 2)
        self.assertEqual(result[0].election_years[0], "1788–89")
        self.assertEqual(result[0].election_years[1], "1792")
        self.assertEqual(len(result[0].vice_presidents), 1)
        self.assertEqual(result[0].vice_presidents[0], "John Adams")

    def test_parse_dates_shouldParseBirthAndDeathDates(self):
        scraper = Scraper(self.mockRequester)
        content = """<td data-sort-value="Washington, George"><b><a href="/wiki/George_Washington" title="George Washington">George Washington</a></b><br><span style="font-size:85%">(1732–1799)</span><br><sup id="cite_ref-FOOTNOTEMcDonald2000_21-0" class="reference"><a href="#cite_note-FOOTNOTEMcDonald2000-21"><span class="cite-bracket">&#91;</span>19<span class="cite-bracket">&#93;</span></a></sup></td>"""
        soup = BeautifulSoup(content, "html.parser")

        result1, result2 = scraper.parse_life_dates(soup)

        self.assertEqual(result1, "1732")
        self.assertEqual(result2, "1799")

    def test_parse_life_dates_shouldParseBirthDateFormat(self):
        scraper = Scraper(self.mockRequester)
        content = """<td data-sort-value="Obama, Barack"><b><a href="/wiki/Barack_Obama" title="Barack Obama">Barack Obama</a></b><br><span style="font-size:85%">(<abbr title="born in">b.</abbr>1961)</span><br><sup id="cite_ref-FOOTNOTEwhitehouse.gov_(e)_96-0" class="reference"><a href="#cite_note-FOOTNOTEwhitehouse.gov_(e)-96"><span class="cite-bracket">&#91;</span>75<span class="cite-bracket">&#93;</span></a></sup></td>"""
        soup = BeautifulSoup(content, "html.parser")

        result1, result2 = scraper.parse_life_dates(soup)

        self.assertEqual(result1, "1961")
        self.assertEqual(result2, None)

    def test_parse_dates_shouldParseTermStartAndEndDates(self):
        scraper = Scraper(self.mockRequester)
        content = """<td><span data-sort-value="000000001789-04-30-0000" style="white-space:nowrap">April 30, 1789</span><br>–<br><span data-sort-value="000000001797-03-04-0000" style="white-space:nowrap">March 4, 1797</span></td>"""
        soup = BeautifulSoup(content, "html.parser")

        result1, result2 = scraper.parse_term_dates(soup)

        self.assertEqual(result1, "April 30, 1789")
        self.assertEqual(result2, "March 4, 1797")

    def test_parse_party_shouldParseParty_i(self):
        scraper = Scraper(self.mockRequester)
        content = """<td><i>Unaffiliated</i></td>"""
        soup = BeautifulSoup(content, "html.parser")

        result = scraper.parse_political_affiliations(soup)

        self.assertEqual(len(result), 1)
        self.assertEqual(result[0], "Unaffiliated")

    def test_parse_party_shouldParseParty_a(self):
        scraper = Scraper(self.mockRequester)
        content = """<td><a href="/wiki/Republican_Party_(United_States)" title="Republican Party (United States)">Republican</a></td>"""
        soup = BeautifulSoup(content, "html.parser")

        result = scraper.parse_political_affiliations(soup)

        self.assertEqual(len(result), 1)
        self.assertEqual(result[0], "Republican")

    def test_parse_party_shouldParseParty_linebreak(self):
        scraper = Scraper(self.mockRequester)
        content = """<td><a href="/wiki/Democratic-Republican_Party" title="Democratic-Republican Party">Democratic-<br>Republican</a></td>"""
        soup = BeautifulSoup(content, "html.parser")

        result = scraper.parse_political_affiliations(soup)
        
        self.assertEqual(len(result), 1)
        self.assertEqual(result[0], "Democratic-Republican")

    # Test data from John Quincy Adams
    def test_parse_party_shouldParseParty_linebreak_and_two_parties(self):
        scraper = Scraper(self.mockRequester)
        content = """<td><a href="/wiki/Democratic-Republican_Party" title="Democratic-Republican Party">Democratic-<br>Republican</a><sup id="cite_ref-JQAdams_34-0" class="reference"><a href="#cite_note-JQAdams-34"><span class="cite-bracket">&#91;</span>f<span class="cite-bracket">&#93;</span></a></sup><hr><a href="/wiki/National_Republican_Party" title="National Republican Party">National Republican</a></td>"""
        soup = BeautifulSoup(content, "html.parser")

        result = scraper.parse_political_affiliations(soup)

        self.assertEqual(len(result), 2)
        self.assertEqual(result[0], "Democratic-Republican")
        self.assertEqual(result[1], "National Republican")

    def test_parse_election_years_shouldParseSingleElectionYear(self):
        scraper = Scraper(self.mockRequester)
        content = """<td><a href="/wiki/1796_United_States_presidential_election" title="1796 United States presidential election">1796</a></td>"""
        soup = BeautifulSoup(content, "html.parser")

        result = scraper.parse_election_years(soup)

        self.assertEqual(len(result), 1)
        self.assertEqual(result[0], "1796")

    def test_parse_election_years_shouldParseMultipleElectionYears(self):
        scraper = Scraper(self.mockRequester)
        content = """<td class="nowrap"><a href="/wiki/1788%E2%80%9389_United_States_presidential_election" title="1788–89 United States presidential election">1788–89</a><hr><a href="/wiki/1792_United_States_presidential_election" title="1792 United States presidential election">1792</a></td>"""
        soup = BeautifulSoup(content, "html.parser")

        result = scraper.parse_election_years(soup)

        self.assertEqual(len(result), 2)
        self.assertEqual(result[0], "1788–89")
        self.assertEqual(result[1], "1792")

    def test_parse_vice_presidents_shouldParseSingleVicePresident(self):
        scraper = Scraper(self.mockRequester)
        content = """<td><a href="/wiki/John_Adams" title="John Adams">John Adams</a><sup id="cite_ref-23" class="reference"><a href="#cite_note-23"><span class="cite-bracket">&#91;</span>c<span class="cite-bracket">&#93;</span></a></sup></td>"""
        soup = BeautifulSoup(content, "html.parser")

        result = scraper.parse_vice_presidents(soup)

        self.assertEqual(len(result), 1)
        self.assertEqual(result[0], "John Adams")

    def test_parse_vice_presidents_shouldParseDoubleVicePresident(self):
        scraper = Scraper(self.mockRequester)
        content = """<td><a href="/wiki/Aaron_Burr" title="Aaron Burr">Aaron Burr</a><hr><a href="/wiki/George_Clinton_(vice_president)" title="George Clinton (vice president)">George Clinton</a></td>"""
        soup = BeautifulSoup(content, "html.parser")

        result = scraper.parse_vice_presidents(soup)

        self.assertEqual(len(result), 2)
        self.assertEqual(result[0], "Aaron Burr")
        self.assertEqual(result[1], "George Clinton")

    def test_parse_vice_presidents_shouldParseJamesMadisonVps(self):
        scraper = Scraper(self.mockRequester)
        content = """<td><a href="/wiki/George_Clinton_(vice_president)" title="George Clinton (vice president)">George Clinton</a><sup id="cite_ref-diedintraterm_30-0" class="reference"><a href="#cite_note-diedintraterm-30"><span class="cite-bracket">&#91;</span>e<span class="cite-bracket">&#93;</span></a></sup><hr><i>Vacant&#160;after<br>April 20, 1812</i><hr><a href="/wiki/Elbridge_Gerry" title="Elbridge Gerry">Elbridge Gerry</a><sup id="cite_ref-diedintraterm_30-1" class="reference"><a href="#cite_note-diedintraterm-30"><span class="cite-bracket">&#91;</span>e<span class="cite-bracket">&#93;</span></a></sup><hr><i>Vacant&#160;after<br>November 23, 1814</i></td>"""
        soup = BeautifulSoup(content, "html.parser")

        result = scraper.parse_vice_presidents(soup)

        self.assertEqual(len(result), 2)
        self.assertEqual(result[0], "George Clinton")
        self.assertEqual(result[1], "Elbridge Gerry")

if __name__ == '__main__':
    unittest.main()