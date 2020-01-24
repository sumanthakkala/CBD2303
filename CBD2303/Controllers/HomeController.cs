using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CBD2303.Models;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;

namespace CBD2303.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyDatabaseContext _dbContext { get; set; }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _dbContext = new MyDatabaseContext();
            _dbContext.Database.EnsureCreated();
        }

        public IActionResult Index(int id = 1)
        {
            var userStatusDetails = new UserStatuses();
            userStatusDetails.UserStatusesList = new List<StatusTextsWithLikes>();
            userStatusDetails.user = _dbContext.Users.FromSqlRaw("select * from Users where UserID = {0}", id).FirstOrDefault();
            var userPostedStatusList = _dbContext.StatusTexts.FromSqlRaw("select * from StatusTexts inner join Relationships on StatusTexts.UserID = Relationships.FollowingID where Relationships.FollowerID={0}", id).ToList<StatusTexts>();
            foreach (var item in userPostedStatusList)
            {
                var temp = new StatusTextsWithLikes();
                temp.StatusId = item.StatusId;
                temp.StatusText = item.StatusText;
                temp.UserID = item.UserID;
                temp.LikeDetails = _dbContext.Likes.FromSqlRaw("select * from Likes where StatusID={0} and UserID={1}", item.StatusId, id).ToList();
                userStatusDetails.UserStatusesList.Add(temp);
            }
            return View(userStatusDetails);
        }
        public IActionResult Profile(int id)
        {
            id = (id == 0) ? 1 : id;
            var userStatusDetails = new UserStatuses();
            userStatusDetails.UserStatusesList = new List<StatusTextsWithLikes>();
            userStatusDetails.user = _dbContext.Users.FromSqlRaw("select * from Users where UserID = {0}", id).FirstOrDefault();
            var userPostedStatusList = _dbContext.StatusTexts.FromSqlRaw("select * from StatusTexts where UserID={0}", id).ToList<StatusTexts>();
            foreach (var item in userPostedStatusList)
            {
                var temp = new StatusTextsWithLikes();
                temp.StatusId = item.StatusId;
                temp.StatusText = item.StatusText;
                temp.UserID = item.UserID;
                temp.LikeDetails = _dbContext.Likes.FromSqlRaw("select * from Likes where StatusID={0}", item.StatusId).ToList();
                userStatusDetails.UserStatusesList.Add(temp);
            }
            return View(userStatusDetails);
        }

        public IActionResult PostStatus(long userID, string statusText)
        {
            var statusModel = new StatusTexts();
            statusModel.StatusText = statusText;
            statusModel.UserID = userID;
            statusModel.StatusId = new Random().Next();
            _dbContext.StatusTexts.Add(statusModel);
            _dbContext.SaveChanges();
            return StatusCode(200);

        }
        public IActionResult EditStatusByID(int statusID, long userID, string statusText)
        {
            var statusModel = new StatusTexts();
            statusModel.StatusText = statusText;
            statusModel.UserID = userID;
            statusModel.StatusId = statusID;
            _dbContext.Update<StatusTexts>(statusModel);
            _dbContext.SaveChanges();
            return StatusCode(200);
        }
        public IActionResult DeleteStatusByID(long statusID)
        {
            _dbContext.StatusTexts.Remove(new StatusTexts { StatusId = statusID});
            _dbContext.SaveChanges();
            return StatusCode(200);

        }
        public IActionResult LikeStatusByID(long userID, long statusID)
        {
            var likeModel = new Likes();
            likeModel.StatusID = statusID;
            likeModel.UserID = userID;
            likeModel.LikeId = new Random().Next();
            _dbContext.Likes.Add(likeModel);
            _dbContext.SaveChanges();
            return StatusCode(200);

        }
        public IActionResult DislikeStatusByID(long likeID)
        {
            _dbContext.Likes.Remove(new Likes { LikeId = likeID });
            _dbContext.SaveChanges();
            return StatusCode(200);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}