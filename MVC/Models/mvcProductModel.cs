using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class mvcProductModel
    {

        [Required(ErrorMessage = "Serial Number is required")]
        public int SN { get; set; }
        [Required(ErrorMessage = "ProductName is required")]
        [StringLength(100, ErrorMessage = "ProductName can't be longer than 100 characters")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description can't be longer than 500 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Created date is required")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Created { get; set; }
    }
}