//#define XMI
//#define Oats
//#define LR

#if PL_XMI
#endif
using System;
using Plets.Data.Xmi;
using Plets.Core.Interfaces;
using Plets.Oats.OatsScriptGenerator;


#if PL_Oats
using Plets.Oats.OgmaJParser;
#endif

#if PL_LR
using Plets.Data.ReadLR;
#endif

namespace Plets.Factory.AbstractParser
{
    public class ParserFactory
    {
        public static Parser CreateParser(String parserType)
        {
            switch (parserType)
            {
#if PL_Oats
                case "Script JAVA":
                    return new OgmaJ();
#endif
#if PL_XMI
                case "Astah SeqDiag XML":
                    return new XmiToOats();
                case "Astah XML":
                    return new SequenceDiagramImporter();
                case "Argo XML":
                    return new XmlArgoUml();
#endif
#if PL_LR
                case "LoadRunnerToXMI":
                    return new LoadRunnerToXMI();
#endif
            }
            return null;
        }
    }
}