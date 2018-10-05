using System;
using System.Collections.Generic;
using Plets.Modeling.FiniteStateMachine;

namespace Plets.Modeling.Vfsm {
    public class Vfsm {
        #region Attributes
        public State StateInitial { get; set; }
        public List<State> ListStates { get; set; }
        public List<TransitionVfsm> ListTransition { get; set; }
        public List<String> ListAlphabetInput { get; set; }
        public List<String> ListAlphabetOutput { get; set; }
        public List<Variable> ListOfGuardian { get; set; }
        public List<Variable> ListOfVariableInitial { get; set; }
        public String Name { get; set; }
        #endregion

        #region Constructor
        public Vfsm (String n) {
            Name = n;
            ListTransition = new List<TransitionVfsm> ();
            ListAlphabetInput = new List<string> ();
            ListAlphabetOutput = new List<string> ();
            ListStates = new List<State> ();
            ListOfVariableInitial = new List<Variable> ();
            ListOfGuardian = new List<Variable> ();
        }
        #endregion
    }
}