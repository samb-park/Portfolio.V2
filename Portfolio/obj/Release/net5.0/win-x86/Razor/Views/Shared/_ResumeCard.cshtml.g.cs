#pragma checksum "\\Mac\Home\Projects\Portfolio\Portfolio\Views\Shared\_ResumeCard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a94a167d02de8a461acd8f5368fc874252c50447"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ResumeCard), @"mvc.1.0.view", @"/Views/Shared/_ResumeCard.cshtml")]
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
#line 1 "\\Mac\Home\Projects\Portfolio\Portfolio\Views\_ViewImports.cshtml"
using Portfolio;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "\\Mac\Home\Projects\Portfolio\Portfolio\Views\_ViewImports.cshtml"
using Portfolio.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a94a167d02de8a461acd8f5368fc874252c50447", @"/Views/Shared/_ResumeCard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c04bce7982831a5298dbaf0154894cf857e44535", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ResumeCard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Portfolio.Models.Resume>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<div class=\"col-lg-6 p-2 resume_item\">\n    <div class=\"card\" style=\"background-color:#333;\">\n        <div class=\"card-body\">\n            <p class=\"card-subtitle text-light\">");
#nullable restore
#line 6 "\\Mac\Home\Projects\Portfolio\Portfolio\Views\Shared\_ResumeCard.cshtml"
                                           Write(Model.Start.ToString("MMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 6 "\\Mac\Home\Projects\Portfolio\Portfolio\Views\Shared\_ResumeCard.cshtml"
                                                                               Write(Model.End.ToString("MMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\n\n            <p class=\"card-title text_custom\">");
#nullable restore
#line 8 "\\Mac\Home\Projects\Portfolio\Portfolio\Views\Shared\_ResumeCard.cshtml"
                                         Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n            <p class=\"card-text font-weight-lighter\">");
#nullable restore
#line 9 "\\Mac\Home\Projects\Portfolio\Portfolio\Views\Shared\_ResumeCard.cshtml"
                                                Write(Model.ShortDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n            <p class=\"card-text font-weight-lighter\">");
#nullable restore
#line 10 "\\Mac\Home\Projects\Portfolio\Portfolio\Views\Shared\_ResumeCard.cshtml"
                                                Write(Model.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n            <p class=\"card-text font-weight-lighter\" style=\"display:none;\">");
#nullable restore
#line 11 "\\Mac\Home\Projects\Portfolio\Portfolio\Views\Shared\_ResumeCard.cshtml"
                                                                      Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n        </div>\n    </div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Portfolio.Models.Resume> Html { get; private set; }
    }
}
#pragma warning restore 1591
