#pragma checksum "E:\git\Spice\Eczamen\Eczamen\Areas\Admin\Views\Category\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d018a2eef3a053a8a6ccbefbe918ff0a19a904cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Category_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Category/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Category/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_Category_Index))]
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
#line 1 "E:\git\Spice\Eczamen\Eczamen\Areas\Admin\Views\_ViewImports.cshtml"
using Eczamen;

#line default
#line hidden
#line 2 "E:\git\Spice\Eczamen\Eczamen\Areas\Admin\Views\_ViewImports.cshtml"
using Eczamen.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d018a2eef3a053a8a6ccbefbe918ff0a19a904cb", @"/Areas/Admin/Views/Category/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf772bb6fa7c5d7f8a13b4b9d2083155c19488a4", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Category_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Eczamen.Entitie.Category>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_CreateButtonPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_TableButtonPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(46, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\git\Spice\Eczamen\Eczamen\Areas\Admin\Views\Category\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(136, 227, true);
            WriteLiteral("<br/>\r\n<br/>\r\n<div class=\"border backgroundWhite\">\r\n    <div class=\"row\">\r\n        <div class=\"col-6\">\r\n            <h2 class=\"text-info\"> Category List</h2>\r\n        </div>\r\n        <div class=\"col-6 text-right\">\r\n            ");
            EndContext();
            BeginContext(363, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d018a2eef3a053a8a6ccbefbe918ff0a19a904cb4433", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(401, 53, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <br />\r\n    <div>\r\n");
            EndContext();
#line 20 "E:\git\Spice\Eczamen\Eczamen\Areas\Admin\Views\Category\Index.cshtml"
         if (Model.Count() > 0)
        {

#line default
#line hidden
            BeginContext(498, 178, true);
            WriteLiteral("            <table class=\"table table-striped border\">\r\n                <thead>\r\n                <tr class=\"table-secondary\">\r\n                    <th >\r\n                        ");
            EndContext();
            BeginContext(677, 48, false);
#line 26 "E:\git\Spice\Eczamen\Eczamen\Areas\Admin\Views\Category\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.NameCategory));

#line default
#line hidden
            EndContext();
            BeginContext(725, 165, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th></th>\r\n                    <th></th>\r\n                </tr>\r\n                </thead>\r\n                <tbody>\r\n");
            EndContext();
#line 33 "E:\git\Spice\Eczamen\Eczamen\Areas\Admin\Views\Category\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(955, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1040, 47, false);
#line 37 "E:\git\Spice\Eczamen\Eczamen\Areas\Admin\Views\Category\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.NameCategory));

#line default
#line hidden
            EndContext();
            BeginContext(1087, 92, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td></td>\r\n                        ");
            EndContext();
            BeginContext(1179, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d018a2eef3a053a8a6ccbefbe918ff0a19a904cb7561", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#line 40 "E:\git\Spice\Eczamen\Eczamen\Areas\Admin\Views\Category\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = item.Id;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1233, 29, true);
            WriteLiteral("\r\n                    </tr>\r\n");
            EndContext();
#line 42 "E:\git\Spice\Eczamen\Eczamen\Areas\Admin\Views\Category\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(1281, 50, true);
            WriteLiteral("\r\n                </tbody>\r\n            </table>\r\n");
            EndContext();
#line 46 "E:\git\Spice\Eczamen\Eczamen\Areas\Admin\Views\Category\Index.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(1367, 42, true);
            WriteLiteral("            <p>No category exists...</p>\r\n");
            EndContext();
#line 50 "E:\git\Spice\Eczamen\Eczamen\Areas\Admin\Views\Category\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1420, 30, true);
            WriteLiteral("    </div>\r\n    \r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Eczamen.Entitie.Category>> Html { get; private set; }
    }
}
#pragma warning restore 1591