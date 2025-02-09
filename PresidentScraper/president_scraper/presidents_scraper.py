import sys
from president_scraper.requester import Requester
from president_scraper.scraper import Scraper
from president_scraper.output_handler import OutputHandler
from president_scraper.output_handler import OutputType
from president_scraper.arg_parser import ArgParser


parser = ArgParser()
parser.parse_args(sys.argv[1:])

requester = Requester()

scraper = Scraper(requester)
terms = scraper.scrape()

print(f"Found {len(terms)} terms")

outputHandler = OutputHandler()
result = outputHandler.generate(OutputType.JSON, terms, parser.output_file)

if result:
    print("Output generated!")
else:
    print("Error generating output.")