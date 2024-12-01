namespace SoftDesign.Library.Cross.Core.ResultModels.Book
{
    public class BookResult
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public bool IsRented { get; set; }
        public string RentUsername { get; set; }
    }
}