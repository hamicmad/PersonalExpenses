using PersonalExpenses.Enums;

namespace PersonalExpenses.Models
{
    public class Category
    {
        public int Id { get; set; }
        public Types Type { get; set; }
        public string Name { get; set; }

        public List<CategoryOperation> CategoryOperations { get; set; } = new();

        public Category(string name, Types type)
        {
            Name = name;
            Type = type;
        }
    }
}
