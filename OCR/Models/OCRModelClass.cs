using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCR.Models
{
    public class OCRModelClass
    {
        public List<SelectListItem> languages { get; set; }
        public String language { get; set; }


        public HttpPostedFileBase file { get; set; }
    }
}