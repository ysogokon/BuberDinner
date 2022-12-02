using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public class AverateRating : ValueObject
{
  public double Value { get; set; }
  public int NumRatings { get; set; }
  private AverateRating(double value, int numRatings)
  {
    NumRatings = numRatings;
    Value = value;

  }

  public static AverateRating CreateNew(double rating = 0, int numRatings = 0)
  {
    return new AverateRating(rating, numRatings);
  }

  public void AddNewRating(Rating rating)
  {
    Value = ((Value * NumRatings) + rating.Value) / ++NumRatings;
  }

  internal void RemoveRating(Rating rating)
  {
    Value = ((Value * NumRatings) - rating.Value) / --NumRatings;
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
