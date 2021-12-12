#pragma checksum "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e3b75552538d1eefc226d012745eb2d46a46dedf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Statistics_Index), @"mvc.1.0.view", @"/Views/Statistics/Index.cshtml")]
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
#line 1 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\_ViewImports.cshtml"
using MoneyManager;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\_ViewImports.cshtml"
using MoneyManager.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\_ViewImports.cshtml"
using MoneyManager.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\_ViewImports.cshtml"
using MoneyManager.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3b75552538d1eefc226d012745eb2d46a46dedf", @"/Views/Statistics/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c1ce498abc2d3cbe5bbe3fa2079a1769b1b102d", @"/Views/_ViewImports.cshtml")]
    public class Views_Statistics_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MoneyManager.Models.ViewModels.StatisticsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""container p-3"">
    <div class=""row pt-4"">
        <div class=""col-6"">
            <h2 class=""text-primary"">Статистика</h2>
        </div>
    </div>
    <div class=""col-6"">
        <div class=""row"">
            <p>Загалом витрачено:</p>
            <p>");
#nullable restore
#line 12 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"
          Write(Model.TotalExpense);

#line default
#line hidden
#nullable disable
            WriteLiteral(" грн.</p>\r\n        </div>\r\n        <div class=\"row\">\r\n            <p>Загалом витрачено цього року:</p>\r\n            <p>");
#nullable restore
#line 16 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"
          Write(Model.CurrentYearExpense);

#line default
#line hidden
#nullable disable
            WriteLiteral(" грн.</p>\r\n        </div>\r\n        <div class=\"row\">\r\n            <p>Загалом витрачено цього місяця:</p>\r\n            <p>");
#nullable restore
#line 20 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"
          Write(Model.CurrentMonthExpense);

#line default
#line hidden
#nullable disable
            WriteLiteral(" грн.</p>\r\n        </div>\r\n        <div class=\"row\">\r\n            <p>Загалом витрачено цього тижня:</p>\r\n            <p>");
#nullable restore
#line 24 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"
          Write(Model.CurrentWeekExpense);

#line default
#line hidden
#nullable disable
            WriteLiteral(" грн.</p>\r\n        </div>\r\n    </div>\r\n    <div>\r\n");
#nullable restore
#line 28 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"
          
            foreach (var a in Model.ExpenseByExpenseType)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p>");
#nullable restore
#line 31 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"
              Write(a.Item1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p>");
#nullable restore
#line 32 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"
              Write(a.Item2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 33 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MoneyManager.Models.ViewModels.StatisticsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
