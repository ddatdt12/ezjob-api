using EzjobApi.Core.Contracts;
using EzjobApi.Models;

namespace EzjobApi.Core.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context, ILogger logger) : base(context, logger)
        {

        }

    }
}
