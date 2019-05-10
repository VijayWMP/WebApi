using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRMWebApi.Models
{
    public class PersonModel
    {
            public int ID { get; set; }
           // [Required(ErrorMessage = "Please enter your first name")]
            public string Title { get; set; }
          //  [Required(ErrorMessage = "Please enter your last name")]
            public string Author { get; set; }
        
            public string Description { get; set; }
          
       
    }
}
