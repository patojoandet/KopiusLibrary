namespace KopiusLibrary.Model.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DeathDate { get; set; }
    }
}
