using System;

namespace Plets.Core.Uml {
    public class UmlMessage : UmlBase {
        #region Constructor

        #endregion
        #region Attributes
        public int ActionType { get; set; }

        public UmlClass Sender { get; set; }

        public UmlClass Receiver { get; set; }

        public Double Index { get; set; }

        public UmlMethod Method { get; set; }
        #endregion
        #region Public Methods
        public override string ToString () {
            return "(" + this.Name + ") " + this.Sender + " - " + this.Receiver + " <Index: " + this.Index.ToString () + ">";
        }
        #endregion
    }
}