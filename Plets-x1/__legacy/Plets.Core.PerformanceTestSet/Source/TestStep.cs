using System;

namespace Plets.Modeling.TestPlanStructure {
    public class TestStep {
        public String Description { get; set; }
        public String ExpectedResult { get; set; }
        public String Index { get; set; }
        public String Title { get; set; }
        public String workItemIdString { get; set; }

        public TestStep () {
            this.Description = "";
            this.ExpectedResult = "";
            this.Index = "";
            this.Title = "";
            this.workItemIdString = "";
        }
    }
}