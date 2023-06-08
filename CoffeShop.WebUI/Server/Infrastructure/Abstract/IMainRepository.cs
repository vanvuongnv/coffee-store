using System;
using CoffeShop.WebUI.Server.Data.Entities;

namespace CoffeShop.WebUI.Server.Infrastructure.Abstract
{
	public interface IRepository
	{
		IQueryable<Category> Categories { get; }
		IQueryable<Product> Products { get; }
		IQueryable<Customer> Customers { get; }
		IQueryable<Order> Orders { get; }
		IQueryable<OrderDetail> OrderDetails { get; }
		IQueryable<OrderState> OrderStates { get; }

        void Add<T>(T entity) where T: BaseEntity;
        void Update<T>(T entity) where T : BaseEntity;
        void Delete<T>(T entity) where T : BaseEntity;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}

