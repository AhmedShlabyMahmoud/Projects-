#pragma checksum "E:\ITI\SecondProjectIti\FristProjectIti\FristProjectIti\Views\patients\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "11b36045ff1487f58b357571a5ebc50c197e7cbb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_patients_Details), @"mvc.1.0.view", @"/Views/patients/Details.cshtml")]
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
#line 1 "E:\ITI\SecondProjectIti\FristProjectIti\FristProjectIti\Views\_ViewImports.cshtml"
using FristProjectIti;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\ITI\SecondProjectIti\FristProjectIti\FristProjectIti\Views\_ViewImports.cshtml"
using FristProjectIti.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11b36045ff1487f58b357571a5ebc50c197e7cbb", @"/Views/patients/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e159004c88c390e1bb57bcb373242fec2c5dc1c3", @"/Views/_ViewImports.cshtml")]
    public class Views_patients_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Patient>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Doctors", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("250"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Patients", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<dl>\r\n    <dt>id : </dt>\r\n    <dd>");
#nullable restore
#line 4 "E:\ITI\SecondProjectIti\FristProjectIti\FristProjectIti\Views\patients\Details.cshtml"
   Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n    <dt>age : </dt>\r\n    <dd>");
#nullable restore
#line 6 "E:\ITI\SecondProjectIti\FristProjectIti\FristProjectIti\Views\patients\Details.cshtml"
   Write(Model.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n    <dt>name :</dt>\r\n    <dd>");
#nullable restore
#line 8 "E:\ITI\SecondProjectIti\FristProjectIti\FristProjectIti\Views\patients\Details.cshtml"
   Write(Model.Fullname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n    <dt>Diagnesis :</dt>\r\n    <dd>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "11b36045ff1487f58b357571a5ebc50c197e7cbb5627", async() => {
                WriteLiteral("\r\n            ");
#nullable restore
#line 12 "E:\ITI\SecondProjectIti\FristProjectIti\FristProjectIti\Views\patients\Details.cshtml"
       Write(Model.Doctors.Description);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 11 "E:\ITI\SecondProjectIti\FristProjectIti\FristProjectIti\Views\patients\Details.cshtml"
                                                           WriteLiteral(Model.Doctors.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n    </dd>\r\n\r\n    <dt>Date Of Birth :</dt>\r\n    <dd>");
#nullable restore
#line 18 "E:\ITI\SecondProjectIti\FristProjectIti\FristProjectIti\Views\patients\Details.cshtml"
   Write(Model.BirthDay.ToString("dd-mm-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n    <dt>");
#nullable restore
#line 20 "E:\ITI\SecondProjectIti\FristProjectIti\FristProjectIti\Views\patients\Details.cshtml"
   Write(Html.DisplayNameFor(e => e.injuryTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n    <dd>");
#nullable restore
#line 21 "E:\ITI\SecondProjectIti\FristProjectIti\FristProjectIti\Views\patients\Details.cshtml"
   Write(Model.injuryTime.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n    <dt>");
#nullable restore
#line 23 "E:\ITI\SecondProjectIti\FristProjectIti\FristProjectIti\Views\patients\Details.cshtml"
   Write(Html.DisplayNameFor(e => e.LastUpdateDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n    <dd>");
#nullable restore
#line 24 "E:\ITI\SecondProjectIti\FristProjectIti\FristProjectIti\Views\patients\Details.cshtml"
   Write(Model.LastUpdateDate.ToShortTimeString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n    <dt>");
#nullable restore
#line 26 "E:\ITI\SecondProjectIti\FristProjectIti\FristProjectIti\Views\patients\Details.cshtml"
   Write(Html.DisplayNameFor(e => e.PersonalImageName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n    <dd>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "11b36045ff1487f58b357571a5ebc50c197e7cbb9974", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 28 "E:\ITI\SecondProjectIti\FristProjectIti\FristProjectIti\Views\patients\Details.cshtml"
       WriteLiteral("~/images/"+Model.PersonalImageName);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#nullable restore
#line 28 "E:\ITI\SecondProjectIti\FristProjectIti\FristProjectIti\Views\patients\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </dd>\r\n\r\n\r\n</dl>\r\n<br />\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "11b36045ff1487f58b357571a5ebc50c197e7cbb12143", async() => {
                WriteLiteral("Back To List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Patient> Html { get; private set; }
    }
}
#pragma warning restore 1591
