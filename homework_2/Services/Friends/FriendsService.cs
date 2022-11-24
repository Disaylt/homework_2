using homework_2.Models;

namespace homework_2.Services.Friends
{
    public class FriendsService : IFriendsService
    {
        private static int _lastId = 0;
        private static object _lock = new object();

        private readonly List<FriendModel> _friends;

        public FriendsService()
        {
            _friends = new List<FriendModel>();
        }

        public FriendModel Add(FriendModel friend)
        {
            friend.Id = GetNewId();
            _friends.Add(friend);

            return friend;
        }

        public bool Delete(int id)
        {
            FriendModel? friend = _friends.FirstOrDefault(x => x.Id == id);
            if(friend == null) return false;

            _friends.Remove(friend);

            return true;
        }

        public bool Update(FriendModel newFriend)
        {
            bool isDelete = Delete(newFriend.Id);
            if(!isDelete) return false;

            _friends.Add(newFriend);

            return true;
        }

        public IEnumerable<FriendModel> GetAll()
        {
            return _friends;
        }

        public FriendModel? Get(int id)
        {
            FriendModel? friend = _friends.FirstOrDefault(x => x.Id == id);

            return friend;
        }

        private int GetNewId()
        {
            lock (_lock)
            {
                _lastId += 1;
                int newId = _lastId;

                return newId;
            }
        }
    }
}
