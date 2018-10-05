using System.Collections.Generic;
using Plets.Conversion.ConversionUnit;
using Plets.Core.ControlAndConversionStructures;
using Plets.Core.ControlStructure;

namespace Plets.Core.Interfaces {
    public class SequenceGenerator {
        public List<GeneralUseStructure> ConvertStructure (List<GeneralUseStructure> listGeneralUseStructure, StructureType type) {
            ModelingStructureConverterFactory msf = new ModelingStructureConverterFactory ();
            ModelingStructureConverter msc = msf.CreateModelingStructureConverter (type);
            List<GeneralUseStructure> sgs = msc.Converter (listGeneralUseStructure, StructureType.None);
            return sgs;

        }

        public virtual List<GeneralUseStructure> GenerateSequence (List<GeneralUseStructure> listGeneralStructure, ref int tcCount, StructureType type) {
            return listGeneralStructure;
        }

    }
}