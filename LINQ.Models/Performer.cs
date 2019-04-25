using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Models
{
    public class Performer : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
