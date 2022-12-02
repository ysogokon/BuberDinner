using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
  // private readonly List<MenuItem> _items = new();
  public string Name { get; } = null!;
  public string Description { get; } = null!;
  private MenuItem(MenuItemId menuItemId, string name, string description) : base(menuItemId)
  {
    Name = name;
    Description = description;
  }

  public static MenuItem Create(string name, string description)
  {
    return new(MenuItemId.CreateUnique(), name, description);
  }
}
