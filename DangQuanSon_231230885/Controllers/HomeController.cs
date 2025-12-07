using DangQuanSon_231230885.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection;

namespace DangQuanSon_231230885.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SystemDbContext systemDbContext;

        public HomeController(ILogger<HomeController> logger,SystemDbContext dbcontext)
        {
            _logger = logger;
            systemDbContext = dbcontext;
        }

        public IActionResult Index()
        {
            TempData["name"] = "Dang Quang Son";
            List<HangHoa> list = systemDbContext.HangHoas
                                    .Where(h => h.Gia >= 100)
                                    .ToList();
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FillterByCategory(int id)
        {
            TempData["name"] = "Dang Quang Son";
            List<HangHoa> list = systemDbContext.HangHoas
                                    .Where(h => h.MaLoai == id && h.Gia >= 100)
                                    .ToList();
            return PartialView("DangQuangSon_MainContent", list);
        }

        [HttpGet()]
        public IActionResult Create()
        {

            ViewBag.Menu = new List<SelectListItem>();
            
            List<LoaiHang> categories = systemDbContext.LoaiHangs.ToList();
            foreach(var loaihang in categories)
            {
                ViewBag.Menu.Add(new SelectListItem { Text = loaihang.TenLoai, Value = loaihang.MaLoai.ToString() });
            }

            return View();
        }

        [HttpPost()]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MaLoai, TenHang, Gia, Anh")] HangHoaCreate hanghoacreate)
        {
            TempData["name"]= "Dang Quang Son";

            //s.DateOfBirth = Convert.ToDateTime(s.DateOfBirth.ToString());
            if (ModelState.IsValid)
            {
                var extension = Path.GetExtension(hanghoacreate.Anh.FileName);

                var fileName = $"{hanghoacreate.TenHang}{extension}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    hanghoacreate.Anh.CopyTo(stream);
                }

                HangHoa hanghoa = new HangHoa();

                hanghoa.Anh = fileName;
                hanghoa.MaLoai = hanghoacreate.MaLoai;
                hanghoa.TenHang = hanghoacreate.TenHang;
                hanghoa.Gia = hanghoacreate.Gia;
                //systemDbContext.HangHoas.Add(hanghoa);
                //systemDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // set lại ViewBag
            ViewBag.Menu = new SelectList(systemDbContext.LoaiHangs ,"MaLoai","TenLoai",hanghoacreate.MaLoai);
            return View(hanghoacreate);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
