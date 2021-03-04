using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Необходимо указать название фильма!")]
        [Display(Name = "Название фильма")]
        public string Title { get; set; }
        [Display(Name = "Описание фильма")]
        [Required(ErrorMessage = "Необходимо добавить описание фильма!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Укажите год премьеры!")]
        [Display(Name = "Год выпуска")]
        public int Year { get; set; }
        [Display(Name = "Режиссер")]
        [Required(ErrorMessage = "Укажите режиссера!")]
        public string Director { get; set; }
        [Display(Name = "Постер")]
        [Required(ErrorMessage = "Необходимо загрузить постер!")]
        public string Poster { get; set; }

        public string AddedByUserId { get; set; }
    }
}
