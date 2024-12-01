using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quiz.Domain.Entity;

namespace Quiz.Domain.Repository
{
    public interface IHistoryResultRepository
    {
        Task Insert(HistoryResult historyResult);
        Task<HistoryResult> Get(int id_user);
    }
}