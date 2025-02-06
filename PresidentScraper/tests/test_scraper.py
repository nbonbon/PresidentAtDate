import unittest
from unittest.mock import Mock
import requests

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

    def test_scrapeShouldParseTheTermNumber(self):
        scraper = Scraper(self.mockRequester)
        result = scraper.scrape()
        self.assertEqual(result[0].number, 1)

    def test_scrapeShouldParseThePortraitUri(self):
        scraper = Scraper(self.mockRequester)
        result = scraper.scrape()
        self.assertEqual(result[0].portrait.online_uri, "//upload.wikimedia.org/wikipedia/commons/thumb/d/d6/Gilbert_Stuart_Williamstown_Portrait_of_George_Washington_%28cropped%29%282%29.jpg/110px-Gilbert_Stuart_Williamstown_Portrait_of_George_Washington_%28cropped%29%282%29.jpg")

    def test_scrapeShouldParseTheTermPresidentName(self):
        scraper = Scraper(self.mockRequester)
        result = scraper.scrape()
        self.assertEqual(result[0].president.name, "George Washington")

if __name__ == '__main__':
    unittest.main()