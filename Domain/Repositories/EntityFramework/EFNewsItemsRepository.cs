using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyCompany.Domain.Entities;
using MyCompany.Domain.Repositories.Abstract;

namespace MyCompany.Domain.Repositories.EntityFramework
{
    public class EFNewsItemsRepository : INewsItemsRepository
    {
        private readonly AppDbContext context;
        public EFNewsItemsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<NewsItem> GetServiceItems()
        {
            return context.NewsItems;
        }

        public IQueryable<NewsItem> GetLastServiceItems(int count)
        {
            return context.NewsItems.Take(count);
        }

        public NewsItem GetServiceItemById(Guid id)
        {
            return context.NewsItems.FirstOrDefault(x => x.Id == id);
        }

		

		public void SaveServiceItem(NewsItem entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteServiceItem(Guid id)
        {
            context.NewsItems.Remove(new NewsItem() { Id = id });
            context.SaveChanges();
        }
    }
}
