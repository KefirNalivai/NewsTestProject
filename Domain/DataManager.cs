using MyCompany.Domain.Repositories.Abstract;

namespace MyCompany.Domain
{
    public class DataManager
    {
        public INewsItemsRepository NewsItems { get; set; }

        public DataManager(INewsItemsRepository serviceItemsRepository)
        {           
            NewsItems = serviceItemsRepository;
        }
    }
}
