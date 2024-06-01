using KianBasparTest.Domain.Common;

namespace KianBasparTest.Domain.Aggregates.CustomersAggregate;
public class Customer : Entity, IAggregateRoot
{
    public string Name { get; set; } = string.Empty;
    //PhoneNumber as Value Object, etc...


    //Avoid Bi-Directional relation to Factors because it's not necessary and it only adds complexity
}