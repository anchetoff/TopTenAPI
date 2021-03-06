using System.Web;
using System.Web.Optimization;

namespace Top10Covid19
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/default").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/scripts/underscore*",
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/DataTables/jquery.dataTables.*",
                        "~/Scripts/DataTables/dataTables.buttons.js",
                        "~/Scripts/DataTables/buttons.html5.js",
                        "~/Scripts/DataTables/buttons.print.js",
                        "~/scripts/bootstrap.*")) ;
            /* bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                         "~/Scripts/jquery-{version}.js"));

             bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                         "~/Scripts/jquery.validate*"));

             bundles.Add(new ScriptBundle("~/bundles/DataTable").Include(
                       "~/Scripts/DataTables/dataTables.js"));*/


            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            /*bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));*/

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/DataTables/css/jquery.dataTables.css",
                      "~/Content/DataTables/css/buttons.dataTables.css"));

            

        }
    }
}
