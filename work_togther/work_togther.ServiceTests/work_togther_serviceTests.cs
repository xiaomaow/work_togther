using Microsoft.VisualStudio.TestTools.UnitTesting;
using work_togther.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work_togther.Service.Tests
{
    [TestClass()]
    public class work_togther_serviceTests
    {
        [TestMethod()]
        public void Get_AdminTest()
        {
            work_togther_service _service = new work_togther_service();
          var _admin=  _service.Get_Admin("xiaomaow", "123456");
            if (_admin == null)
            {
                Assert.Fail();
            }
            else
            {
                Console.WriteLine("查询成功");
            }
        }
    }
}