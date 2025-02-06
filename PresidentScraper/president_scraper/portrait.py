class Portrait:
    def __init__(self, online_uri=None, local_uri=None):
        self.online_uri = online_uri
        self.local_uri = local_uri


    @property
    def online_uri(self):
        return self._online_uri
    
    @online_uri.setter
    def online_uri(self, value):
        self._online_uri = str(value).strip()