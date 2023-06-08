﻿using System;
namespace CoffeShop.WebUI.Shared.Common
{
	public static class ApiUrls
	{
		public static class CategoryUrls
		{
			private const string BaseUrl = "api/Categories";

			public const string GetCategories = $"{BaseUrl}";
			public static string GetCategoryById(int id) => $"{BaseUrl}/{id}";
            public const string CreateCategory = $"{BaseUrl}";
            public static string UpdateCategory(int id) => $"{BaseUrl}/{id}";
			public static string DeleteCategory(int id) => $"{BaseUrl}/{id}";
        }

		public static class ProductUrls
		{
            private const string BaseUrl = "api/Products";

        }
    }
}

