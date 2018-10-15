using System;
using System.Collections.Generic;
using Plets.Core.ControlAndConversionStructures;

namespace Plets.Core.Interfaces {
    public class Validator {
        public virtual List<KeyValuePair<String, Int32>> Validate (List<GeneralUseStructure> ListModel, String fileName) {
            return new List<KeyValuePair<String, Int32>> ();
        }
    }
}