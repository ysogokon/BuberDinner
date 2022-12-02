using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;

public class DinnerId : ValueObject
{
  public Guid Value { get; }
  private DinnerId(Guid value)
  {
    Value = value;
  }

  public static DinnerId CreateUnique()
  {
    // call private constructor here to create a new MenuId object
    return new(Guid.NewGuid());
  }
  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
