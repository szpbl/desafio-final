using System;

namespace bibliotecaAPI.Models
{
    public class Book
    {
        #region Properties

        public int Id { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string Title { get; private set; }
        public long ISBN { get; set; }
        public int PublishingYear { get; private set; }
        public DateTime CeratedIn { get; set; }

        #endregion

        #region Constructors

        protected Book() { }

        public Book(string title, long isbn, int publishingYear, int authorId)
        {
            Title = title;
            ISBN = isbn;
            PublishingYear = publishingYear;
            AuthorId = authorId;
            CeratedIn = DateTime.Now;
        }

        #endregion

        #region Methods

        public void SetTitle(string title)
        {
            Title = title;
        }

        public void SetPublishingYear(int publishingYear)
        {
            PublishingYear = publishingYear;
        }

        #endregion


    }
}
