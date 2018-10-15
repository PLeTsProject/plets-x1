using System.Collections.Generic;
using System.Xml;
using Plets.Core.ControlAndConversionStructures;

namespace Plets.Core.Interfaces {
    public interface ParsedStructureExporter {
        XmlDocument ToXmi (List<GeneralUseStructure> model);
    }
}