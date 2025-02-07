from enum import Enum
import json

class OutputType(Enum):
    JSON = "JSON"


class OutputHandler:
    def generate(self, OutputType, terms):
        terms_json = []

        for term in terms:
            terms_json.append(term.to_dict())

        # Specify the file path
        file_path = 'data\presidents.json'

        # Write JSON data to a file
        with open(file_path, 'w') as json_file:
            json.dump(terms_json, json_file, indent=4)

        return True
