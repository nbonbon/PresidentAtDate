using NuGet.Frameworks;
using PresidentAtDate;
using PresidentAtDate.Common.InputContainers;

namespace PresidentAtDateTests
{
    public class JsonTermInputContainerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LoadTermsShouldPopulateTermProperties()
        {
            JsonTermInputContainer uut = new JsonTermInputContainer();

            string jsonString = UnitTestData.TERM_JSON;
            List<Term> result = uut.LoadTerms(jsonString);

            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(2));

            Term term = result[0];
            Assert.IsNotNull(term);
            Assert.That(term.Number, Is.EqualTo(1));
            Assert.IsNotNull(term.TermPortrait);
            Assert.IsNotNull(term.TermPresident);

            DateTime startDateTime;
            DateTime.TryParse("April 30, 1789", out startDateTime);
            Assert.That(term.StartDateInOffice, Is.EqualTo(startDateTime));

            DateTime endDateTime;
            DateTime.TryParse("March 4, 1797", out endDateTime);
            Assert.That(term.EndDateInOffice, Is.EqualTo(endDateTime));

            Assert.That(term.PoliticalAffiliations, Is.EqualTo(new PoliticalAffiliation[]{ PoliticalAffiliation.Unaffiliated}));

            Assert.That(term.VicePresidents, Is.EqualTo(new string[] { "John Adams" }));
            Assert.That(term.ElectionYears, Is.EqualTo(new string[] { "1788–89", "1792" }));
        }

        [Test]
        public void LoadTermsShouldPopulatePortraitProperties()
        {
            JsonTermInputContainer uut = new JsonTermInputContainer();

            string jsonString = UnitTestData.TERM_JSON;
            List<Term> result = uut.LoadTerms(jsonString);

            Term term = result[0];
            Assert.IsNotNull(term.TermPortrait);

            Assert.That(term.TermPortrait.OnlineUri.OriginalString, Is.EqualTo("//upload.wikimedia.org/wikipedia/commons/thumb/d/d6/Gilbert_Stuart_Williamstown_Portrait_of_George_Washington_%28cropped%29%282%29.jpg/110px-Gilbert_Stuart_Williamstown_Portrait_of_George_Washington_%28cropped%29%282%29.jpg"));
            Assert.IsNull(term.TermPortrait.LocalUri);
        }

        [Test]
        public void LoadTermsShouldPopulatePresidentProperties()
        {
            JsonTermInputContainer uut = new JsonTermInputContainer();

            string jsonString = UnitTestData.TERM_JSON;
            List<Term> result = uut.LoadTerms(jsonString);

            Term term = result[0];
            Assert.IsNotNull(term.TermPresident);

            Assert.That(term.TermPresident.Name, Is.EqualTo("George Washington"));

            DateTime birthDateTime;
            DateTime.TryParse("1732", out birthDateTime);
            Assert.That(term.TermPresident.BirthDate, Is.EqualTo(birthDateTime));

            DateTime deathDateTime;
            DateTime.TryParse("1799", out deathDateTime);
            Assert.That(term.TermPresident.DeathDate, Is.EqualTo(deathDateTime));
        }
    }
}