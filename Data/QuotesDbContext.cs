using CRMWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMWebApi.Data
{
    public class QuotesDbContext:DbContext
    {
        public QuotesDbContext(DbContextOptions<QuotesDbContext> options) : base(options)
        {
        }
        public DbSet<PersonModel> People { get; set; }
    }
}
