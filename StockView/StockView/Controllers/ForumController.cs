using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockView.Models.Forum;

namespace StockView.Controllers
{
    public class ForumController : Controller
    {
        //We're gonna have to delete this controller aren't we?
        private readonly IForum _forumService;

        public ForumController(IForum forumService)
        {
            _forumService = forumService;
        }

        public IActionResult Index()
        {
            var forums = _forumService.GetAll().Select(forum => new ForumListingModel
            {
                Id = forum.Id,
                Name = forum.Title,
                Content = forum.Content
            });

            var model = new ForumIndexModel
            {
                ForumList = forums
            };
            return View();
        }
    }
}
