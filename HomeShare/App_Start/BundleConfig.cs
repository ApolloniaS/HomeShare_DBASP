using System.Web;
using System.Web.Optimization;

namespace HomeShare
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            //// prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/css/base-css").Include(
                "~/css/main-style.css",
                "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/css/owlcarousel-css").Include(
                "~/css/owl.carousel.css",
                "~/css/owl.theme.css"));

            bundles.Add(new StyleBundle("~/css/slitslider-css").Include(
                "~/css/style.css",
                "~/css/custom.css"));

            bundles.Add(new ScriptBundle("~/bundles/base-js").Include(
                "~/Scripts/jquery-1.9.1.min.js",
                "~/Scripts/bootstrap.js",
                "~/js/script.js"));

            bundles.Add(new ScriptBundle("~/bundles/owlcarousel-js").Include(
                "~/js/owl.carousel.js"));

            bundles.Add(new ScriptBundle("~/bundles/slitslider-js").Include(
                "~/js/modernizr.custom.79639.js",
                "~/js/jquery.ba-cond.min.js",
                "~/js/jquery.slitslider.js"));

        }
    }
}
