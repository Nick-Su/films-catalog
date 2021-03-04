using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.ViewModel
{
    public class FilmViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Название фильма")]
        [Required(ErrorMessage = "Необходимо указать название фильма!")]
        public string Title { get; set; }
        [Display(Name = "Описание фильма")]
        [Required(ErrorMessage = "Необходимо добавить описание фильма!")]
        public string Description { get; set; }
        [Display(Name = "Год выпуска")]
        [Required(ErrorMessage = "Укажите год премьеры!")]
        public int Year { get; set; }
        [Display(Name = "Режиссер")]
        [Required(ErrorMessage = "Укажите режиссера!")]
        public string Director { get; set; }
        [Display(Name = "Постер")]
        [Required(ErrorMessage = "Необходимо загрузить постер!")]

        private string AddedByUserId {get;set;}
        public IFormFile Poster { get; set; }
    }
}
