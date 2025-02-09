import unittest
from unittest.mock import Mock

from president_scraper.arg_parser import ArgParser

class ScraperTest(unittest.TestCase):
    def test_parse_args_defaults(self):
        args = []

        parser = ArgParser()
        parser.parse_args(args)

        self.assertEqual(parser.output_file, "data\presidents.json")

    def test_parse_args_shouldParseOutputFileWithShortOption(self):
        args = ["-o",  "data/ps.json"]

        parser = ArgParser()
        parser.parse_args(args)

        self.assertEqual(parser.output_file, "data/ps.json")

    def test_parse_args_shouldParseOutputFileWithLongOption(self):
        args = ["--outputfile",  "data/ps.json"]

        parser = ArgParser()
        parser.parse_args(args)

        self.assertEqual(parser.output_file, "data/ps.json")