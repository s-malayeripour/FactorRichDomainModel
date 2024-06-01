using KianBasparTest.Domain.Aggregates.FactorsAggregate;

namespace KianBasparTest.Domain.Services.FactorPricing.Shipping;
public interface IFactorShippingStrategy
{
    decimal CalculateShippingCost(Factor factor);
}