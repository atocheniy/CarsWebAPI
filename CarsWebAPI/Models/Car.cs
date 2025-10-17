using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsWebAPI.Models
{
    [Table("MyCar")]
    public class Car
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите марку машины.")]
        [StringLength(30, ErrorMessage = "Название марки не должно превышать 30 символов")]
        [Display(Name = "Марка машины")]
        public String Brand { get; set; }

        [Required(ErrorMessage = "Введите модель машины.")]
        [StringLength(30, ErrorMessage = "Название модели не должно превышать 30 символов")]
        [Display(Name = "Модель машины")]
        public String Model { get; set; }

        [Required(ErrorMessage = "Введите скорость машины.")]
        [Range(100, 600, ErrorMessage = "Скорость от 100 до 600")]
        [Display(Name = "Скорость")]
        public int Speed { get; set; }

        [Required(ErrorMessage = "Введите вес машины.")]
        [Range(100, 10000, ErrorMessage = "Вес от 100 до 10000")]
        [Display(Name = "Вес машины")]
        public int Weight { get; set; }

        [Required(ErrorMessage = "Введите цену машины.")]
        [Display(Name = "Цена машины")]
        [Range(0, int.MaxValue, ErrorMessage = "Цена от 0")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Введите год машины.")]
        [Display(Name = "Год выпуска")]
        public DateTime Year { get; set; }
    }
}
