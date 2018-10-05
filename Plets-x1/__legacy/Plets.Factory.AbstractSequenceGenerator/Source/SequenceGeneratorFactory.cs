//#define HSI
//#define DFS
//#define Wp
//#define OATS

using Plets.Core.ControlStructure;
using Plets.Core.Interfaces;

#if PL_HSI
using Plets.Modeling.FiniteStateMachine.Hsi;
#endif

#if PL_DFS
using Plets.Modeling.Graph.Dfs;
using Plets.Modeling.Graph.DfsForTcc;
#endif

#if PL_WP
using Plets.Modeling.FiniteStateMachine.WP;
#endif

#if PL_OATS
#endif

namespace Plets.Factory.AbstractSequenceGenerator {
    public class SequenceGeneratorFactory {
        public static SequenceGenerator CreateSequenceGenerator (StructureType type) {
            switch (type) {
#if PL_HSI
                case StructureType.HSI:
                    return new HsiMethod ();
#endif
#if PL_DFS
                case StructureType.DFS_TCC:
                    return new DepthFirstSearchForTCC ();
                case StructureType.DFS:
                    return new DepthFirstSearch ();
#endif
#if PL_WP
                case StructureType.Wp:
                    return new Wp ();
#endif
#if PL_OATS
                case StructureType.OATS:
                    return new SequenceGenerator ();
#endif

            }
            return null;
        }
    }
}