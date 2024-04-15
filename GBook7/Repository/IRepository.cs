using Microsoft.AspNetCore.Mvc;
using GBook.Models;

namespace GBook.Repository
{
    public interface IRepository
    { 
        Task<List<Messages>> GetMessageList();
        Task Create(Messages mes);
        Task Save();

    }
}
