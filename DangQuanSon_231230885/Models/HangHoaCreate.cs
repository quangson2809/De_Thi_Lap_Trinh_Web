using System.ComponentModel.DataAnnotations;

namespace DangQuanSon_231230885.Models
{
    public class HangHoaCreate
    {
        public int MaLoai { get; set; }
        [Required(ErrorMessage = "Tên hàng không được bỏ trống")]
        public string TenHang { get; set; } = null!;
        [Required(ErrorMessage = "giá khôg được bỏ trống")]
        [Range(100, 5000, ErrorMessage = "giá 100 -> 5000")]
        public decimal? Gia { get; set; }

        [AllowedFileExtensions(new string[] { ".jpg", ".png", ".jpeg" })]
        public IFormFile? Anh { get; set; }

    }
}
