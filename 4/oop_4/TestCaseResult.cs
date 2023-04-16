using oop_4.StressTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_4
{
    public struct TestCaseResult
    {
        /// <summary>
        /// Test result (enumeration type)
        /// </summary>
        public TestResult Result;
        /// <summary>
        /// Description of reason for failure
        /// </summary>
        public string ReasonForFailure;
    }
}
