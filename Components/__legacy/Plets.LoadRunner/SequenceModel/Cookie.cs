namespace Lesse.LoadRunner.SequenceModel {
    public class Cookie {
        private string name;

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public Cookie (string name) {
            this.name = name;
        }

        public Cookie () {

        }
    }
}