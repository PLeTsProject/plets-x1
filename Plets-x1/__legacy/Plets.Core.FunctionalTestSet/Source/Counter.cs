using System;

namespace Plets.Modeling.TestSuitStructure {
    /// <summary>
    /// Class that represents a generic Counter
    /// </summary>
    public class Counter {
        private string name;
        /// <summary>
        /// Counter name.
        /// </summary>
        public string Name {
            get { return name; }
            set { name = value; }
        }

        private Object thresholds;
        /// <summary>
        /// Thresholds. Expected SLA value.
        /// </summary>
        public Object Thresholds {
            get { return thresholds; }
            set { thresholds = value; }
        }
    }
}