using System;
using System.Collections.Generic;
using Plets.Core.ControlAndConversionStructures;

namespace Plets.Core.Interfaces {
    public interface ScriptGenerator {
        void GenerateScript (List<GeneralUseStructure> listPlan, String path);

    }
}