using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace StockManageWebservice
{
    /// <summary>
    /// Service1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        DBOperation dbOperation = new DBOperation();

        [WebMethod(Description = "测试")]
        public string HelloWorld()
        {
            string str = "Hello World!!!";
            return str;
        }
        [WebMethod(Description = "获取所有物品信息")]
        public string[] selectAllCargoInfor()
        {
            return dbOperation.selectAllCargoInfor().ToArray();
        }

        [WebMethod(Description = "增加一条物品信息")]
        public bool insertCargoInfo(string Cname, int Cnum)
        {
            return dbOperation.insertCargoInfo(Cname, Cnum);
        }

        [WebMethod(Description = "删除一条物品信息")]
        public bool deleteCargoInfo(string Cno)
        {
            return dbOperation.deleteCargoInfo(Cno);
        }
    }
}