using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestEF.Models
{
    public class Anime
    {
        [Key]
        public int ID { get; set; }
        public string URL { get; set; }
        public string IMGURL { get; set; }
        public string TITLE { get; set; }
        public string AIRING { get; set; }
        public string DESCRIPTION { get; set; }
        public string TYPE { get; set; }
        public long EPISODES { get; set; }
        public decimal SCORE { get; set; }
        public Nullable<System.DateTime> SDATE { get; set; }
        public Nullable<System.DateTime> EDATE { get; set; }
    }
}