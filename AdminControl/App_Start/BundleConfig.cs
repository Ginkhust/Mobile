using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace AdminControl.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Css bundles
            bundles.Add(new StyleBundle("~/Content/vender").Include(
                    "~/Content/vendor/fontawesome/css/font-awesome.css",
                    "~/Content/vendor/metisMenu/dist/metisMenu.css",
                    "~/Content/vendor/animate.css/animate.css",
                    "~/Content/vendor/bootstrap/dist/css/bootstrap.css"
                ));

            bundles.Add(new StyleBundle("~/Content/app").Include(
                    "~/fonts/pe-icon-7-stroke/css/pe-icon-7-stroke.css",
                    "~/fonts/pe-icon-7-stroke/css/helper.css",
                    "~/Content/styles/style.css"
                ));

            bundles.Add(new StyleBundle("~/Content/summernote").Include(
                    "~/Content/summernote/summernote.css"
                ));

            // Script bundles
            bundles.Add(new StyleBundle("~/Scripts/summernote").Include(
                    "~/Content/summernote/summernote.js"
                ));

            bundles.Add(new StyleBundle("~/Scripts/vender").Include(
                    "~/Content/vendor/jquery/dist/jquery.min.js",
                    "~/Content/vendor/jquery-ui/jquery-ui.min.js",
                    "~/Content/vendor/slimScroll/jquery.slimscroll.min.js",
                    "~/Content/vendor/bootstrap/dist/js/bootstrap.min.js",
                    "~/Content/vendor/jquery-flot/jquery.flot.js",
                    "~/Content/vendor/jquery-flot/jquery.flot.resize.js",
                    "~/Content/vendor/jquery-flot/jquery.flot.pie.js",
                    "~/Content/vendor/flot.curvedlines/curvedLines.js",
                    "~/Content/vendor/jquery.flot.spline/index.js",
                    "~/Content/vendor/metisMenu/dist/metisMenu.min.js",
                    "~/Content/vendor/iCheck/icheck.min.js",
                    "~/Content/vendor/peity/jquery.peity.min.js",
                    "~/Content/vendor/sparkline/index.js"
                ));

            bundles.Add(new StyleBundle("~/Scripts/app").Include(
                    "~/Scripts/homer.js"
                ));

            bundles.Add(new StyleBundle("~/Content/checkbox_datepicker").Include(
                    "~/Content/vendor/select2-3.5.2/select2.css",
                    "~/Content/vendor/select2-bootstrap/select2-bootstrap.css",
                    "~/Content/vendor/xeditable/bootstrap3-editable/css/bootstrap-editable.css",
                    "~/Content/vendor/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.min.css",
                    "~/Content/vendor/bootstrap-datepicker-master/dist/css/bootstrap-datepicker3.min.css",
                    "~/Content/vendor/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css"
                ));

            bundles.Add(new StyleBundle("~/Scripts/checkbox_datepicker").Include(
                    "~/Content/vendor/xeditable/bootstrap3-editable/js/bootstrap-editable.min.js",
                    "~/Content/vendor/select2-3.5.2/select2.min.js",
                    "~/Content/vendor/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.min.js",
                    "~/Content/vendor/bootstrap-datepicker-master/dist/js/bootstrap-datepicker.min.js"
                ));


        }
    }
}