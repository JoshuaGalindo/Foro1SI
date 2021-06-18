using System;
using System.ComponentModel.DataAnnotations;

namespace pruebaSI.Models
{
    public class Department
    {
       
        
            [Key]
            public int DepartmentId { get; set; }

            [Display(Name = "Nombre")]
            public string DepartmentName { get; set; }

            

            
        
    }
}
