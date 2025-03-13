using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_04_Join_Demo.Models
{
    public  class Empolyee
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int ?Age { get; set; }
        public required string Email { get; set; }
        public decimal  Salary { get; set; }
        //One to one Total Relation
        public  Address DetailedAddress { get; set; }

        #region Relation one to many (Emp Work in Deparment)
        //FK
        [ForeignKey("Department")]
        public  int? DeparmentId { get; set; }
        //nav porperty
        [InverseProperty(nameof(Models.Department.empolyees))]
        public virtual Department? Department { get; set; }
        #endregion

        #region Relation one to one (Emp manager one Deparment)
        [InverseProperty(nameof(Models.Department.Manager))]
        public virtual Department? Manage { set; get; }
        #endregion
    }
}
