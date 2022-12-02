using System;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

public class MenuSectionId : ValueObject
{
  public Guid Value { get; }
  private MenuSectionId(Guid value)
  {
    Value = value;
  }

  public static MenuSectionId CreateUnique()
  {
    // call private constructor here to create a new MenuId object
    var retValue = new MenuSectionId(Guid.NewGuid());
    return retValue;
  }
  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
