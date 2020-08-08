namespace XamarinHelloWorld.Models
{
    public class Painter
    {
        // Attributes
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        // Constructors
        public Painter() { }

        public Painter(string fName, string lName)
        {
            firstName = fName;
            lastName = lName;
        }

        // Methods
    }
}
