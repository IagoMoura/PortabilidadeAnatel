using Common.Contracts;
using Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace YUM.Service.Host
{
    /// <summary>
    /// Summary description for YumService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class YumService : System.Web.Services.WebService
    {
        [WebMethod]
        public bool UpdateCustomer(Customer customer)
        {
            return Repository.UpdateCustomer(customer);
        }
    }
}
