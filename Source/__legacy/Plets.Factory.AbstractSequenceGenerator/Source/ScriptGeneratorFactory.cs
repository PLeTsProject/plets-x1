//#define MTM
//#define OATS

using Plets.Core.Interfaces;
#if PL_JUNIT
using Plets.JUnit;
#endif

#if PL_MTM
using Plets;
#endif

#if PL_OATS
using Plets.OATS;
#endif


namespace Plets.Factory.AbstractSequenceGenerator
{
    public class ScriptGeneratorFactory
    {
        public static ScriptGenerator CreateScriptGenerator()
        {
#if PL_JUNIT
            return new JUnitDriverGenerator();
#endif
#if PL_MTM
           
            return new MTMScriptGenerator();
#endif
#if PL_OATS
            return new ParserToExcelOATS();
#endif
            return null;
        }
    }
}
