#pragma checksum "C:\work\git\eam590\sql\MyShop\MyShop\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "65f144d272072bcc88228f8bfb9f946f8447dc4d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\work\git\eam590\sql\MyShop\MyShop\Views\_ViewImports.cshtml"
using MyShop.ViewModels;

#line default
#line hidden
#line 2 "C:\work\git\eam590\sql\MyShop\MyShop\Views\_ViewImports.cshtml"
using MyShop.Data.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65f144d272072bcc88228f8bfb9f946f8447dc4d", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7dcbd9537796d68e14dc62f290295092beb40f07", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HomeViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(22, 39, true);
            WriteLiteral("\r\n<div class=\"row mt-1 mb-5\">\r\n    <h2>");
            EndContext();
            BeginContext(62, 15, false);
#line 4 "C:\work\git\eam590\sql\MyShop\MyShop\Views\Home\Index.cshtml"
   Write(Model.modelName);

#line default
#line hidden
            EndContext();
            BeginContext(77, 41, true);
            WriteLiteral("</h2>\r\n</div>\r\n\r\n<div class=\"row mb-5\">\r\n");
            EndContext();
#line 8 "C:\work\git\eam590\sql\MyShop\MyShop\Views\Home\Index.cshtml"
      
        foreach (Item item in Model.favouriteItems)
        {
            

#line default
#line hidden
            BeginContext(203, 30, false);
#line 11 "C:\work\git\eam590\sql\MyShop\MyShop\Views\Home\Index.cshtml"
       Write(Html.Partial("AllItems", item));

#line default
#line hidden
            EndContext();
#line 11 "C:\work\git\eam590\sql\MyShop\MyShop\Views\Home\Index.cshtml"
                                           ;
        }
    

#line default
#line hidden
            BeginContext(254, 6, true);
            WriteLiteral("</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HomeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
