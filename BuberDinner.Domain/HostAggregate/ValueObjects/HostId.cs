using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.HostAggregate.ValueObjects;

public class HostId : ValueObject
{
  public Guid Value { get; }
  private HostId(Guid value)
  {
    Value = value;
  }

  // public static HostId Create(string hostId)
  // {
  //   // call private constructor here to create a new MenuId object
  //   return new(Guid.NewGuid());
  //  }
  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }

  public static string Create(string hostId)
  {

    return hostId;
  }
}
