using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using work_togther.Model;

namespace work_togther.Service
{
    public class work_togther_service
    {
        private WorkTogtherContext _context = new WorkTogtherContext();

        /// <summary>
        /// 查询管理员信息
        /// </summary>
        /// <param name="login_name"></param>
        /// <param name="login_pass_word"></param>
        /// <returns></returns>
        public admin Get_Admin(string login_name, string login_pass_word)
        {
            var admin = _context.admin.Where(a => a.login_name == login_name && login_pass_word == login_pass_word).FirstOrDefault();
            return admin;
        }
    }
}
