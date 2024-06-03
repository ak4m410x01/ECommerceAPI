﻿namespace ECommerceAPI.Application.Features.Product.Categories.Queries.GetById.DTOs
{
    public class GetByIdQueryDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ParentCategory { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}