using homework_2.Models;

namespace homework_2.Services.Friends
{
    public interface IFriendsService
    {
        public int Add(FriendModel friend);
        public bool Update(FriendModel friend);
        public bool Delete(int id);
        public FriendModel? Get(int id);
        public IEnumerable<FriendModel> GetAll();
    }
}
