using DangQuanSon_231230885.Models;
namespace DangQuanSon_231230885.ViewComponents
{
    public class HeaderViewComponent: Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly SystemDbContext SystemDbContext;
        public HeaderViewComponent( SystemDbContext dbContext) => this.SystemDbContext = dbContext;
        
        public async Task<Microsoft.AspNetCore.Mvc.IViewComponentResult> InvokeAsync()
        {
            TempData["name"] = "Dang Quang Son";
            List<LoaiHang> list = SystemDbContext.LoaiHangs.ToList();
            return View("DangQuangSon_Header",list);
        }
    }
}
