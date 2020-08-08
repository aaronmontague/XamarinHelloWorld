namespace XamarinHelloWorld.ViewModels
{
    class NotesViewModel : BaseViewModel
    {
        public string HouseName { get; set; }
        public NotesViewModel()
        {
            Title = "Note List";
            HouseName = "Hufflepuff";
        }
    }
}
