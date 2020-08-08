namespace XamarinHelloWorld.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Practice,
        MoreText,
        Grid,
        ListView,
        PopUp,
        Database,
        WebService,
        Notes
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
