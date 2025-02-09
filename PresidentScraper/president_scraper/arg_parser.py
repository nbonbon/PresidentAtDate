import argparse

DEFAULT_OUTPUT_FILE = "data\presidents.json"

class ArgParser:
    def parse_args(self, args):
        self.parser = argparse.ArgumentParser()
        self.parser.add_argument("-o", "--outputfile", help="Output file path. Default: 'data\presidents.json'")

        parsed_args = self.parser.parse_args(args)
        self.output_file = parsed_args.outputfile

    @property
    def output_file(self):
        return self._output_file
    
    @output_file.setter
    def output_file(self, value):
        if value is None:
            self._output_file = DEFAULT_OUTPUT_FILE
        else:
            self._output_file = value