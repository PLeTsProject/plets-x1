using Lesse.Core.Interfaces;

namespace Lesse.Factory.Xmi.AbstractValidator {
    public class ValidatorFactory {
        public static Validator CreateValidator () {
#if PL_FUNCTIONAL_TESTING
            return new FunctionalValidator.FunctionalValidator ();
#elif PL_PERFORMANCE_TESTING
            return new PerformanceValidator.PerformanceValidator ();
#else
            return new Validator ();
#endif
        }
    }
}