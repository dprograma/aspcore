using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BulkyWeb.Models.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>  CategoryList { get; set; }
    }
}
