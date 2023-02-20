namespace Library.models
{
    public class LibraryModelJoin
    {
        public Library Library { get; set; }
        public Book Book { get; set; }
        public Client Client { get; set; }
    }
}
