from enum import Enum
import json

class OutputType(Enum):
    JSON = "JSON"


class OutputHandler:
    def generate(self, OutputType, terms, output_file):
        terms_json = []

        for term in terms:
            terms_json.append(term.to_dict())

        with open(output_file, 'w') as json_file:
            json.dump(terms_json, json_file, indent=4)

        return True
