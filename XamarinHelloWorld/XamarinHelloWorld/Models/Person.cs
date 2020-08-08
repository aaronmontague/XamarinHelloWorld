using SQLite;

namespace XamarinHelloWorld.Models
{
    public class Person
    {
        [PrimaryKey, AutoIncrement] 
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string DrinkOfChoice { get; set; }
    }
}
