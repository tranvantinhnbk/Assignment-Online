using Assignment_Online.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web;
using Assignment_Online.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Assignment_Online.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
       
        private readonly ApplicationDbContext _context;

        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /HelloWorld/ 
        public async Task<IActionResult> Index()
        {
            return _context.Assignment != null ?
                        View(await _context.Assignment.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Assignment'  is null.");
        }

        // 
        // GET: /HelloWorld/Evaluate/ 
        [HttpPost]  
        public ActionResult Evaluate(List<string> answers)
        {
            foreach (var answer in answers)
            {
                System.Diagnostics.Debug.WriteLine("Answer: " + answer);
            }
            List<string> realAnswer = _context.Assignment.Select(a => a.Answer).ToList();

            // ChatGPT code 
            ViewData["total"] = realAnswer.Count;
            ViewData["correctPredictions"] = answers.Intersect(realAnswer).Count();


            return View();
        }
    }
}
