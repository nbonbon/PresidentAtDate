using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresidentAtDateTests
{
    internal class UnitTestData
    {
        public const string TERM_JSON = @"
            [
                {
                    ""number"": 1,
                    ""portrait"": {
                        ""online_uri"": ""//upload.wikimedia.org/wikipedia/commons/thumb/d/d6/Gilbert_Stuart_Williamstown_Portrait_of_George_Washington_%28cropped%29%282%29.jpg/110px-Gilbert_Stuart_Williamstown_Portrait_of_George_Washington_%28cropped%29%282%29.jpg"",
                        ""local_uri"": null
                    },
                    ""start_date"": ""April 30, 1789"",
                    ""end_date"": ""March 4, 1797"",
                    ""political_affiliations"": [
                        ""Unaffiliated""
                    ],
                    ""president"": {
                        ""name"": ""George Washington"",
                        ""birth_date"": ""1732"",
                        ""death_date"": ""1799""
                    },
                    ""vice_presidents"": [
                        ""John Adams""
                    ],
                    ""election_years"": [
                        ""1788\u201389"",
                        ""1792""
                    ]
                },
                {
                    ""number"": 2,
                    ""portrait"": {
                        ""online_uri"": ""//upload.wikimedia.org/wikipedia/commons/thumb/c/c8/John_Adams_1800_to_1815_Portrait_%284x5_cropped%29.jpg/110px-John_Adams_1800_to_1815_Portrait_%284x5_cropped%29.jpg"",
                        ""local_uri"": null
                    },
                    ""start_date"": ""March 4, 1797"",
                    ""end_date"": ""March 4, 1801"",
                    ""political_affiliations"": [
                        ""Federalist""
                    ],
                    ""president"": {
                        ""name"": ""John Adams"",
                        ""birth_date"": ""1735"",
                        ""death_date"": ""1826""
                    },
                    ""vice_presidents"": [
                        ""Thomas Jefferson""
                    ],
                    ""election_years"": [
                        ""1796""
                    ]
                }
            ]
        ";
    }
}
