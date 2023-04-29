using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace MyCompany.Domain.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase() => DateAdded= DateTime.UtcNow;

        [System.ComponentModel.DataAnnotations.Required]
        public Guid Id { get; set; }

        [Display(Name = "Название (заголовок)")]
        public virtual string? Title { get; set; }

        [Display(Name = "Краткое описание (подзаголовок)")]
        public virtual string? Subtitle { get; set; }

        [Display(Name = "Полное описание")]
        public virtual string? Text { get; set; }

        [Display(Name = "Изображение")]
        public virtual string? TitleImagePath { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }


    }
}
