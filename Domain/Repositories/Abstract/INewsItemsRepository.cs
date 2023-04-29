using System;
using System.Linq;
using MyCompany.Domain.Entities;

namespace MyCompany.Domain.Repositories.Abstract
{
    public interface INewsItemsRepository
    {
        IQueryable<NewsItem> GetServiceItems();
        NewsItem GetServiceItemById(Guid id);

		
		void SaveServiceItem(NewsItem entity);
        void DeleteServiceItem(Guid id);
        IQueryable<NewsItem> GetLastServiceItems(int count);
    }
}
