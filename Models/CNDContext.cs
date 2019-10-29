using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Models
{
    public class CNDContext : DbContext
    {
        public CNDContext (DbContextOptions options) : base(options) {}

        //property will be a DbSet - a collection type from the Entity Framework library 
        //that you will provide your Model class in angle brackets
        //Your DBSet will refer to all data in your corresponding table as objects of the Model type you provide.
        public DbSet<Dish> Dishes {get; set;}
        public DbSet<Chef> Chefs {get; set;}
    }
}