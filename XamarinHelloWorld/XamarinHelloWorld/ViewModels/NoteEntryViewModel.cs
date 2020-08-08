namespace XamarinHelloWorld.ViewModels
{
    class NoteEntryViewModel : BaseViewModel
    {
        public string Text { get; set; }
        public NoteEntryViewModel()
        {
            Title = "Note Entry";
            Text = "Eggs over";
        }
    }
}
