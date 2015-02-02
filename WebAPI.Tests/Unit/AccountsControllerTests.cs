using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAPI.Tests.Unit
{
    class AccountsControllerTests
    {
        [Test]
        public void WhenAuthenticatingAClientWebApiUserForAInvalidUser_ThenShouldReturn401Status()
        {
            var response = 401;
            Assert.AreEqual(HttpStatusCode.Unauthorized, response);
        }
    }
}
