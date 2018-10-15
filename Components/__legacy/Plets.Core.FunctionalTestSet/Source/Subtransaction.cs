namespace Plets.Modeling.TestSuitStructure {
    public class Subtransaction {
        private string name;
        /// <summary>
        /// Name.
        /// </summary>
        public string Name {
            get { return name; }
            set { name = value; }
        }

        private Request begin;
        /// <summary>
        /// Begin trans.
        /// </summary>
        public Request Begin {
            get { return begin; }
            set { begin = value; }
        }

        private Request end;
        /// <summary>
        /// End trans.
        /// </summary>
        public Request End {
            get { return end; }
            set { end = value; }
        }

        public override string ToString () {
            return this.Name;
        }
    }
}