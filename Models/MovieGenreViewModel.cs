using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebAppMVC.Models
{
    public class MovieGenreViewModel
    {
        /*
         SelectList chứa danh sách các thể loại. Điều này cho phép người dùng chọn một thể loại từ danh sách.
         MovieGenre, chứa thể loại đã chọn.
         SearchString, chứa văn bản người dùng nhập vào hộp văn bản tìm kiếm.
         */
        public List<Movie>? Movies { get; set; }
        public SelectList? Genres { get; set; }
        public string? MovieGenre { get; set; }
        public string? SearchString { get; set; }
    }
}
