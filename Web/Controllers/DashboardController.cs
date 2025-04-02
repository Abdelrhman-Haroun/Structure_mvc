using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entities.IRepositories;
using Utilities;

namespace Web.Controllers
{
    [Authorize(Roles = SD.AdminRole)]
    public class DashboardController : Controller
    {

        private IUnitOfWork _unitOfWork;
        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            //ViewBag.Orders = _unitOfWork.OrderHeader.GetAll().Count();
            //ViewBag.ApprovedOrders = _unitOfWork.OrderHeader.GetAll(x => x.OrderStatus == SD.Approved).Count();
            ViewBag.Users = _unitOfWork.ApplicationUser.GetAll().Count();
            //ViewBag.Products = _unitOfWork.Product.GetAll().Count();
            return View();
        }
    }
}
