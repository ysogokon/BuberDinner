using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

public sealed class MenuItemId : ValueObject
{
  public Guid Value { get; }
  private MenuItemId(Guid value)
  {
    Value = value;
  }

  public static MenuItemId CreateUnique()
  {
    // call private constructor here to create a new MenuId object
    return new(Guid.NewGuid());
  }
  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
