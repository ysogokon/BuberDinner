using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.Entities;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using BuberDinner.Domain.Common.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{
  private readonly List<MenuSection> _sections = new();
  private readonly List<DinnerId> _dinnerIds = new();
  private readonly List<MenuReviewId> _menuReviewIds = new();

  private Menu(MenuId menuId,
                string hostId,
                string name,
                string description,
                AverateRating averageRating,
                IReadOnlyList<MenuSection> sections) : base(menuId)
  {
    Name = name;
    Description = description;
    AverageRating = averageRating;
    Sections = sections;
    HostId = hostId;
  }

  public string Name { get; } = null!;
  public string Description { get; } = null!;
  public AverateRating AverageRating { get; }

  public IReadOnlyList<MenuSection> Sections { get; } = null!;// => _sections;

  public string HostId { get; } = null!;
  public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds;
  public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds;

  public DateTime CreatedDateTime { get; }
  public DateTime UpdatedDateTime { get; }

  public static Menu Create(
    string hostId,
    string name,
    string description,
    List<MenuSection>? sections)
  {
    return new Menu(MenuId.CreateUnique(), hostId, name, description, AverateRating.CreateNew(), sections ?? new());

  }
}
