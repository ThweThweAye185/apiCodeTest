using api.CodeTest.DAL.Models;
using api.CodeTest.DAL.Repositories.Interfaces;
using api.CodeTest.DAL.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace api.CodeTest.DAL.Services
{
    public class TransactionAuditService : ITransactionAuditService
    {
        private readonly IRepository<TransactionAudit> _tranAuditRepository;
        private readonly IMapper _mapper;
        public TransactionAuditService(IRepository<TransactionAudit> tranAuditRepository, IMapper mapper)
        {
            _tranAuditRepository = tranAuditRepository;
            _mapper = mapper;
        }
        public async Task<bool> CreateTranAuditAsync(TransactionAudit transactionAudit)
        {
            try
            {
                transactionAudit.Id = System.Guid.NewGuid().ToString();
                transactionAudit.Active = true;
                transactionAudit.CreatedBy = "admin";
                transactionAudit.CreatedDate = DateTime.Now;
                transactionAudit.UpdatedDate = DateTime.Now;
                await _tranAuditRepository.AddAsync(transactionAudit);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
