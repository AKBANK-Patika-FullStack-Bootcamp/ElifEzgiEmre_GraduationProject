using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Data.Models
{
    public class Result
    {
          public int Status { get; set; }

        public string Message { get; set; }

        public List<User>? UserList { get; set; }
        public List<Bill>? BillList { get; set; }
    }
}
