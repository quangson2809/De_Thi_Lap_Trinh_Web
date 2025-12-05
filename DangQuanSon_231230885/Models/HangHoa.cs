using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DangQuanSon_231230885.Models;

public partial class HangHoa
{
    [Required]
    public int MaHang { get; set; }
    [Required]
    public int MaLoai { get; set; }
    [Required]
    public string TenHang { get; set; } = null!;
    [Required]
    [Range(100,5000,ErrorMessage ="giá 100 -> 5000")]
    public decimal? Gia { get; set; }
    [Required]
    public string? Anh { get; set; }

    public virtual LoaiHang MaLoaiNavigation { get; set; } = null!;
}
