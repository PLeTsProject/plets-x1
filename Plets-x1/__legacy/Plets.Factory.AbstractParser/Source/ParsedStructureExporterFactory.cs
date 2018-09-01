//#define XMI

using Plets.Data.Xmi;
using Plets.Core.Interfaces;
#if PL_XMI

#endif

namespace Plets.Factory.AbstractParser
{
    public class ParsedStructureExporterFactory
    {
        public static ParsedStructureExporter CreateExporter()
        {
#if PL_XMI
            return new XmiExporter();
#endif
            return null;
        }
    }
}
