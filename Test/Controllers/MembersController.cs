using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test.Models;
using Test.Models.VMs;

namespace Test.Controllers
{
    public class MembersController : Controller
    {
        private readonly BigProjectContext _context;

        public MembersController(BigProjectContext context)
        {
            _context = context;
        }

        // GET: Members
        public async Task<IActionResult> Index(string account)
        {
            IQueryable<Member> members = _context.Members.Include(x => x.Photos);

            // 透過Input Text進行Search

            if (!string.IsNullOrEmpty(account)) members = members.Where(x => x.Account.Contains(account));

            IEnumerable<MemberVM> vms = await members
                .Select(x => new MemberVM()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Account = x.Account,
                    Password = x.Password,
                    Photos = x.Photos,
                }).ToListAsync();

              return View(vms);
        }
    }
}
