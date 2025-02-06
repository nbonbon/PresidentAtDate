from president_scraper.requester import Requester
from president_scraper.scraper import Scraper

requester = Requester()

scraper = Scraper(requester)
terms = scraper.scrape()

print(f"Found {len(terms)} terms")

for term in terms:
    print(term.number)