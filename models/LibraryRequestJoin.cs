namespace Library.models
{
    public class LibraryRequestJoin
    {
        public LibraryRequest Library { get; set; }
        public Book Book { get; set; }
        public Client Client { get; set; }
    }
}
