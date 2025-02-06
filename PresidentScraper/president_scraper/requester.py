import requests

class Requester:
     def wikipedia_president_request(self):
        URL = "https://en.wikipedia.org/wiki/List_of_presidents_of_the_United_States"
        page = requests.get(URL)

        if requests.codes.ok == page.status_code:
            return page
        else:
            return None