using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System;

namespace ChefsNDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid calorie count")]
        public int Calories { get; set; }

        [Required]
        [Range(1,5)]
        public int Tastiness { get; set; }

        [Required]
        public string Description { get; set; }

        public Chef Creator { get; set; }

    }
}