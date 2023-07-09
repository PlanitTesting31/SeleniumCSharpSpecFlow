using System.ComponentModel;

namespace SeleniumAutomationSolution.Environment
{
    public enum EnvironmentType
    {
        [Description("Test")]
        Test = 0,
        [Description("UAT")]
        UAT = 1,

    }
}
