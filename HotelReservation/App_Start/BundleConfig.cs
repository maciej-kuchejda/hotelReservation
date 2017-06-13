using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace HotelReservation.App_Start
{
    public class BundleConfig
    {
        internal static void RegisterBundles(BundleCollection bundles)
        {
            bundles
                .Add(
                    new ScriptBundle("~/bundles/script")
                        .Include(
                            "~/Scripts/jquery-1.9.1.js",
                            "~/Scripts/bootstrap.js",
                            "~/Scripts/angular.js",
                            "~/Scripts/angular-animate.js",
                            "~/Scripts/angular-touch.js",
                            "~/Scripts/angular-sanitize.js",
                            "~/Scripts/angular-ui-router.js",
                            "~/Scripts/angular-ui/ui-bootstrap.js",
                            "~/Scripts/angular-ui/ui-bootstrap-tpls.js"
                            )
                        .Include("~/app/app.module.js", "~/app/app.config.js")
                        .IncludeDirectory("~/app/", "*.js", true)
                );

            bundles.Add(new StyleBundle("~/Content/site")
                .Include("~/Content/bootstrap.min.css", "~/Content/Site.css", "~/Content/Font.css"
                    , "~/Content/ui-bootstrap-csp.css"));
        }
    }
}