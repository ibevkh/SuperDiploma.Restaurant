namespace SuperDiploma.Restaurant.DataContext.Entities.Models;

public class CategoryDbo
{
    public int Id { get; set; }

    public string Name { get; set; }
    public ICollection<DishMenuItemDbo> Dishes { get; set; } //Одна Category може містити багато DishMenuItem.
}