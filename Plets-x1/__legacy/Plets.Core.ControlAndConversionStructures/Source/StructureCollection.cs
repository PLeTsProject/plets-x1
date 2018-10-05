using System.Collections.Generic;
using Plets.Core.ControlStructure;

namespace Plets.Core.ControlAndConversionStructures {
    public class StructureCollection {
        public StructureType type { get; set; }
        public List<GeneralUseStructure> listGeneralStructure { get; set; }
        public StructureCollection () {
            listGeneralStructure = new List<GeneralUseStructure> ();
        }
    }
}