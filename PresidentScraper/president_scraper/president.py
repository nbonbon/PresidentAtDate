
import json

class President:
    def __init__(self, name, birth_date, death_date, terms):
        self.name = name
        self.birth_date = birth_date
        self.death_date = death_date
        self.terms = terms
    
    @classmethod
    def from_json(cls, json_string):
        try:
            data = json.loads(json_string)
            # todo normalize and check
            return cls(name=None, birth_date=None, death_date=None, terms=[])
        except json.JSONDecodeError as e:
            print(f"JSONDecodeError: {e.msg} at line {e.lineno} column {e.colno} (char {e.pos})")

    @classmethod
    def create_default(cls):
        return cls(name=None, birth_date=None, death_date=None, terms=[])