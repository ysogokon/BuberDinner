using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

public sealed class MenuId : ValueObject
{
  public Guid Value { get; }
  private MenuId(Guid value)
  {
    Value = value;
  }

  public static MenuId CreateUnique()
  {
    // call private constructor here to create a new MenuId object
    return new(Guid.NewGuid());
  }
  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
