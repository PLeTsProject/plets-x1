using System;
using Plets.Modeling.FiniteStateMachine;

namespace Plets.Modeling.FiniteStateMachine.WP {
    public class StatePair {
        #region Attributes
        public State Si { get; set; }
        public State Sj { get; set; }
        public String wi { get; set; }
        #endregion

        #region Public Methods
        public override string ToString () {
            return Si.Name + " - " + wi + " - " + Sj.Name;
        }
        #endregion
    }
}