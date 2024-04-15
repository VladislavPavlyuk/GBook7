using Microsoft.AspNetCore.Mvc;
using GBook.Models;

namespace GBook.Repository
{
    public interface IRepository
    {
       // public IActionResult Create();
        //public Task<IActionResult> Create([Bind("Message")] Messages mes);
        public Task<List<Messages>> GetMessageList();
    }
}
