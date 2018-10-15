//#define XMI

using Plets.Core.Interfaces;
using Plets.Data.Xmi;
#if PL_XMI

#endif

namespace Plets.Factory.AbstractParser {
    public class ParsedStructureExporterFactory {
        public static ParsedStructureExporter CreateExporter () {
#if PL_XMI
            return new XmiExporter ();
#endif
            return null;
        }
    }
}