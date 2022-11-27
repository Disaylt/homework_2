using homework_2.Models;

namespace homework_2.Services.Friends
{
    public class StubFriendsService : IFriendsService
    {
        public FriendModel Add(FriendModel friend)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public FriendModel? Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FriendModel> GetAll()
        {
            return new List<FriendModel>();
        }

        public bool Update(FriendModel friend)
        {
            throw new NotImplementedException();
        }
    }
}
