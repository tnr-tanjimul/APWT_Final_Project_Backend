using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string CommenterName { get; set; }
        public Nullable<int> NewsId { get; set; }
    }
}
