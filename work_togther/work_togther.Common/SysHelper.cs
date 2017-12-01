using System;
using System.Diagnostics;
using System.Threading;
using System.Web;

namespace work_togther.Common
{
    /// <summary>
    /// 系统操作相关的公共类
    /// </summary>
    public class SysHelper
    {
        #region 获取文件相对路径映射的物理路径
        /// <summary>
        /// 获取文件相对路径映射的物理路径
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <returns></returns>
        public string GetPath(string virtualPath)
        {
            return HttpContext.Current.Server.MapPath(virtualPath);
        }
        #endregion


        #region 获取指定调用层级的方法名
        /// <summary>
        /// 获取指定调用层级的方法名
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public string GetMethodName(int level)
        {
            //创建一个堆栈跟踪
            StackTrace trace = new StackTrace();
            //获得制定调用层架的方法名
            return trace.GetFrame(level).GetMethod().Name;
        }
        #endregion

        #region 获取GUID的值
        /// <summary>
        /// 获取GUID值
        /// </summary>
        public string NewGUID
        {
            get {
                return Guid.NewGuid().ToString();
            }
        }
        #endregion

        #region 获取当前应用程序域
        /// <summary>
        /// 获取当前应用程序域
        /// </summary>
        public AppDomain CurrentAppDomain
        {
            get
            {
                return Thread.GetDomain();
            }
        }
        #endregion
    }
}
