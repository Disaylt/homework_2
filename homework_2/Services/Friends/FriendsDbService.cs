using homework_2.Database;
using homework_2.Models;

namespace homework_2.Services.Friends
{
    public class FriendsDbService : IFriendsService
    {
        private readonly FriendContext _friendContext;
        public FriendsDbService(FriendContext friendContext)
        {
            _friendContext = friendContext;
        }

        public FriendModel Add(FriendModel friend)
        {
            _friendContext.Friends.Add(friend);
            _friendContext.SaveChanges();

            return friend;
        }

        public bool Delete(int id)
        {
            FriendModel? friend = Get(id);

            if(friend == null) return false;

            _friendContext.Friends.Remove(friend);
            _friendContext.SaveChanges();

            return true;
        }

        public FriendModel? Get(int id)
        {
            return _friendContext.Friends
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<FriendModel> GetAll()
        {
            IEnumerable<FriendModel> friends = _friendContext.Friends
                .ToList();

            return friends;
        }

        public bool Update(FriendModel friend)
        {
            _friendContext.Friends.Update(friend);
            _friendContext.SaveChanges();

            return true;
        }
    }
}
