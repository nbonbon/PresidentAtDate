
class Term:
    def __init__(self, number, portrait, start_date, end_date, party, president, vice_presidents, election_years):
        self._number = number
        self.portrait = portrait
        self.start_date = start_date
        self.end_date = end_date
        self.party = party
        self.president = president
        self.vice_presidents = vice_presidents
        self.election_year = election_years

    @classmethod
    def create_default(cls):
        return cls(number=0, portrait=None, start_date=None, end_date=None, party=None, president=None, vice_presidents=[], election_years=[])
    
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
