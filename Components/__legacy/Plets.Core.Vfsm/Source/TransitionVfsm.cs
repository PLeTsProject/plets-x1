using System;
using System.Collections.Generic;
using Plets.Modeling.FiniteStateMachine;

namespace Plets.Modeling.Vfsm {
    public class TransitionVfsm {
        #region Attributes
        public List<Variable> ListGuardian { get; set; }
        public List<Variable> ListNewGuardian { get; set; }
        public State Source { get; set; }
        public State Target { get; set; }
        public String Input { get; set; }
        public String Output { get; set; }
        public bool Isvisited { get; set; }
        #endregion

        #region Constructor
        public TransitionVfsm () {
            ListGuardian = new List<Variable> ();
            ListNewGuardian = new List<Variable> ();
        }
        #endregion

        #region Public Methods
        public override string ToString () {
            String guardian = "[";
            String newGuardian = "[";

            foreach (var item in ListGuardian) {
                guardian += item + ",";
            }

            guardian += "]";

            foreach (var item in ListNewGuardian) {
                newGuardian += item + ",";
            }

            newGuardian += "]";

            return (Source.Name + "---" + " Guardian: " + guardian + " Input:" + Input + "--" + "Output:" + Output + " NewValueGuardian: " + newGuardian + "--" + Target.Name);
        }
        #endregion
    }
}