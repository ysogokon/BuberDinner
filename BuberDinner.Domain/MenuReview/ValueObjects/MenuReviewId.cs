using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuReview.ValueObjects;

public class MenuReviewId : ValueObject
{
  public Guid Value { get; }
  private MenuReviewId(Guid value)
  {
    Value = value;
  }

  public static MenuReviewId CreateUnique()
  {
    // call private constructor here to create a new MenuId object
    return new(Guid.NewGuid());
  }
  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
