using System.Web.Mvc;

namespace PhotoExploration.Controllers
{
    public class CommentsController : Controller
    {
        // GET: Comments
        [AllowAnonymous]
        public ActionResult Comments()
        {
            return PartialView();
        }
    }
}