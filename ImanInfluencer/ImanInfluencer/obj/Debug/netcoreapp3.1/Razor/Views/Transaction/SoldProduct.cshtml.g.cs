#pragma checksum "C:\Users\kamel\Desktop\Training\ImanInfluencer\ImanInfluencer\ImanInfluencer\Views\Transaction\SoldProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aeaa562c6077334b24544d395d1b5ed2f51b55cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Transaction_SoldProduct), @"mvc.1.0.view", @"/Views/Transaction/SoldProduct.cshtml")]
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
#nullable restore
#line 1 "C:\Users\kamel\Desktop\Training\ImanInfluencer\ImanInfluencer\ImanInfluencer\Views\_ViewImports.cshtml"
using ImanInfluencer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\kamel\Desktop\Training\ImanInfluencer\ImanInfluencer\ImanInfluencer\Views\_ViewImports.cshtml"
using ImanInfluencer.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aeaa562c6077334b24544d395d1b5ed2f51b55cf", @"/Views/Transaction/SoldProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea5b59277d5a1fad60d2a183ba3ede725e8896d6", @"/Views/_ViewImports.cshtml")]
    public class Views_Transaction_SoldProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ImanInfluencer.Models.Transaction>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img rounded-0 img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Client", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ViewItem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("h3 text-decoration-none"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\kamel\Desktop\Training\ImanInfluencer\ImanInfluencer\ImanInfluencer\Views\Transaction\SoldProduct.cshtml"
  
    ViewData["Title"] = "BuyedProduct";
    Layout = "~/Views/Shared/_UserDashboardLayout.cshtml";


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<div class=\"container py-5\">\r\n    <div class=\"row\">\r\n\r\n        <div class=\"col-lg-9\">\r\n            <div class=\"row\">\r\n            </div>\r\n            <div class=\"row\">\r\n");
#nullable restore
#line 17 "C:\Users\kamel\Desktop\Training\ImanInfluencer\ImanInfluencer\ImanInfluencer\Views\Transaction\SoldProduct.cshtml"
                 foreach (var item in Model)
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-md-3\">\r\n                        <div class=\"card mb-4 product-wap rounded-0\">\r\n                            <div class=\"card rounded-0\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "aeaa562c6077334b24544d395d1b5ed2f51b55cf5751", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 659, "~/Images/", 659, 9, true);
#nullable restore
#line 23 "C:\Users\kamel\Desktop\Training\ImanInfluencer\ImanInfluencer\ImanInfluencer\Views\Transaction\SoldProduct.cshtml"
AddHtmlAttributeValue("", 668, item.Product.Images.FirstOrDefault().Imagepath, 668, 47, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                            </div>\r\n                            <div class=\"card-body\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aeaa562c6077334b24544d395d1b5ed2f51b55cf7511", async() => {
#nullable restore
#line 27 "C:\Users\kamel\Desktop\Training\ImanInfluencer\ImanInfluencer\ImanInfluencer\Views\Transaction\SoldProduct.cshtml"
                                                                                                                                    Write(item.Product.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 27 "C:\Users\kamel\Desktop\Training\ImanInfluencer\ImanInfluencer\ImanInfluencer\Views\Transaction\SoldProduct.cshtml"
                                                                                   WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                <ul class=""w-100 list-unstyled d-flex justify-content-between mb-0"">
                                    <li class=""pt-2"">
                                        <span class=""product-color-dot color-dot-red float-left rounded-circle ml-1""></span>
                                        <span class=""product-color-dot color-dot-blue float-left rounded-circle ml-1""></span>
                                        <span class=""product-color-dot color-dot-black float-left rounded-circle ml-1""></span>
                                        <span class=""product-color-dot color-dot-light float-left rounded-circle ml-1""></span>
                                        <span class=""product-color-dot color-dot-green float-left rounded-circle ml-1""></span>
                                    </li>
                                </ul>

                                <p class=""text-center mb-0 ""><span class=""price"">");
#nullable restore
#line 38 "C:\Users\kamel\Desktop\Training\ImanInfluencer\ImanInfluencer\ImanInfluencer\Views\Transaction\SoldProduct.cshtml"
                                                                            Write(item.Product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>                                <p>Date of selling : ");
#nullable restore
#line 38 "C:\Users\kamel\Desktop\Training\ImanInfluencer\ImanInfluencer\ImanInfluencer\Views\Transaction\SoldProduct.cshtml"
                                                                                                                                                           Write(item.Actiondate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <h6>Sold to:</h6>\r\n                                <p>");
#nullable restore
#line 40 "C:\Users\kamel\Desktop\Training\ImanInfluencer\ImanInfluencer\ImanInfluencer\Views\Transaction\SoldProduct.cshtml"
                              Write(item.Buyer.Userlogin1s.FirstOrDefault().Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <p>");
#nullable restore
#line 41 "C:\Users\kamel\Desktop\Training\ImanInfluencer\ImanInfluencer\ImanInfluencer\Views\Transaction\SoldProduct.cshtml"
                              Write(item.Buyer.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 46 "C:\Users\kamel\Desktop\Training\ImanInfluencer\ImanInfluencer\ImanInfluencer\Views\Transaction\SoldProduct.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ImanInfluencer.Models.Transaction>> Html { get; private set; }
    }
}
#pragma warning restore 1591
