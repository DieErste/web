#pragma checksum "C:\work\git\eam590\sql\MyShop\MyShop\Views\Items\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "596d99fce78a2e58266eadf8ce5099ee911d6dcb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Items_List), @"mvc.1.0.view", @"/Views/Items/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Items/List.cshtml", typeof(AspNetCore.Views_Items_List))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"596d99fce78a2e58266eadf8ce5099ee911d6dcb", @"/Views/Items/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7dcbd9537796d68e14dc62f290295092beb40f07", @"/Views/_ViewImports.cshtml")]
    public class Views_Items_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ItemsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(23, 29, true);
            WriteLiteral("<div class=\"row mt-1 mb-5\">\r\n");
            EndContext();
#line 3 "C:\work\git\eam590\sql\MyShop\MyShop\Views\Items\List.cshtml"
     if(!String.IsNullOrEmpty(Model.currentCategory))
    {

#line default
#line hidden
            BeginContext(114, 12, true);
            WriteLiteral("        <h2>");
            EndContext();
            BeginContext(127, 21, false);
#line 5 "C:\work\git\eam590\sql\MyShop\MyShop\Views\Items\List.cshtml"
       Write(Model.currentCategory);

#line default
#line hidden
            EndContext();
            BeginContext(148, 7, true);
            WriteLiteral("</h2>\r\n");
            EndContext();
#line 6 "C:\work\git\eam590\sql\MyShop\MyShop\Views\Items\List.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(179, 12, true);
            WriteLiteral("        <h2>");
            EndContext();
            BeginContext(192, 15, false);
#line 9 "C:\work\git\eam590\sql\MyShop\MyShop\Views\Items\List.cshtml"
       Write(Model.modelName);

#line default
#line hidden
            EndContext();
            BeginContext(207, 7, true);
            WriteLiteral("</h2>\r\n");
            EndContext();
#line 10 "C:\work\git\eam590\sql\MyShop\MyShop\Views\Items\List.cshtml"
    }

#line default
#line hidden
            BeginContext(221, 32, true);
            WriteLiteral("</div>\r\n<div class=\"row mb-5\">\r\n");
            EndContext();
#line 13 "C:\work\git\eam590\sql\MyShop\MyShop\Views\Items\List.cshtml"
      
        foreach (Item item in Model.items)
        {
            

#line default
#line hidden
            BeginContext(329, 30, false);
#line 16 "C:\work\git\eam590\sql\MyShop\MyShop\Views\Items\List.cshtml"
       Write(Html.Partial("AllItems", item));

#line default
#line hidden
            EndContext();
#line 16 "C:\work\git\eam590\sql\MyShop\MyShop\Views\Items\List.cshtml"
                                           ;
        }
    

#line default
#line hidden
            BeginContext(380, 6, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ItemsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591