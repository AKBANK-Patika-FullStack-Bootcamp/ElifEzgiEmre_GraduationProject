using Proje.Data.Models;
using Proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Controllers
{
    public class DBOperations
    {
        private ProjectContext _projectContext = new ProjectContext();


        public void AddUser(User _user)
        {
            _projectContext.Users.Add(_user);
            _projectContext.SaveChanges();

        }
        public List<User> GetUsers()
        {
            List<User> userList = new List<User>();
            //userList = AddUser();
            userList = _projectContext.Users.OrderBy(m => m.IdentificationNumber).ToList();
            return userList;

        }

        public User GetAirplane(string identificationNumber)
        {
            //List<User> userList = new List<User>();
            //userList = AddUser();

            //User resultObject = new User();
            //resultObject = userList.FirstOrDefault(x => x.Id == id);
            //return resultObject;
            return _projectContext.Users.FirstOrDefault(x => x.IdentificationNumber == identificationNumber);
        }

        public List<User> Update(User newValue, User oldValue)
        {


            _projectContext.Users.Remove(oldValue);
            _projectContext.Users.Add(newValue);
            _projectContext.SaveChanges();



            return GetUsers();
        }
        public void Delete(User oldValue)
        {
            _projectContext.Users.Remove(oldValue);
            _projectContext.SaveChanges();

        }


        //Bill

        public void AddBill(Bill _bill)
        {
            _projectContext.Bills.Add(_bill);
            _projectContext.SaveChanges();

        }
        public List<Bill> GetBills()
        {
            List<Bill> billList = new List<Bill>();
            //userList = AddUser();
            billList = _projectContext.Bills.OrderBy(m => m.FlatId).ToList();
            return billList;

        }

        public Bill GetBill(int _flatId)
        {
            //List<User> userList = new List<User>();
            //userList = AddUser();

            //User resultObject = new User();
            //resultObject = userList.FirstOrDefault(x => x.Id == id);
            //return resultObject;
            return _projectContext.Bills.FirstOrDefault(x => x.FlatId == _flatId);
        }

        public List<Bill> BillUpdate(Bill newValue, Bill oldValue)
        {


            _projectContext.Bills.Remove(oldValue);
            _projectContext.Bills.Add(newValue);
            _projectContext.SaveChanges();



            return GetBills();
        }
        public void BillDelete(Bill oldValue)
        {
            _projectContext.Bills.Remove(oldValue);
            _projectContext.SaveChanges();

        }
    }
}
