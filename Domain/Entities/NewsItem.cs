using System.ComponentModel.DataAnnotations;

namespace MyCompany.Domain.Entities
{
    public class NewsItem : EntityBase
    {
        [Required(ErrorMessage = "Дайте новости краткое название")]
        [Display(Name = "Название новости")]
        public override string? Title { get; set; }

        [Display(Name = "Краткое описание новости")]
        public override string? Subtitle { get; set; }

        [Display(Name = "Полный текст новости")]
        public override string? Text { get; set; }
    }
}
