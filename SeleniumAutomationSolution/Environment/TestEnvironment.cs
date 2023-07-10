using System;

namespace SeleniumAutomationSolution.Environment
{
    public class TestEnvironment
    {
        public static string URL_Test = Properties.Settings.Default.URL_TEST;
        public static string URL_SIT = Properties.Settings.Default.URL_SIT;
        public static TestEnvironment GetEnvironment()
        {
            switch (Properties.Settings.Default.Environment)
            {
                case EnvironmentType.Test:
                    return new TestEnvironment(URL_Test);
                case EnvironmentType.SIT:
                    return new TestEnvironment(URL_SIT);
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
