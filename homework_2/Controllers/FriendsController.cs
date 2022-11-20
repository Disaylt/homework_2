using homework_2.Models;
using homework_2.Services.Friends;
using Microsoft.AspNetCore.Mvc;

namespace homework_2.Controllers
{
    public class FriendsController : Controller
    {
        private readonly IFriendsService _friendsService;

        public FriendsController(IFriendsService friendsService)
        {
            _friendsService = friendsService;
        }

        public IActionResult Index()
        {
            IEnumerable<FriendModel> friends = _friendsService.GetAll();
            return View(friends);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new FriendModel());
        }

        [HttpPost]
        public IActionResult Create(FriendModel friend)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Message = "Получился не четкий друг, проверь данные." });

            _friendsService.Add(friend);

            return Redirect("/friends");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            FriendModel? friend = _friendsService.Get(id);

            if (friend == null)
                return NotFound(new { Message = "Братик у тебя нет такого друга." });

            return View(friend);
        }

        [HttpPost]
        public IActionResult Update(FriendModel friend)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Message = "Получился не четкий друг, проверь данные." });

            bool isUpdate = _friendsService.Update(friend);

            if (!isUpdate)
                return BadRequest(new { Message = "Не удалось обновить друга =(" });

            return Redirect("/friends");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            bool isDelete = _friendsService.Delete(id);

            if (!isDelete)
                return StatusCode(StatusCodes.Status404NotFound, new { Message = "Ты не удалишь друга, потому что его не существует! =)" });

            return Redirect("/friends");
        }
    }
}
