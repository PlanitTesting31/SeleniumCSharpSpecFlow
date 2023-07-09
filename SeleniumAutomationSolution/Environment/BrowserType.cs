using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationSolution.Environment
{
    public enum BrowserType
    {
        [Description("Firefox")]
        Firefox = 0,
        [Description("IE")]
        IE = 1,
        [Description("Chrome")]
        Chrome = 2,

    }
}
