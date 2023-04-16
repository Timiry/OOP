using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_4
{
    namespace StressTest
    {
        /// <summary>
        /// Enumeration of girder material types
        /// </summary>
        public enum Material
        {
            StainlessSteel,
            Aluminium,
            ReinforcedConcrete,
            Composite,
            Titanium
        }
        /// <summary>
        /// Enumeration of girder cross-sections
        /// </summary>
        public enum CrossSection
        {
            IBeam,
            Box,
            ZShaped,
            CShaped
        }
        /// <summary>
        /// Enumeration of test results
        /// </summary>
        public enum TestResult
        {
            Pass,
            Fail
        }
    }
}
