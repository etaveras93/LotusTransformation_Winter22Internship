using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LotusTransformation.Models;
using LotusTransformation.ViewModels;
using LotusTransformation.Data;

namespace LotusTransformation.Controllers
{
    public class CreateAccountController : Controller
    {

        private LotusTransformationDBContext _efac;

        public CreateAccountController(LotusTransformationDBContext Acc)
        {
            _efac = Acc;
        }

        [HttpGet][RequireHttps]
        public ActionResult AccountCreation()
        {
            return View();
        }

        [HttpPost][RequireHttps]
        public IActionResult AccountCreation(UserSignUpVM NewUser)
        {
            if (ModelState.IsValid)
            {
                UserInformation user = new UserInformation()
                {
                    FirstName = NewUser.FirstName,
                    LastName = NewUser.LastName,
                    Address1 = NewUser.Address1,
                    City = NewUser.City,
                    StateOrProvince = NewUser.StateOrProvince,
                    ZIPorPostal = NewUser.ZIPorPostal,
                    Country = NewUser.Country,
                    UserName = NewUser.UserName,
                    Password = NewUser.Password,
                    PrimaryEmail = NewUser.PrimaryEmail,
                    PrimaryPhoneNumber = NewUser.PrimaryPhoneNumber,
                    PrimaryPhoneType = NewUser.PrimaryPhoneType,
                    SecondaryEmail = NewUser.SecondaryEmail,
                    DateOfBirth = NewUser.DateOfBirth,
                    SecondaryPhoneNumber = NewUser.SecondaryPhoneNumber,
                    SecondaryPhoneType = NewUser.SecondaryPhoneType,
                    MiddleInitial = NewUser.MiddleInitial,
                    Address2 = NewUser.Address2,
                };

                _efac.Add(user);
                _efac.SaveChanges();

                return View("CreationSuccess");
            }
            else return View();
        }
    }
}
