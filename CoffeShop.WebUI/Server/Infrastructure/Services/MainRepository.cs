using System;
using CoffeShop.WebUI.Server.Data;
using CoffeShop.WebUI.Server.Data.Entities;
using CoffeShop.WebUI.Server.Infrastructure.Abstract;

namespace CoffeShop.WebUI.Server.Infrastructure.Services
{
	public class MainRepository : IRepository
    {
		private readonly StoreDbContext _context;
		public MainRepository(StoreDbContext context)
		{
			_context = context;
		}

        public IQueryable<Category> Categories => _context.Categories;

        public IQueryable<Product> Products => _context.Products;

        public IQueryable<Customer> Customers => _context.Customers;

        public IQueryable<Order> Orders => _context.Orders;

        public IQueryable<OrderDetail> OrderDetails => _context.OrderDetails;

        public IQueryable<OrderState> OrderStates => _context.OrderStates;

        public void Add<T>(T entity) where T: BaseEntity
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return (await _context.SaveChangesAsync(cancellationToken) > 0);
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}

