using Common;
using Common.Exceptions;
using Common.Utilities;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CategoryTagRepository : Repository<CategoryTag>, ICategoryTagRepository
    {
        public CategoryTagRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

    }
}
