﻿namespace ProductManagementSystem.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Name}, {Description}, {Price}";
        }
    }
}
