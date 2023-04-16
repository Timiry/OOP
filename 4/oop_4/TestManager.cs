using oop_4.StressTest;
using oop_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_4
{
    internal class TestManager
    {
        public static TestCaseResult GenerateResult()
        {
            Random rand = new Random();
            var randMaterial = (Material)rand.Next(5);
            var randCrossSection = (CrossSection)rand.Next(4);
            var randResult = (TestResult)rand.Next(2);

            var item = (randMaterial, randCrossSection, randResult);

            if (item.randResult == TestResult.Fail)
            {
                return new TestCaseResult { ReasonForFailure = $"Материал {item.randMaterial} не выдержал нагрузку при {item.randCrossSection} сечении", Result = item.randResult };
            }
            return new TestCaseResult { Result = item.randResult };
        }
    }
}