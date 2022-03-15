using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace libraryAPI.Entities
{
    public class Authors
    {
        public int Id { get; set; }
        public int IdBook { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }

    }
}
