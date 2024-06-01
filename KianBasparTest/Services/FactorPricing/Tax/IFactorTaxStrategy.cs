using KianBasparTest.Domain.Aggregates.FactorsAggregate;

namespace KianBasparTest.Domain.Services.FactorPricing.Tax;
public interface IFactorTaxStrategy
{
    decimal CalculateTax(Factor factor);
}