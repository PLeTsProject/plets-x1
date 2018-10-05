using System;
using Plets.Core.ControlAndConversionStructures;

namespace Plets.Core.Interfaces {
    public abstract class Parser {
        public abstract StructureCollection ParserMethod (String path, ref String name, Tuple<String, object>[] args);
    }
}