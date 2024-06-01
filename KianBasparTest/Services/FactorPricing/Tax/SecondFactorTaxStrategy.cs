using KianBasparTest.Domain.Aggregates.FactorsAggregate;

namespace KianBasparTest.Domain.Services.FactorPricing.Tax;
public class SecondFactorTaxStrategy : IFactorTaxStrategy
{
    public decimal CalculateTax(Factor factor)
    {
        //Another taxing strategy.

        throw new NotImplementedException();
    }
}