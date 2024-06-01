namespace KianBasparTest.Domain.Common;
public abstract class ValueObject : IEquatable<ValueObject>
{
    //Operator overriding and other logics for HashCode

    public bool Equals(ValueObject? other)
    {
        throw new NotImplementedException();
    }
}