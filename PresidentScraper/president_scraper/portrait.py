import json

class Portrait:
    def __init__(self, online_uri=None, local_uri=None):
        self.online_uri = online_uri
        self.local_uri = local_uri

    def to_dict(self):
        return {
            "online_uri": self.online_uri,
            "local_uri": self.local_uri
        }
    
    def to_json(self):
        return json.dumps(self.to_dict(), indent=4)