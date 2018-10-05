namespace Plets.Modeling.TestSuitStructure {
    public class Cookie {
        #region Constructor
        public Cookie (string name) {
            this.name = name;
        }

        public Cookie () {

        }
        #endregion

        private string name;

        public string Name {
            get { return name; }
            set { name = value; }
        }

    }
}