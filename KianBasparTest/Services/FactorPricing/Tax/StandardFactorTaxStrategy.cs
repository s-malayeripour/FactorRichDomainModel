using KianBasparTest.Domain.Aggregates.FactorsAggregate;

namespace KianBasparTest.Domain.Services.FactorPricing.Tax;
internal class StandardFactorTaxStrategy : IFactorTaxStrategy
{
    public decimal CalculateTax(Factor factor)
    {
        //Normal taxing rules and calculations using factor object.

        throw new NotImplementedException();
    }
}
