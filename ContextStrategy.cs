using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment_Application
{
    /// <summary>
    // The Context maintains a reference to one of the Strategy objects. The
    // Context does not know the concrete class of a strategy. It should
    // work with all strategies via the Strategy interface.
    /// </summary>
    class ContextStrategy
    {     
        private ValidationIStrategy strategy;

        public ContextStrategy()
        { }

        public ContextStrategy(ValidationIStrategy strategy)
        {
            this.strategy = strategy;
        }

        // Usually, the Context allows replacing a Strategy object at runtime.
        public void SetStrategy(ValidationIStrategy strategy)
        {
            this.strategy = strategy;
        }

        // The Context delegates some work to the Strategy object instead of
        // implementing multiple versions of the algorithm on its own.
        public bool ExecuteStrategy(string[] fields)
        {
             bool strategyResults = strategy.ValidateRecord(fields);
            return strategyResults;
        }
    }
}
