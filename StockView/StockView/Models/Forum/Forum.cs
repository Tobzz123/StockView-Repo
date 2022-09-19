using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockView.Models.Forum
{
    public class Forum
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public DateTime Created { get; set; }

        public virtual GenericUser User { get; set; }
        public virtual Forum forum { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }


    }
}
