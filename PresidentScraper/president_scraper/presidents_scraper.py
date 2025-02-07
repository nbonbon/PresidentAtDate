from president_scraper.requester import Requester
from president_scraper.scraper import Scraper
from president_scraper.output_handler import OutputHandler
from president_scraper.output_handler import OutputType

requester = Requester()

scraper = Scraper(requester)
terms = scraper.scrape()

print(f"Found {len(terms)} terms")

outputHandler = OutputHandler()
result = outputHandler.generate(OutputType.JSON, terms)

if result:
    print("Output generated!")
else:
    print("Error generating output.")