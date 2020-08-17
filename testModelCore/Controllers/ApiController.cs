using System;
using System.Linq;
using System.Threading.Tasks;
using LIb.Model.BaseModel;
using LIb.Model.EFCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace testModelCore.Controllers
{
    public class ApiController : Controller
    {
        private readonly TestDbContextForEfCore _dbContext;

        public ApiController(TestDbContextForEfCore dbContext)
        {
            _dbContext = dbContext;
        }
        
        [Route("api")]
        public async Task<IActionResult> Index()
        {
            await _dbContext.Users.AddAsync(new User { Name = Guid.NewGuid().ToString() });
            await _dbContext.SaveChangesAsync();

            var users = await _dbContext.Users.ToListAsync();

            return Json(new { count = users.Count, users });
        }
    }
}