﻿namespace KopiusLibrary.Model.Entities
{
    public class BookGenre
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
