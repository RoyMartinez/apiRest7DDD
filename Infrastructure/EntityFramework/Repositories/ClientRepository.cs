﻿using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityFramework.Repositories
{
    public class ClientRepository : EntityFrameworkBaseRepository<Client>, IEntityFrameworkClientRepository
    {
        public ClientRepository(ApiRestDbContext context) : base(context)
        {
        }
    }
}
