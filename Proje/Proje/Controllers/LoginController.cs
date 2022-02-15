using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Proje.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace Proje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        Result _result = new Result();
        DBOperations DbOpp = new DBOperations();

        [HttpGet]
        public List<User> GetUsers()
        {
            return DbOpp.GetUsers();
        }

        [HttpGet("{id}")]
        public User GetById(string id)
        {
            //staticList = new List<Airplane>();
            ////staticList = AddAirplane();

            //Airplane resultObject = new Airplane();
            //resultObject = staticList.FirstOrDefault(x => x.airplane_id == id);
            User resultObject = DbOpp.GetAirplane(id);
            return resultObject;
        }


        [HttpPost]
        public Result Post(User user)
        {

            //staticList = new List<Airplane>();
            //staticList = AddAirplane();


            //var airplaneCheck = staticList.FirstOrDefault(x => x.airplane_id == airplane.airplane_id);

            var userList = DbOpp.GetUsers();
            var userCheck = userList.FirstOrDefault(x => x.IdentificationNumber== user.IdentificationNumber);
            if (userCheck == null)
            {
                DbOpp.AddUser(user);
                userList.Add(user);
                _result.Status = 1;
                _result.Message = "Yeni eleman listeye eklendi.";
                _result.UserList = userList;
            }

            else
            {
                _result.Status = 0;
                _result.Message = "Eleman zaten listede var.";

            }
            return _result;
        }


        [HttpPut]
        public Result Update(User newValue)
        {
            //staticList = AddAirplane();
            var airplaneList = DbOpp.GetUsers();
            User? oldValue = airplaneList.Find(o => o.Name == newValue.Name && o.Surname == newValue.Surname);

            if (oldValue != null)
            {
                _result.Status = 1;
                _result.Message = "Başarıyla güncellendi.";
                DbOpp.Update(newValue, oldValue);
                _result.UserList = DbOpp.GetUsers();
                
            }

            else
            {
                _result.Status = 0;
                _result.Message = "Bu eleman listede yok.";

            }
            return _result;
        }
        [HttpDelete("{id}")]
        public Result Delete(string id)
        {
            //staticList = AddAirplane();
            var userList = DbOpp.GetUsers();
            User? oldValue = userList.Find(o => o.IdentificationNumber == id);

            if (oldValue != null)
            {
                _result.Status = 1;
                _result.Message = "Kulllanıcı başarıyla silindi.";

                DbOpp.Delete(oldValue);
                _result.UserList = DbOpp.GetUsers();

            }

            else
            {
                _result.Status = 0;
                _result.Message = "Kullanıcı bu listede yok.";

            }

            return _result;
        }


        /// Bill

        [HttpGet]
        public List<Bill> GetBills()
        {
            return DbOpp.GetBills();
        }

        [HttpGet("{id}")]
        public Bill GetById(int id)
        {
            
            Bill resultObject = DbOpp.GetBill(id);
            return resultObject;
        }


        [HttpPost]
        public Result Post(Bill bill)
        {


            var billList = DbOpp.GetBills();
            var billCheck = billList.FirstOrDefault(x => x.Id== bill.Id);
            if (billCheck == null)
            {
                DbOpp.AddBill(bill);
                billList.Add(bill);
                _result.Status = 1;
                _result.Message = "Yeni eleman listeye eklendi.";
                _result.BillList = billList;
            }

            else
            {
                _result.Status = 0;
                _result.Message = "Eleman zaten listede var.";

            }
            return _result;
        }


        [HttpPut]
        public Result Update(Bill newValue)
        {
            //staticList = AddAirplane();
            var billList = DbOpp.GetBills();
            Bill? oldValue = billList.Find(o => o.Id == newValue.Id);

            if (oldValue != null)
            {
                _result.Status = 1;
                _result.Message = "Başarıyla güncellendi.";
                DbOpp.BillUpdate(newValue, oldValue);
                _result.BillList = DbOpp.GetBills();

            }

            else { 
            
                _result.Status = 0;
                _result.Message = "Bu eleman listede yok.";

            }
            return _result;
        }
        [HttpDelete("{id}")]
        public Result Delete(int id)
        {
            //staticList = AddAirplane();
            var billList = DbOpp.GetBills();
            Bill? oldValue = billList.Find(o => o.Id == id);

            if (oldValue != null)
            {
                _result.Status = 1;
                _result.Message = "Kulllanıcı başarıyla silindi.";

                DbOpp.BillDelete(oldValue);
                _result.UserList = DbOpp.GetUsers();

            }

            else
            {
                _result.Status = 0;
                _result.Message = "Fatura bu listede yok.";

            }

            return _result;
        }
        //public static string GetRandomPassword(int length)
        //{
        //    const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        //    StringBuilder sb = new StringBuilder();
        //    Random rnd = new Random();

        //    for (int i = 0; i < length; i++)
        //    {
        //        int index = rnd.Next(chars.Length);
        //        sb.Append(chars[index]);
        //    }

        //    return sb.ToString();
        //}

        //public LoginController(IConfiguration config)
        //{
        //    _config = config;
        //}

        //[HttpGet]
        //public IActionResult Login(string email, string password)
        //{
        //    User login = new User();
        //    login.Email = email;
        //    login.Password = password;

        //    IActionResult response = Unauthorized();

        //    var user = AuthenticationUser(login);

        //    if (user != null)
        //    {
        //        var tokenStr = GenerateJSONWebToken(user);
        //        response = Ok(new { token = tokenStr });
        //    }

        //    return response;

        //}
        //private User AuthenticationUser(User login)
        //{
        //    User user = null;
        //    if(login.Email=="admin@gmail.com" && login.Password == "123")
        //    {
        //        user = new User { Email = "admin@gmail.com", Password = "123", Plaka = "34 G 6101", IdentificationNumber = "13813830580", Name = "Elif", Surname = "Emre" };
        //    }

        //    return user;
        //}

        //private string GenerateJSONWebToken(User userinfo)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var claims = new[]
        //    {
        //        new Claim(JwtRegisteredClaimNames.Sub,userinfo.Name),
        //        new Claim(JwtRegisteredClaimNames.Email,userinfo.Email),
        //        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
        //    };

        //    var token = new JwtSecurityToken(
        //        issuer: _config["Jwt:Issuer"],
        //        audience: _config["Jwt:Issuer"],
        //        claims,
        //        expires: DateTime.Now.AddMinutes(120),
        //        signingCredentials: credentials);

        //    var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
        //    return encodetoken;
        //}
        //[Authorize]
        //[HttpPost("Post")]
        //public string Post()
        //{
        //    var identity = HttpContext.User.Identity as ClaimsIdentity;
        //    IList<Claim> claim = identity.Claims.ToList();
        //    var userName = claim[0].Value;
        //    return "Welcome To: " + userName;
        //}
        //[Authorize]
        //[HttpGet("GetValue")]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "Value1", "Value2", "Value3" };
        //}
    }
}
