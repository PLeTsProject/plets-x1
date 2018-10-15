using System;
using System.Collections.Generic;
using Plets.Core.ControlAndConversionStructures;

namespace Plets.Modeling.TestSuitStructure {
    public class TestSuit : GeneralUseStructure {
        #region Constructor
        public TestSuit (String name) {
            this.Name = name;
            this.Scenarios = new List<Scenario> ();
        }
        #endregion

        public String Name { set; get; }

        public List<Scenario> Scenarios { set; get; }

        public override string ToString () {
            return this.Name;
        }
    }
}