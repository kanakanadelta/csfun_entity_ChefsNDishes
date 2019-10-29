using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System;

using ChefsNDishes.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsNDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
        
        [NotMapped]
        public int Age 
        {
            get 
            {
                DateTime now = DateTime.Today;
                int age = now.Year - DateOfBirth.Year;
                if(DateOfBirth > now.AddYears(-age))
                    age--;
                return age;
            }
        }
        public List<Dish> CreatedDishes {get; set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public Chef()
        {
            CreatedDishes = new List<Dish>();
        }

    }
}