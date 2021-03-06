using System.Collections.Generic;

namespace Plets.Modeling.TestSuitStructure {
    /// <summary>
    /// Class that represents a generic Request
    /// </summary>
    public class Request {
        #region Constructor
        public Request () {
            this.Parameters = new List<Parameter> ();
            this.Cookies = new List<Cookie> ();
            this.SaveParameters = new List<SaveParameter> ();
        }
        #endregion

        public double OptimisticTime { get; set; }
        public double PessimisticTime { get; set; }
        public double ExpectedTime { get; set; }
        public double ThinkTime { get; set; }

        //POST or GET. POST-GET not supported.
        public string Method { get; set; }
        public string Action { get; set; }
        public string Referer { get; set; }
        public List<Parameter> Parameters { get; set; }
        public List<SaveParameter> SaveParameters { get; set; }
        public List<Cookie> Cookies { get; set; }

        /// <summary>
        /// Indexes this Request. Names are unique - Request with the same name are the same Request.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Returns true if this Request has the same name of given Request. 
        /// Names diagram as unique identifier each for Request objects.
        /// </summary>
        public override bool Equals (object obj) {
            Request r = (Request) obj;
            if (r == null) {
                return false;
            }

            if (this.Name.Equals (r.Name)) {
                return true;
            }
            return false;
        }

        private bool isParallel;

        public bool IsParallel {
            get { return isParallel; }
            set { isParallel = value; }
        }

        /// <summary>
        /// Overrides base method for prevent warnings.
        /// </summary>
        public override int GetHashCode () {
            return base.GetHashCode ();
        }

        private string body;

        public string Body {
            get { return body; }
            set { body = value; }
        }

        public override string ToString () {
            return this.Name;
        }
    }
}