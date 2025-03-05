﻿using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WebApi.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        public bool IsGlutenFree { get; set; }

        public Sauce? Sauce { get; set; }
        public ICollection<Topping>? Toppings { get; set; }
    }


}
