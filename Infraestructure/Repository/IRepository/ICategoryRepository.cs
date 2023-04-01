﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void  UpdateCategory(Category category);
    }
}
