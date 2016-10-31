using CardGame.Models;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CardGame
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitDeck();
        }
        public static void InitDeck()
        {
            var newDeck = new DeckModel();
            Controllers.HomeController._decks.Add(newDeck);
        }
    }
}
