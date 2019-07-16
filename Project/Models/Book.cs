namespace CastleGrimtol.Project.Models
{
  public class Book : Item
  {
    public Item Contents { get; set; }

    public Book(string name, string description, Item contents) : base(name, description)
    {
      Contents = contents;
    }
  }
}