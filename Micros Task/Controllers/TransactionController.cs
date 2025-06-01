using Micros_Task.Data;
using Micros_Task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Micros_Task.Controllers
{
    public class TransactionController : Controller
    {
        private readonly AppDbContext _context;
        public TransactionController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Transaction> transactions = _context.Transaction
                .OrderBy(x => x.Id)
                .Include(y => y.Category)
                .ToList();
            return View(transactions);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Transaction transaction = new();
            transaction.Categories = _context.Category.ToList(); 
            return View(transaction);
        }

        [HttpPost]
        public IActionResult Create(Transaction transaction)
        {
            _context.Transaction.Add(transaction);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
