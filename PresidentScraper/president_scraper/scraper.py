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
            
            while current_row:
                if not current_cell:
                    current_cell = current_row.find(['th']) # first cell is a <th> for number

                current_term = Term.create_default()
                current_portrait = Portrait()
                current_president = President.create_default()

                current_term.number = self.parse_number(current_cell)
                current_cell = current_cell.find_next_sibling()

                current_portrait.online_uri = self.parse_portrait(current_cell)
                current_cell = current_cell.find_next_sibling()

                current_president.name = self.parse_name(current_cell)
                
                birth_date, death_date = self.parse_life_dates(current_cell)
                current_president.birth_date = birth_date
                current_president.death_date = death_date
                current_cell = current_cell.find_next_sibling()

                start_date, end_date = self.parse_term_dates(current_cell)
                current_term.start_date = start_date
                current_term.end_date = end_date
                current_cell = current_cell.find_next_sibling()

                # skip party color
                current_cell = current_cell.find_next_sibling()

                current_term.political_affiliations = self.parse_political_affiliations(current_cell)
                current_cell = current_cell.find_next_sibling()

                current_term.election_years = self.parse_election_years(current_cell)
                current_cell = current_cell.find_next_sibling()

                current_term.vice_presidents = self.parse_vice_presidents(current_cell)

                current_term.portrait = current_portrait
                current_term.president = current_president
                
                terms.append(current_term)
                
                current_row = current_row.find_next_sibling('tr')
                current_cell = None

            return terms
        else:
            print("Could not find presidents table.")
            return None

    def remove_reference(self, str):
        return re.sub(r'\[.*\]', '', str)
    
    def is_reference(self, text):
        match = re.search(r"\[([a-f]{1,2}|\d{1,3})\]", text)
        return match
    
    def parse_number(self, cell):
        return self.remove_reference(cell.get_text().strip())
    
    def parse_portrait(self, cell):
        img_tag = cell.find('img')
        if img_tag:
            src = img_tag.get('src')
            return src.strip()
        else:
            print("No <img> tag found in the current cell.")

    def parse_name(self, cell):
        name_a = cell.find('a')
        if name_a:
            name = name_a.get('title')
            return name.strip()
        else:
            print("No <a> tag found in the current cell.")

    def parse_life_dates(self, cell):
        date_span = cell.find('span')
        if date_span:
            date_span_string = date_span.get_text()
            match_with_two_dates = re.search(r"\((\d{4})[–-](\d{4})\)", date_span_string)
            match_with_one_date = re.search(r"\(b\..*(\d{4})\)", date_span_string)

            if match_with_two_dates:
                # Extract the years using capture groups
                return match_with_two_dates.group(1), match_with_two_dates.group(2)
            elif match_with_one_date:
                return match_with_one_date.group(1), None
            else:
                print("No date span matches found.")
        else:
            print("No <span> tag found in the current cell.")

    def parse_term_dates(self, cell):
        start_date = ""
        end_date = ""

        start_span = cell.find('span')
        end_span = start_span.find_next_sibling('span')

        if start_span:
            start_date = start_span.get_text().strip()
        else:
            print("No term start <span> tag found in the current cell.")

        if end_span:
            end_date = end_span.get_text().strip()

        return start_date, end_date
    
    def parse_political_affiliations(self, cell):
        terms = []
        nodes = cell.find_all(['a', 'i'])
        for node in nodes:
            node_text = node.get_text().strip()
            if not self.is_reference(node_text):
                terms.append(node_text)
        return terms

    def parse_election_years(self, cell):
        years = []
        nodes = cell.find_all('a')
        for node in nodes:
            node_text = node.get_text().strip()
            if not self.is_reference(node_text):
                years.append(node_text)
        return years
    
    def parse_vice_presidents(self, cell):
        vps = []
        nodes = cell.find_all('a')
        for node in nodes:
            node_text = node.get_text().strip()
            if not self.is_reference(node_text):
                vps.append(node_text)
        return vps