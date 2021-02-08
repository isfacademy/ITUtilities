using System.Web;
using System.Web.Optimization;

namespace ITUtilities
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            //Bootstrap RTL Scripts
            bundles.Add(new ScriptBundle("~/bundles/bootstrapRTL").Include(
                      "~/Content/BootstrapRTL/js/bootstrap.min.js"
                      ));

            //Datatable Scripts
            bundles.Add(new ScriptBundle("~/bundles/Datatable").Include(
                      "~/Content/DataTables/datatables.min.js"));
            //Datatable Styles
            bundles.Add(new StyleBundle("~/Content/Datatable").Include(
                      "~/Content/DataTables/datatables.rtl.css"));

            //Fancybox Scripts
            bundles.Add(new ScriptBundle("~/bundles/Fancy").Include(
                      "~/Content/Fancybox/source/jquery.fancybox.js"));
            //Fancybox Styles
            bundles.Add(new StyleBundle("~/Content/Fancy").Include(
                      "~/Content/Fancybox/source/jquery.fancybox.css"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                      "~/Scripts/functions.js"));

            //Treant Scripts
            bundles.Add(new ScriptBundle("~/bundles/TreeTreantJS").Include(
                      "~/Content/TreeTreant/js/raphael.js",
                      "~/Content/TreeTreant/js/Treant.js",
                      "~/Content/TreeTreant/js/jquery.easing.js",
                      "~/Content/TreeTreant/js/collapsable.js"));

            //Treant Styles
            bundles.Add(new StyleBundle("~/Content/TreeTreantJS").Include(
                      "~/Content/TreeTreant/css/Treant.css",
                      "~/Content/TreeTreant/css/collapsable.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //Bootstrap RTL Styles
            bundles.Add(new StyleBundle("~/Content/cssRTL").Include(
                      "~/Content/BootstrapRTL/css/bootstrap.min.css",
                      "~/Content/site.css"));
        }
    }
}
