#pragma checksum "C:\Users\mitch\Desktop\Coding_Dojo\C#\ORMs\projects\TeamManager\Views\Home\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd88f1f213fdff999e7d9a49fd340555781e6881"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Dashboard), @"mvc.1.0.view", @"/Views/Home/Dashboard.cshtml")]
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
#line 1 "C:\Users\mitch\Desktop\Coding_Dojo\C#\ORMs\projects\TeamManager\Views\_ViewImports.cshtml"
using TeamManager;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mitch\Desktop\Coding_Dojo\C#\ORMs\projects\TeamManager\Views\_ViewImports.cshtml"
using TeamManager.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd88f1f213fdff999e7d9a49fd340555781e6881", @"/Views/Home/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a56655cf4008c865310328023591408e53730ba", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\mitch\Desktop\Coding_Dojo\C#\ORMs\projects\TeamManager\Views\Home\Dashboard.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""d-flex flex-wrap justify-content-around"">
    <h1>Your Teams</h1>
        <table class=""table"">
            <thead>
                <tr>
                    <th>Name</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 14 "C:\Users\mitch\Desktop\Coding_Dojo\C#\ORMs\projects\TeamManager\Views\Home\Dashboard.cshtml"
                  foreach (Team team in Model.Teams){

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td><a");
            BeginWriteAttribute("href", " href=\"", 413, "\"", 433, 2);
            WriteAttributeValue("", 420, "/", 420, 1, true);
#nullable restore
#line 16 "C:\Users\mitch\Desktop\Coding_Dojo\C#\ORMs\projects\TeamManager\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 421, team.TeamId, 421, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 16 "C:\Users\mitch\Desktop\Coding_Dojo\C#\ORMs\projects\TeamManager\Views\Home\Dashboard.cshtml"
                                               Write(team.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n                    </tr>\r\n");
#nullable restore
#line 18 "C:\Users\mitch\Desktop\Coding_Dojo\C#\ORMs\projects\TeamManager\Views\Home\Dashboard.cshtml"
                } 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </tbody>
        </table>
</div>
<div class=""d-flex flex-wrap justify-content-around"">
    <div>
        <div>
            <p>for each team this user has</p>
        </div>
        <div>
            <p>it will be displayed in a div</p>
        </div>
    </div>
    
</div>
<div class=""d-flex flex-wrap justify-content-around"">
    <a href=""/new/team"" class=""btn btn-primary"">Start a new Team</a>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
