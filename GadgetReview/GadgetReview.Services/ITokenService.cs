using GadgetReview.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace GadgetReview.Services
{
    public interface ITokenService
    {
        public string CreateToken(ApplicationUserIdentity user);
    }
}
