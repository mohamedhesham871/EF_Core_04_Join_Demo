using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_04_Join_Demo.Models
{
    public class Department
    {
        public int Id { get; set; }//PK
        public required string Name { get; set; }
        public string? Description { get; set; }

        #region Relation one to many {One -Deparment to Many  Employee
        //Nav prop 
        [InverseProperty(nameof(Empolyee.Department))]
        public virtual ICollection<Empolyee>? empolyees { get; set; }
        #endregion

        #region Relation one to one Manager 
        //FK
        [ForeignKey("Manager")]
        public int ?ManagerId { get; set; }
        [InverseProperty(nameof(Empolyee.Manage))]
        public virtual Empolyee? Manager { get; set; }
        #endregion
    }
}
