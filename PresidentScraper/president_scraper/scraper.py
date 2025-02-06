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

                col_header_string = self.remove_reference(col_header_string)
                col_header_strings.append(col_header_string)

            terms = []
            current_cell = presidentsTable.find('th', scope='row') # first president

            if len(col_headers) == 0:
                print("Did not find a <th scope='row'> element. Could not parse.")
                return None

            current_row = current_cell.find_parent()
            
            # loop through currentRow / President cells
            current_term = Term.create_default()
            current_portrait = Portrait()
            current_president = President.create_default()

            # number
            current_term.number = self.parse_number(current_cell)
            current_cell = current_cell.find_next_sibling()

            # portrait
            img_tag = current_cell.find('img')
            if img_tag:
                src = img_tag.get('src')
                current_portrait.online_uri = src
            else:
                print("No <img> tag found in the current cell.")
            current_cell = current_cell.find_next_sibling()

            # Name
            name_a = current_cell.find('a')
            if name_a:
                name = name_a.get('title')
                current_president.name = name
            else:
                print("No <a> tag found in the current cell.")
            
            # #birth and death dates
            # date_span = current_cell.find('span')
            # if date_span:
            #     date_span_string = date_span.get_text()
            #     match = re.search(r"\((\d{4})[–-](\d{4})\)", date_span_string)

            #     if match:
            #         # Extract the years using capture groups
            #         year1 = match.group(1)
            #         year2 = match.group(2)
            #     else:
            #         print("No date span matches found.")
            #     current_president.name = name
            # else:
            #     print("No <span> tag found in the current cell.")

            # current_cell = current_cell.find_next_sibling()

            current_term.portrait = current_portrait
            current_term.president = current_president
            
            terms.append(current_term)

            return terms
        else:
            print("Could not find presidents table.")
            return None

    def remove_reference(self, str):
        return re.sub(r'\[.*\]', '', str)
    
    def parse_number(self, cell):
        return self.remove_reference(cell.get_text())