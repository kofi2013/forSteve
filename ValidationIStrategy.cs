using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment_Application
{

    /// <summary>
    /// The Strategy interface declares operations common to all supported versions of some algorithm.
    /// The Context uses this interface to call the algorithm defined by Concrete Strategies.
    /// </summary>
    interface ValidationIStrategy
    {
        bool ValidateRecord(string[] fields);
    }
}
