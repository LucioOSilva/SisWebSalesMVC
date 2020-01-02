using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace SisWebSalesMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]      //parametros Name={0}
        [StringLength(60, MinimumLength = 3,ErrorMessage ="{0} size must be between {2} and {1}")] //parametros Name={0},MinimunLength={2},MaximunLength={1}
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Enter a valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")] //parametros BirthDate={0}
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} required")] //parametros BaseSalary={0}
        [Range(100.0 , 50000.0 , ErrorMessage = "{0} must be a value between {1} to {2}")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double BaseSalary { get; set; }
        public Department Department { get; set; } //Como temos o DepartmentID o mesmo ja é do tipo "required" e este também é selecionado por "caixa" de seleção no app.
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new LinkedList<SalesRecord>();
        

        public Seller()
        {
        }
        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
            
    }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }
        public double TotalSales(DateTime initial, DateTime Final)
        {
            return Sales.Where(x => x.Date >= initial && x.Date <= Final).Sum(x => x.Ammount);
        }
    }
}
