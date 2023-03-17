using System;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African, European
    }

    public enum SwallowLoad
    {
        None, Coconut
    }

    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType) => swallowType switch {
            SwallowType.African => new AfricanSwallow(),
            SwallowType.European => new EuropeanSwallow(),
            _ => throw new NotSupportedException()
        };
    }

    public abstract class Swallow
    {
        public SwallowLoad Load { get; set; }

        public virtual void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public virtual double GetAirspeedVelocity() => throw new NotImplementedException();
    }

    public class AfricanSwallow : Swallow
    {
        public override double GetAirspeedVelocity() => Load switch
        {
            SwallowLoad.None => 22,
            SwallowLoad.Coconut => 18,
            _ => throw new NotSupportedException()
        };
    }

    public class EuropeanSwallow : Swallow
    {
        public override double GetAirspeedVelocity() => Load switch
        {
            SwallowLoad.None => 20,
            SwallowLoad.Coconut => 16,
            _ => throw new NotSupportedException()
        };
    }
}