using System;
using System.Collections.Generic;
using System.Linq;
using LotusTransformation.Data;
using LotusTransformation.Models;
using LotusTransformation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LotusTransformation.Controllers
{
    public class CreateAccountController : Controller
    {
        
        private readonly LotusTransformationDBContext _efac;
        private ExistingUserVM _existingUser;

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

            _existingUser = new ExistingUserVM() { Account = _efac.UserInformation };

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

                LogIn logIn = new LogIn()
                {
                    UserName = NewUser.UserName,
                    Password = NewUser.Password,
                    Email = NewUser.PrimaryEmail,
                    
                };


               // if (_existingUser.Account.Select(A => A.PrimaryEmail).Contains(NewUser.PrimaryEmail)) return View();// TODO: Make Email Already Exists View
                // if (_existingUser.Account.Select(A => A.SecondaryEmail).Contains(NewUser.SecondaryEmail)) return View(); //TODO: Make Backup email Already In use View
                // if (_existingUser.Account.Select(A => A.UserName).Contains(NewUser.UserName)) return View(); // TODO: Make UserName Already in Use View

                _efac.Add(user);
                _efac.Add(logIn);
                _efac.SaveChanges();

                return View("CreationSuccess");
            }
            else return View();
        }
    }
}
