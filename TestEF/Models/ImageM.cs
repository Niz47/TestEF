using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestEF.Models
{
    public class ImageM
    {
        [Key]
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
    }
}