using System;
using System.Web;

namespace Plets.Core.Uml {
    public class UmlAssociation : UmlBase {
        public UmlAssociationCardinality End1Cardinality { get; set; }
        public UmlAssociationCardinality End2Cardinality { get; set; }

        public UmlElement End1 { get; set; }
        public UmlElement End2 { get; set; }

        public UmlAssociation () : base () {
            this.End1Cardinality = UmlAssociationCardinality.Undefined;
            this.End2Cardinality = UmlAssociationCardinality.Undefined;
        }

        public override String ToString () {
            return HttpUtility.UrlDecode (End1.ToString () + " - " + End2.ToString () + (TaggedValues.Count > 0 ? " <Tags:" + TaggedValues.Count + ">" : ""));
        }

        // override object.GetHashCode
        public override int GetHashCode () {
            //return Source.Name.GetHashCode()*(-3) + Target.Name.GetHashCode()*7;
            return 0;
        }

    }
}