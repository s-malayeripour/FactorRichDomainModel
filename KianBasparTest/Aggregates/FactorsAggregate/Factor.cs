using KianBasparTest.Domain.Aggregates.CustomersAggregate;
using KianBasparTest.Domain.Common;
using KianBasparTest.Domain.Services.FactorPricing.Shipping;
using KianBasparTest.Domain.Services.FactorPricing.Tax;

//Normally I don't put much amount of CommentsSsS, But I wanted this comments to be here.

namespace KianBasparTest.Domain.Aggregates.FactorsAggregate;
public class Factor(string title, IList<FactorItem> items, Customer owner) : Entity, IAggregateRoot
{
    public string Title { get; private set; /*We can add validation logic to set method*/ } = title;
    public IList<FactorItem> Items { get; private set; /*We can add validation logic to set method*/} = items;
    public Customer Owner { get; private init; /*Cannot be changed*/ } = owner;

    //We can add shipping method and tax method Enums here.


    private IFactorTaxStrategy _taxStrategy = new StandardFactorTaxStrategy();
    public void SetTaxStrategy(IFactorTaxStrategy factorTaxStrategy) => _taxStrategy = factorTaxStrategy;

    private IFactorShippingStrategy _shippingStrategy = new FactorPostShippingStrategy();
    public void SetShippinhStrategy(IFactorShippingStrategy factorShippingStrategy) => _shippingStrategy = factorShippingStrategy;
    //Strategies can be set by an Enum, but it cause the change of entity and it's not fit with Open/Close, I think.


    public void SetTitle(string newTitle)
    {
        //Validation logics can be in set method of propertie and another effect of change can be here.

        Title = newTitle;
    }

    public bool AddItem(FactorItem newItem)
    {
        var isAmountOfItemHigherThanWhatWeWant = newItem.Amount > 0;
        if (!isAmountOfItemHigherThanWhatWeWant) return false;
        // etc...

        Items.Add(newItem);

        return true;
    }
    // We can have AddItems or AddItemRange method, too.

    public bool RemoveItem(Guid factorItemId)
    {
        var foundItem = Items.FirstOrDefault(i => i.Id == factorItemId);
        if (foundItem is null) return false;

        var isRemoved = Items.Remove(foundItem);

        return isRemoved;
    }

    public decimal CalculateFactorTaxCost() => _taxStrategy.CalculateTax(this);
    public decimal CalcualteFactorShippingCost() => _shippingStrategy.CalculateShippingCost(this);

    public decimal CalculateFactorTotalCost()
    {
        var sumOfItems = 0m;

        foreach (var item in Items)
        {
            if (item is null) continue;

            sumOfItems += item.Amount;
        }

        var taxCost = CalculateFactorTaxCost();
        var shippingCost = CalcualteFactorShippingCost();

        var finalAmount = sumOfItems + taxCost + shippingCost;

        return finalAmount;
    }
}