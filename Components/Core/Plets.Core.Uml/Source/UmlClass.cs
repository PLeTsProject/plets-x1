using System;
using System.Collections.Generic;

namespace Plets.Core.Uml {
    public class UmlClass : UmlBase {
        #region Constructor
        public UmlClass () {
            Methods = new List<UmlMethod> ();
        }
        #endregion

        #region Attributes
        public List<UmlMethod> Methods { get; set; }

        public String IdRef { set; get; }
        #endregion
    }
}