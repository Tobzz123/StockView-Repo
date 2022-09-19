using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockView.Models.Forum
{
    public interface IForum
    {
        Forum GetForumID(int id);
        IEnumerable<Forum> GetAll();
        IEnumerable<GenericUser> GetActiveUsers();

        Task Create(Forum forum);
        Task Delete(int forumId);
        Task UpdateForumTitle(int forumId, string newTitle);
        Task UpdateForumDescription(int forumId, string newDesc);

    }
}
