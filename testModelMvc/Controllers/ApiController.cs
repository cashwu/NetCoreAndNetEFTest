using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using LIb.Model.BaseModel;
using LIb.Model.EF;

namespace testModelMvc.Controllers
{
    public class ApiController : Controller
    {
        [Route("api")]
        public async Task<ActionResult> Index()
        {
            var connectionString = "Data Source=10.211.55.4;Initial Catalog=Test;Persist Security Info=True;User ID=rd;Password=rd;MultipleActiveResultSets=True";
            using var testDbContextForEf = new TestDbContextForEf(connectionString);

            testDbContextForEf.Users.Add(new User{ Name = Guid.NewGuid().ToString()});
            await testDbContextForEf.SaveChangesAsync();

            var users = await testDbContextForEf.Users.ToListAsync();

            return Json(new { count = users.Count, users }, JsonRequestBehavior.AllowGet);
        }
    }
}