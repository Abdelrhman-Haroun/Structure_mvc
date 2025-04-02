using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Data;
using Utilities;
using System.Security.Claims;

namespace Web.Controllers
{
	[Authorize(Roles = SD.AdminRole)]
	public class UserController : Controller
	{
		private readonly ApplicationDbContext _context;
		public UserController(ApplicationDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
			string userid = claim.Value;
			return View(_context.ApplicationUsers.Where(x => x.Id != userid).ToList());
		}
		public IActionResult LockUnlock(string? id)
		{
			var user = _context.ApplicationUsers.FirstOrDefault(x => x.Id == id);
			if (user == null)
			{
				return NotFound();
			}
			if (user.LockoutEnd == null | user.LockoutEnd < DateTime.Now)
			{
				user.LockoutEnd = DateTime.Now.AddYears(1);
			}
			else
			{
				user.LockoutEnd = DateTime.Now;
			}
			_context.SaveChanges();
			return RedirectToAction("Index");
		}


		[HttpGet]
		public IActionResult Delete(string id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var user = _context.ApplicationUsers.FirstOrDefault(x => x.Id == id);
			return View(user);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(string id)
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
			string userid = claim.Value;
			var user = _context.ApplicationUsers.FirstOrDefault(x => x.Id == id);
			if (user == null)
			{
				return NotFound();
			}
			_context.ApplicationUsers.Remove(user);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
