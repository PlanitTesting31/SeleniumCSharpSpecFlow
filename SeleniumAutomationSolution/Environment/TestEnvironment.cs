using System;

namespace SeleniumAutomationSolution.Environment
{
    public class TestEnvironment
    {
        public static string URL_Test = Properties.Settings.Default.URL;
        public static string URL_UAT = Properties.Settings.Default.URL;
        public static TestEnvironment GetEnvironment()
        {
            switch (Properties.Settings.Default.Environment)
            {
                case EnvironmentType.Test:
                   //return GetPreProdEnvironment();
                    return new TestEnvironment(URL_Test);
                case EnvironmentType.UAT:
                    return new TestEnvironment(URL_UAT);
                default:
                    throw new ArgumentException("Invalid Environment Setting has been used");

            }
        }

       

        public string Url
        {
            get;
            private set;
        }
        public TestEnvironment(string URL)
        {
            this.Url = URL;
        }
    }
}
