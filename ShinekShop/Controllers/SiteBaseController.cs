using Microsoft.AspNetCore.Mvc;

namespace ShinekShopWeb.Controllers
{
    public class SiteBaseController : Controller
    {
        protected string ErrorMessage = "ErrorMessage";
        protected string SuccessMessage = "SuccessMessage";
        protected string InformationMessage = "InformationMessage";
        protected string WarningMessage = "WarningMessage";
    }
}
