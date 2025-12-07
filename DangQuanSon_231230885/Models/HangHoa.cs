using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DangQuanSon_231230885.Models;

public partial class HangHoa
{
    public int MaHang { get; set; }
    [Required(ErrorMessage="loại hàng không được bỏ trống")]
    public int MaLoai { get; set; }
    [Required(ErrorMessage="Tên hàng không được bỏ trống")]
    public string TenHang { get; set; } = null!;
    [Required(ErrorMessage="giá khôg được bỏ trống")]
    [Range(100,5000,ErrorMessage ="giá 100 -> 5000")]
    public decimal? Gia { get; set; }
    public string? Anh { get; set; }

    public virtual LoaiHang MaLoaiNavigation { get; set; } = null!;
}
