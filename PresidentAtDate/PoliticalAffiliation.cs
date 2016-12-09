using System.ComponentModel;

namespace PresidentAtDate
{
    public enum PoliticalAffiliation
    {
        [Description("None")]
        None,
        [Description("Democrat")]
        Democrat,
        [Description("Democratic-Republican")]
        DemocraticRepublican,
        [Description("Federalist")]
        Federalist,
        [Description("Republican")]
        Republican,
        [Description("Whig")]
        Whig
    }
}
