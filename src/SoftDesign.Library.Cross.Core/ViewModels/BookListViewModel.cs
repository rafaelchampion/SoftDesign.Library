using SoftDesign.Library.Cross.Core.ResponseModels.Book;
using System.Collections.Generic;

namespace SoftDesign.Library.Cross.Core.ViewModels
{
    public class BookListViewModel
    {
        public string SearchQuery { get; set; }
        public ICollection<BookResponse> BookList { get; set; }
    }
}
