using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_04_Join_Demo.Models
{
    //[Owned]
    public class Address
    {
        public int ?BlocNum { get; set; }
        public string ?Street { get; set; }
        public string ?City { get; set; }
        public string ?Country { get; set; }
    }
}
