﻿namespace ECommerceAPI.Application.Features.Product.Categories.Commands.AddCategory.DTOs
{
    public class AddCategoryCommandDTO
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? ParentCategory { get; set; }

        #endregion Properties
    }
}