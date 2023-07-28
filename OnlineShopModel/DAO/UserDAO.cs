using OnlineShopModel.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace OnlineShopModel.DAO
{
    public class UserDAO
    {
        public IEnumerable<User> UserList(string searchStr, int page, int pageSize)
        {
            IQueryable<User> userList = DataProvider.Instance.DB.User;

            if (!string.IsNullOrEmpty(searchStr))
            {
                userList = userList.Where(u => u.Username.Contains(searchStr));
            }

            return userList.OrderBy(u => u.ID).ToPagedList(page, pageSize);
        }

        public long Insert(User entity)
        {
            DataProvider.Instance.DB.User.Add(entity);
            DataProvider.Instance.DB.SaveChanges();

            return entity.ID;
        }

        public bool Update(User userParam)
        {
            try
            {
                var user = DataProvider.Instance.DB.User.Where(u => u.ID == userParam.ID).SingleOrDefault();

                if (user != null)
                {
                    user.Username = userParam.Username;
                    user.Password = userParam.Password;
                    user.DisplayName = userParam.DisplayName;
                    user.Phone = userParam.Phone;
                    user.Email = userParam.Email;
                    user.Address = userParam.Address;
                    user.Birthday = userParam.Birthday;
                    user.ModifiedDate = DateTime.Now;
                    user.ModifiedBy = userParam.ModifiedBy;

                    DataProvider.Instance.DB.SaveChanges();
                    return true;
                }else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Delete(User userDel)
        {
            try
            {
                var user = DataProvider.Instance.DB.User.Where(u => u.ID == userDel.ID).FirstOrDefault();

                if (user != null)
                {
                    DataProvider.Instance.DB.User.Remove(user);
                    DataProvider.Instance.DB.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public User GetUserByID(string username)
        {
            return DataProvider.Instance.DB.User.FirstOrDefault(u => u.Username == username);
        }

        public User GetUserByID(int id)
        {
            return DataProvider.Instance.DB.User.Find(id);
        }

        public int Login(string username, string password)
        {
            var res = DataProvider.Instance.DB.User.Where(u => u.Username == username && u.Password == password).SingleOrDefault();

            if (res != null)
            {
                if (res.status == true)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -2;
            }
        }

        public bool ChangedStatus (long id)
        {
            var user = DataProvider.Instance.DB.User.Find(id);
            user.status = !user.status;
            DataProvider.Instance.DB.SaveChanges(); 
            return user.status;
        }
    }
}
