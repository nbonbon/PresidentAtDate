import json 

class Term:
    def __init__(self, number, portrait, start_date, end_date, political_affiliations, president, vice_presidents, election_years):
        self._number = number
        self.portrait = portrait
        self.start_date = start_date
        self.end_date = end_date
        self.political_affiliations = political_affiliations
        self.president = president
        self.vice_presidents = vice_presidents
        self.election_years = election_years

    @classmethod
    def create_default(cls):
        return cls(number=0, portrait=None, start_date=None, end_date=None, political_affiliations=[], president=None, vice_presidents=[], election_years=[])
    
    
    def to_dict(self):
        return {
            "number": self.number,
            "portait": self.portrait.to_dict(),
            "start_date" : self.start_date,
            "end_date" : self.end_date,
            "political_affiliations" : self.political_affiliations,
            "president" : self.president.to_dict(),
            "vice_presidents" : self.vice_presidents,
            "election_years" : self.election_years
        }
    
    def to_json(self):
        return json.dumps(self.to_dict(), indent=4)
    
    @property
    def number(self):
        return self._number
    
    @number.setter
    def number(self, value):
        if isinstance(value, int) and value:
            self._number = value
        elif isinstance(value, str) and value:
            try:
                self._number = int(value.strip())
            except ValueError as e:
                print(f"Error setting Term.number: {e}")
        else:
            self._number = 0
