using System.Web;
using System.Web.Mvc;

namespace DapperMerybettAvila
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
