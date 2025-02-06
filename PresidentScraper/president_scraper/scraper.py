import re
from bs4 import BeautifulSoup

from president_scraper.president import President
from president_scraper.term import Term
from president_scraper.portrait import Portrait

class Scraper:
    def __init__(self, requester):
        self.requester = requester

    def scrape(self):
        result = self.requester.wikipedia_president_request()

        if result:
            print("Successfully retrieved page source.")
        else:
            print("Error retrieving page source.")

        soup = BeautifulSoup(result.content, "html.parser")

        tables = soup.find_all("table")

        presidentsTable = None

        for table in tables:
            caption = table.find("caption")

            if caption and caption.find('span', string="List of presidents of the United States from 1789 – till date."):
                presidentsTable = table
                break

        if presidentsTable:
            print("Found presidents table.")

            col_headers = presidentsTable.find_all("th", scope="col")

            if len(col_headers) == 0:
                print("No table headers found.")
                return None

            col_header_strings = []

            # Normalize strings to remove link references
            for col_header in col_headers:
                col_header_string = col_header.get_text()

                if not col_header_string:
                    print("Current header text was empty. Skipping...")
                    return None

                col_header_string = self.normalize(col_header_string)
                col_header_strings.append(col_header_string)

            terms = []
            currentCell = presidentsTable.find("th", scope="row") # first president

            if len(col_headers) == 0:
                print("Did not find a <th scope='row'> element. Could not parse.")
                return None

            currentRow = currentCell.find_parent()
            
            # todo: Loop ... until next sibling empty? Then hop a row?
            currentTerm = Term.create_default()
            currentTerm.number = self.normalize(currentCell.get_text())
            currentCell = currentCell.find_next_sibling()
            
            portrait = Portrait()
            portrait.online_uri = currentCell.find('a').find('img').get('src')
            currentTerm.portrait = portrait

            terms.append(currentTerm)

            return terms
        else:
            print("Could not find presidents table.")
            return None

    def normalize(self, str):
        return re.sub(r'\[.*\]', '', str)