#pragma checksum "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc58c798df2a680a69d0cd38473c34611090b163"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc58c798df2a680a69d0cd38473c34611090b163", @"/Views/Statistics/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c1ce498abc2d3cbe5bbe3fa2079a1769b1b102d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Statistics_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MoneyManager.Models.ViewModels.StatisticsViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
    <div class=""container py-5 h-100"">
        <div class=""row d-flex justify-content-center align-items-center h-100"">
            <div class=""col-12 col-md-12 col-lg-12 col-xl-12"">
                <div class=""card shadow-lg"" style=""border-radius: 1rem;"">
                    <div class=""card-body p-5"">
                        <div class=""row pt-4"">
                            <div class=""col"">
                                <h2 class=""text-primary"">Статистика</h2>
                            </div>
                        </div>
                        <br />
                        <div class=""col"">
                            <h3 class=""text-center"">Витрати</h3>
                            <div class=""row"">
                                <div class=""col"">
                                    <div class=""card bg-light mb-3"" style=""max-width: 18rem;"">
                                        <div class=""card-header"">Витрати взагальному за весь період</div>
                                 ");
            WriteLiteral("       <div class=\"card-body\">\r\n                                            <h5 class=\"card-title text-danger\">");
#nullable restore
#line 21 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"
                                                                          Write(Model.TotalExpense);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" грн.</h5>
                                        </div>
                                    </div>
                                </div>
                                <div class=""col"">
                                    <div class=""card bg-light mb-3"" style=""max-width: 18rem;"">
                                        <div class=""card-header"">Загалом витрачено цього року</div>
                                        <div class=""card-body"">
                                            <h5 class=""card-title text-danger"">");
#nullable restore
#line 29 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"
                                                                          Write(Model.CurrentYearExpense);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" грн.</h5>
                                        </div>
                                    </div>
                                </div>
                                <div class=""col"">
                                    <div class=""card bg-light mb-3"" style=""max-width: 18rem;"">
                                        <div class=""card-header"">Загалом витрачено цього місяця</div>
                                        <div class=""card-body"">
                                            <h5 class=""card-title text-danger"">");
#nullable restore
#line 37 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"
                                                                          Write(Model.CurrentMonthExpense);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" грн.</h5>
                                        </div>
                                    </div>
                                </div>
                                <div class=""col"">
                                    <div class=""card bg-light mb-3"" style=""max-width: 18rem;"">
                                        <div class=""card-header"">Загалом витрачено цього тижня</div>
                                        <div class=""card-body"">
                                            <h5 class=""card-title text-danger"">");
#nullable restore
#line 45 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"
                                                                          Write(Model.CurrentWeekExpense);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" грн.</h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <h3 class=""text-center"">Прибутки</h3>
                            <div class=""row"">
                                <div class=""col"">
                                    <div class=""card bg-light mb-3"" style=""max-width: 18rem;"">
                                        <div class=""card-header"">Дохід взагальному за весь період</div>
                                        <div class=""card-body"">
                                            <h5 class=""card-title text-success"">");
#nullable restore
#line 57 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"
                                                                           Write(Model.TotalIncome);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" грн.</h5>
                                        </div>
                                    </div>
                                </div>
                                <div class=""col"">
                                    <div class=""card bg-light mb-3"" style=""max-width: 18rem;"">
                                        <div class=""card-header"">Загальний дохід цього року</div>
                                        <div class=""card-body"">
                                            <h5 class=""card-title text-success"">");
#nullable restore
#line 65 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"
                                                                           Write(Model.CurrentYearIncome);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" грн.</h5>
                                        </div>
                                    </div>
                                </div>
                                <div class=""col"">
                                    <div class=""card bg-light mb-3"" style=""max-width: 18rem;"">
                                        <div class=""card-header"">Загальний прибуток цього місяця</div>
                                        <div class=""card-body"">
                                            <h5 class=""card-title text-success"">");
#nullable restore
#line 73 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"
                                                                           Write(Model.CurrentMonthIncome);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" грн.</h5>
                                        </div>
                                    </div>
                                </div>
                                <div class=""col"">
                                    <div class=""card bg-light mb-3"" style=""max-width: 18rem;"">
                                        <div class=""card-header"">Загальний прибуток цього тижня</div>
                                        <div class=""card-body"">
                                            <h5 class=""card-title text-success"">");
#nullable restore
#line 81 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"
                                                                           Write(Model.CurrentWeekIncome);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" грн.</h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                        </div>

                        <h3 class=""text-center"">Топ 5 катогорій по витратам на протязі місяця</h3>
                        <table class=""table table-bordered table-striped"" style=""width:100%"">
                            <thead>
                                <tr>
                                    <th>
                                        №
                                    </th>
                                    <th>
                                        Категорія
                                    </th>
                                    <th>
                                        Сума
                                    </th>
                                </tr>
                            </thead>
                            <tbo");
            WriteLiteral("dy>\r\n");
#nullable restore
#line 105 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"
                                  
                                    var count = 1;

                                    foreach (var expenses in Model.ExpenseByExpenseType)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td width=\"20%\">");
#nullable restore
#line 111 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"
                                                       Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td width=\"50%\">");
#nullable restore
#line 112 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"
                                                       Write(expenses.Item1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td class=\"text-danger\" width=\"30%\">");
#nullable restore
#line 113 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"
                                                                           Write(expenses.Item2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        </tr>\r\n");
#nullable restore
#line 115 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"

                                        count++;
                                    }
                                

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </tbody>
                        </table>

                        <br />
                        <h3 class=""text-center"">Топ 5 катогорій по прибуткам на протязі місяця</h3>
                        <table class=""table table-bordered table-striped"" style=""width:100%"">
                            <thead>
                                <tr>
                                    <th>
                                        №
                                    </th>
                                    <th>
                                        Категорія
                                    </th>
                                    <th>
                                        Сума
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 139 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"
                                  
                                    var count2 = 1;

                                    foreach (var incomes in Model.IncomeByIncomeType)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td width=\"20%\">");
#nullable restore
#line 145 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"
                                                       Write(count2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td width=\"50%\">");
#nullable restore
#line 146 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"
                                                       Write(incomes.Item1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td class=\"text-success\" width=\"30%\">");
#nullable restore
#line 147 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"
                                                                            Write(incomes.Item2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        </tr>\r\n");
#nullable restore
#line 149 "D:\Important documents\Important\Programming\Repository\MoneyManager\MoneyManager\MoneyManager\Views\Statistics\Index.cshtml"

                                        count2++;
                                    }
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MoneyManager.Models.ViewModels.StatisticsViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
