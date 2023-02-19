using Retail.Model;
using System;
using System.Collections.Generic;
using System.Text;
using api.CodeTest.DAL.Models;
using api.CodeTest.DAL.Repositories.Interfaces;

namespace api.CodeTest.DAL.Repositories
{
    public class AccountRepository<TEntity> : IAccountRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
