using KianBasparTest.Domain.Common;

namespace KianBasparTest.Domain.Aggregates.FactorsAggregate;
public class FactorItem(string name, decimal amount) : Entity
{
    public string Name { get; set; } = name;
    public decimal Amount { get; set; } = amount;

    //Based on bussiness it can be a dynamic value object, too.
}