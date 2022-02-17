using System;
using LotusTransformation.Models;
using System.Collections.Generic;
using System.Linq;

namespace LotusTransformation.ViewModels
{
    public class ExistingUserVM 
    { 
        public IQueryable<UserInformation> Account { get; set; }

    }
}
