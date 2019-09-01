using System.Web;
using System.Web.Optimization;

namespace Economizar
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.validate.custom.pt-br*",
                        "~/Scripts/methods_pt.js"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-flatly.css",
                      "~/Content/site.css"));

            #region Template Design
            bundles.Add(new ScriptBundle("~/js").Include(
                     "~/lib/jquery/jquery.min.js",
                     "~/lib/jquery/jquery-migrate.min.js",
                     "~/lib/bootstrap/js/bootstrap.bundle.min.js",
                     "~/lib/easing/easing.min.js",
                     "~/lib/superfish/hoverIntent.js",
                     "~/lib/superfish/superfish.min.js",
                     "~/lib/wow/wow.min.js",
                     "~/lib/waypoints/waypoints.min.js",
                     "~/lib/counterup/counterup.min.js",
                     "~/lib/owlcarousel/owl.carousel.min.js",
                     "~/lib/isotope/isotope.pkgd.min.js",
                     "~/lib/lightbox/js/lightbox.min.js",
                     "~/lib/touchSwipe/jquery.touchSwipe.min.js",
                     "~/contactform/contactform.js",
                     "~/js/main.js"));

            bundles.Add(new StyleBundle("~/css").Include(
                     "~/lib/bootstrap/css/bootstrap.min.css",
                     "~/lib/font-awesome/css/font-awesome.min.css",
                     "~/lib/animate/animate.min.css",
                     "~/lib/ionicons/css/ionicons.min.css",
                     "~/lib/owlcarousel/assets/owl.carousel.min.css",
                     "~/lib/lightbox/css/lightbox.min.css",
                     "~/css/style.css"));
            #endregion
        }

    }
}
