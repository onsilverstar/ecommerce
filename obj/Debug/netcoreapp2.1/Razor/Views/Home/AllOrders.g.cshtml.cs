#pragma checksum "C:\Users\onsil\OneDrive\Desktop\MyProjects\Commercial\Views\Home\AllOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0af2908f67143e5546e0898061a2f5516a4e5733"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_AllOrders), @"mvc.1.0.view", @"/Views/Home/AllOrders.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/AllOrders.cshtml", typeof(AspNetCore.Views_Home_AllOrders))]
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
#line 1 "C:\Users\onsil\OneDrive\Desktop\MyProjects\Commercial\Views\_ViewImports.cshtml"
using Commercial;

#line default
#line hidden
#line 2 "C:\Users\onsil\OneDrive\Desktop\MyProjects\Commercial\Views\_ViewImports.cshtml"
using Commercial.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0af2908f67143e5546e0898061a2f5516a4e5733", @"/Views/Home/AllOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e1eebfcfcd23d05fee292e62db99a0d37b9f55c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_AllOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Order>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Dashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddProduct", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Roles", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Adminstration", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(20, 114, true);
            WriteLiteral("<div class=\"container\">\r\n<div id=\"topbar\"\r\n    <nav class=\"navbar\">\r\n        <ul>\r\n            <li class=\"listed\">");
            EndContext();
            BeginContext(134, 48, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0af2908f67143e5546e0898061a2f5516a4e57334851", async() => {
                BeginContext(160, 18, true);
                WriteLiteral("<h4>Dashboard</h4>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(182, 38, true);
            WriteLiteral("</li>\r\n            <li class=\"listed\">");
            EndContext();
            BeginContext(220, 73, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0af2908f67143e5546e0898061a2f5516a4e57336272", async() => {
                BeginContext(269, 20, true);
                WriteLiteral("<h4>Add Product</h4>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(293, 38, true);
            WriteLiteral("</li>\r\n            <li class=\"listed\">");
            EndContext();
            BeginContext(331, 71, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0af2908f67143e5546e0898061a2f5516a4e57337901", async() => {
                BeginContext(384, 14, true);
                WriteLiteral("<h4>Roles</h4>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(402, 405, true);
            WriteLiteral(@"</li>
        </ul>
    </nav>
</div>
<div class=""tablewrapper"">
<table class=""table"">
    <thead>
        <tr>
            <td><strong>#<strong></strong></td>
            <td><strong>Date<strong></td>
            <td><strong>Shipping Address<strong></td>
            <td><strong>Order Total<strong></td>
            <td><strong>Status</strong></td>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 24 "C:\Users\onsil\OneDrive\Desktop\MyProjects\Commercial\Views\Home\AllOrders.cshtml"
          
            foreach(var k in Model)
            {

#line default
#line hidden
            BeginContext(871, 42, true);
            WriteLiteral("                <tr>\r\n                <td>");
            EndContext();
            BeginContext(914, 9, false);
#line 28 "C:\Users\onsil\OneDrive\Desktop\MyProjects\Commercial\Views\Home\AllOrders.cshtml"
               Write(k.OrderId);

#line default
#line hidden
            EndContext();
            BeginContext(923, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(951, 11, false);
#line 29 "C:\Users\onsil\OneDrive\Desktop\MyProjects\Commercial\Views\Home\AllOrders.cshtml"
               Write(k.CreatedAt);

#line default
#line hidden
            EndContext();
            BeginContext(962, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(990, 11, false);
#line 30 "C:\Users\onsil\OneDrive\Desktop\MyProjects\Commercial\Views\Home\AllOrders.cshtml"
               Write(k.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(1001, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1003, 10, false);
#line 30 "C:\Users\onsil\OneDrive\Desktop\MyProjects\Commercial\Views\Home\AllOrders.cshtml"
                            Write(k.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(1013, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1015, 9, false);
#line 30 "C:\Users\onsil\OneDrive\Desktop\MyProjects\Commercial\Views\Home\AllOrders.cshtml"
                                        Write(k.Address);

#line default
#line hidden
            EndContext();
            BeginContext(1024, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1026, 6, false);
#line 30 "C:\Users\onsil\OneDrive\Desktop\MyProjects\Commercial\Views\Home\AllOrders.cshtml"
                                                   Write(k.City);

#line default
#line hidden
            EndContext();
            BeginContext(1032, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1034, 9, false);
#line 30 "C:\Users\onsil\OneDrive\Desktop\MyProjects\Commercial\Views\Home\AllOrders.cshtml"
                                                           Write(k.ZipCode);

#line default
#line hidden
            EndContext();
            BeginContext(1043, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1045, 7, false);
#line 30 "C:\Users\onsil\OneDrive\Desktop\MyProjects\Commercial\Views\Home\AllOrders.cshtml"
                                                                      Write(k.State);

#line default
#line hidden
            EndContext();
            BeginContext(1052, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1080, 6, false);
#line 31 "C:\Users\onsil\OneDrive\Desktop\MyProjects\Commercial\Views\Home\AllOrders.cshtml"
               Write(k.Cost);

#line default
#line hidden
            EndContext();
            BeginContext(1086, 65, true);
            WriteLiteral("</td>\r\n                <td>Shipped </td>\r\n                </tr>\r\n");
            EndContext();
#line 34 "C:\Users\onsil\OneDrive\Desktop\MyProjects\Commercial\Views\Home\AllOrders.cshtml"

            }
        

#line default
#line hidden
            BeginContext(1179, 40, true);
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n</div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591
