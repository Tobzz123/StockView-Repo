using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockView.Models.Forum
{
    public class ReplyPost
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public virtual GenericUser User { get; set; }
        public virtual Post post { get; set; }
    }
}
