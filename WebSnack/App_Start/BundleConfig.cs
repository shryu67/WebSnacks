using System.Web;
using System.Web.Optimization;

namespace WebSnack
{
    public class BundleConfig
    {
        // 如需統合的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js", "~/Scripts/jquery.min.js",
                        "~/Scripts/jquery.sticky.js", "~/Scripts/jquery.easing.min.js",
                        "~/Scripts/jquery.scrollTo.js", "~/Scripts/jquery.appear.js",
                        "~/Scripts/jquery-ui.js"));
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/stellar.js",
                        "~/Scripts/nivo-lightbox.min.js", "~/Scripts/custom.js",
                        "~/Scripts/css3-animate-it.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好可進行生產時，請使用 https://modernizr.com 的建置工具，只挑選您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/bootstrap-datepicker.min.js",
                      "~/Scripts/locales/bootstrap-datepicker.zh-TW.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-datepicker3.min.css",
                      "~/Content/animations.css", "~/Content/style.css",
                      "~/Content/nivo-lightbox.css", "~/Content/nivo-lightbox-theme/default/default.css",
                      "~/Content/font-awesome/css/font-awesome.min.css", "~/Content/color/default.css",
                      "~/Content/site.css"));
        }
    }
}
