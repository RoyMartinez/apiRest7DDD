using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dapper.Repositories
{
    public class DapperVendorRepository: DapperBaseRepository<Vendor>, IDapperVendorRepository
    {
        public DapperVendorRepository(IConfiguration configuration):base(configuration)
        {
                
        }
    }
}
