﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrangWebBanQuatDieuHoa.Models.Products
{
    public class Brand
    {
        [Key]

        public int BrandId { get; set; }
        [Required, MaxLength(100)]
        [Display(Name = "Tên Hãng")]
        public string BrandName { get; set; }
        
        public ICollection<Product> Products { get; set; }
    }
}
