namespace ShortcutTrainerBackend.Data.Models;

public class Category
{
    //ToDo: C# properties can be used with simple get/set notations (compiler would create something like "public int Id_get() { ... }" as getter for Id)
    public required int Id { get; set; }
    public required string Name { get; set; }
}