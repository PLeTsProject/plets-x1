using System;

namespace Plets.Modeling.TestPlanStructure {
    public class TestStepForTCC {
        public TestStepForTCC () {
            //this.Params = new List<String>();
        }
        public String ActionType { get; set; }
        //public int Index {get;set;}
        public String Input { get; set; }
        public String Method { get; set; }
        //public Boolean IsAbstract { get; set; }
        //public String Visibility { get; set; }
        public String Output { get; set; }
        //public List<String> Params { get; set; }
        public String Receiver { get; set; }
        public String Return { get; set; }
        public String Sender { get; set; }
    }
}