
import json

class President:
    def __init__(self, name, birth_date, death_date):
        self.name = name
        self.birth_date = birth_date
        self.death_date = death_date

    @classmethod
    def create_default(cls):
        return cls(name=None, birth_date=None, death_date=None)
    
    def to_dict(self):
        return {
            "name": self.name,
            "birth_date" : self.birth_date,
            "death_date" : self.death_date,
        }
    
    def to_json(self):
        return json.dumps(self.to_dict(), indent=4)