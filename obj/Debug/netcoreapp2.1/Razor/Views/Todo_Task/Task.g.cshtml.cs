#pragma checksum "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Todo_Task\Task.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a558374ea10e452ecd038f520cc3cc23f87b0ab1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Todo_Task_Task), @"mvc.1.0.view", @"/Views/Todo_Task/Task.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Todo_Task/Task.cshtml", typeof(AspNetCore.Views_Todo_Task_Task))]
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
#line 1 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\_ViewImports.cshtml"
using GU;

#line default
#line hidden
#line 2 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\_ViewImports.cshtml"
using GU.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a558374ea10e452ecd038f520cc3cc23f87b0ab1", @"/Views/Todo_Task/Task.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff57ca875f9df937fe78e46941148558c1432e42", @"/Views/_ViewImports.cshtml")]
    public class Views_Todo_Task_Task : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GU.Models.ToDo_Task>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Task", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(41, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Todo_Task\Task.cshtml"
  
    ViewData["Title"] = "Task";

#line default
#line hidden
            BeginContext(83, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(636, 1765, true);
            WriteLiteral(@"
<script language=""javascript"" type=""text/javascript"">





    $(document).ready(function () {


        $('#task_Table').DataTable({
            responsive: true

            //,


            //""columnDefs"": [
            //    {
            //        ""targets"": [3],
            //        ""visible"": false
            //    }
            //    ,
            //    {
            //        ""targets"": [4],
            //        ""visible"": false
            //    }

            //]







        });

        var table = $('#task_Table').DataTable();



        $('#Task_Due_Date').datepicker({
            dateFormat: 'dd/mm/yy',
            changeMonth: true,
            changeYear: true,
            yearRange: '1900:2200'

        });

        $('#btnTask_Due_Date').click(function () {

            $('#Task_Due_Date').val("""");

        });



        $('#btnSubmit').click(function () {

            var Email = $(""#Email"").val();


            if (Ema");
            WriteLiteral(@"il == """") {
                validateArray.push(""Please enter <b>'Email'</b> before submit."");
            }



            if (validateArray.length > 0) {
                var text = """";

                var i;

                for (i = 0; i < validateArray.length; i++) {
                    text += validateArray[i] + ""<br>"";
                }

                BootstrapDialog.show({ title: 'Caution', type: BootstrapDialog.TYPE_WARNING, message: text });
                return false;
            }
            else {
                return true;




            }

        });



    });

</script>

<style>
</style>


<br />
<br />
<br />
<br />

<button id=""addSubTask"" hidden>Add</button>

");
            EndContext();
            BeginContext(2401, 5962, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ee011d8a1d8f4dadbeb5affc52672c11", async() => {
                BeginContext(2455, 245, true);
                WriteLiteral("\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n\r\n            <h1>How about your targets?.</h1>\r\n            <br />\r\n\r\n            <table width=\"100%\" class=\"table table-striped table-bordered table-hover nowrap\" id=\"task_Table\">\r\n\r\n");
                EndContext();
                BeginContext(2730, 477, true);
                WriteLiteral(@"
                <thead>

                    <tr>
                        <th>
                            Task Name
                        </th>
                        <th>
                            Due Date
                        </th>

                        <th>
                            is Complete
                        </th>


                        <th></th>
                    </tr>
                </thead>
                <tbody>

");
                EndContext();
#line 174 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Todo_Task\Task.cshtml"
                     foreach (var item in Model)
                    {


                        if (item.Task_isComplete == "Y")
                        {

#line default
#line hidden
                BeginContext(3369, 156, true);
                WriteLiteral("                            <tr class=\"table-success\">\r\n                                <td style=\"text-align:center\">\r\n                                    ");
                EndContext();
                BeginContext(3526, 14, false);
#line 182 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Todo_Task\Task.cshtml"
                               Write(item.Task_Name);

#line default
#line hidden
                EndContext();
                BeginContext(3540, 143, true);
                WriteLiteral("\r\n                                </td>\r\n\r\n                                <td style=\"text-align:center\">\r\n                                    ");
                EndContext();
                BeginContext(3684, 40, false);
#line 186 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Todo_Task\Task.cshtml"
                               Write(ConvertDatetoDisplay(item.Task_Due_Date));

#line default
#line hidden
                EndContext();
                BeginContext(3724, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(3726, 39, false);
#line 186 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Todo_Task\Task.cshtml"
                                                                         Write(InsertTimeToDisplay(item.Task_Due_Time));

#line default
#line hidden
                EndContext();
                BeginContext(3765, 109, true);
                WriteLiteral("\r\n                                </td>\r\n\r\n                                <td style=\"text-align:center\">\r\n\r\n");
                EndContext();
#line 191 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Todo_Task\Task.cshtml"
                                      
                                        if (item.Task_isComplete == "N")
                                        {

#line default
#line hidden
                BeginContext(4031, 62, true);
                WriteLiteral("                                            <font>NOT</font>\r\n");
                EndContext();
#line 195 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Todo_Task\Task.cshtml"
                                        }
                                        else if (item.Task_isComplete == "Y")
                                        {

#line default
#line hidden
                BeginContext(4258, 82, true);
                WriteLiteral("                                            <font style=\"color:green\">YES</font>\r\n");
                EndContext();
#line 199 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Todo_Task\Task.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
                BeginContext(4472, 82, true);
                WriteLiteral("                                            <font style=\"color:red\">ERROR</font>\r\n");
                EndContext();
#line 203 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Todo_Task\Task.cshtml"
                                        }
                                    

#line default
#line hidden
                BeginContext(4636, 109, true);
                WriteLiteral("\r\n                                </td>\r\n\r\n\r\n                                <td style=\"text-align:center\">\r\n");
                EndContext();
                BeginContext(4785, 40, true);
                WriteLiteral("                                        ");
                EndContext();
                BeginContext(4825, 346, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f91cd9d8bba4de5a9f13797a4789d0e", async() => {
                    BeginContext(4878, 289, true);
                    WriteLiteral(@"
                                            <button type=""button"" class=""btn btn-success btn-outline btn-circle"">
                                                <i class=""fa fa-check""></i>
                                            </button>
                                        ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 211 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Todo_Task\Task.cshtml"
                                                                  WriteLiteral(item.Task_ID);

#line default
#line hidden
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
                EndContext();
                BeginContext(5171, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(5212, 80, true);
                WriteLiteral("\r\n                                </td>\r\n\r\n\r\n                            </tr>\r\n");
                EndContext();
#line 222 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Todo_Task\Task.cshtml"
                        }
                        else if (item.Task_isComplete == "N")
                        {

#line default
#line hidden
                BeginContext(5409, 134, true);
                WriteLiteral("                            <tr>\r\n                                <td style=\"text-align:center\">\r\n                                    ");
                EndContext();
                BeginContext(5544, 14, false);
#line 227 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Todo_Task\Task.cshtml"
                               Write(item.Task_Name);

#line default
#line hidden
                EndContext();
                BeginContext(5558, 143, true);
                WriteLiteral("\r\n                                </td>\r\n\r\n                                <td style=\"text-align:center\">\r\n                                    ");
                EndContext();
                BeginContext(5702, 40, false);
#line 231 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Todo_Task\Task.cshtml"
                               Write(ConvertDatetoDisplay(item.Task_Due_Date));

#line default
#line hidden
                EndContext();
                BeginContext(5742, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(5744, 39, false);
#line 231 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Todo_Task\Task.cshtml"
                                                                         Write(InsertTimeToDisplay(item.Task_Due_Time));

#line default
#line hidden
                EndContext();
                BeginContext(5783, 109, true);
                WriteLiteral("\r\n                                </td>\r\n\r\n                                <td style=\"text-align:center\">\r\n\r\n");
                EndContext();
#line 236 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Todo_Task\Task.cshtml"
                                      
                                        if (item.Task_isComplete == "N")
                                        {

#line default
#line hidden
                BeginContext(6049, 62, true);
                WriteLiteral("                                            <font>NOT</font>\r\n");
                EndContext();
#line 240 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Todo_Task\Task.cshtml"
                                        }
                                        else if (item.Task_isComplete == "Y")
                                        {

#line default
#line hidden
                BeginContext(6276, 82, true);
                WriteLiteral("                                            <font style=\"color:green\">YES</font>\r\n");
                EndContext();
#line 244 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Todo_Task\Task.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
                BeginContext(6490, 82, true);
                WriteLiteral("                                            <font style=\"color:red\">ERROR</font>\r\n");
                EndContext();
#line 248 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Todo_Task\Task.cshtml"
                                        }
                                    

#line default
#line hidden
                BeginContext(6654, 109, true);
                WriteLiteral("\r\n                                </td>\r\n\r\n\r\n                                <td style=\"text-align:center\">\r\n");
                EndContext();
                BeginContext(6803, 40, true);
                WriteLiteral("                                        ");
                EndContext();
                BeginContext(6843, 346, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b8418c38b16d4d0bb88eb154303648b1", async() => {
                    BeginContext(6896, 289, true);
                    WriteLiteral(@"
                                            <button type=""button"" class=""btn btn-success btn-outline btn-circle"">
                                                <i class=""fa fa-check""></i>
                                            </button>
                                        ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 256 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Todo_Task\Task.cshtml"
                                                                  WriteLiteral(item.Task_ID);

#line default
#line hidden
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
                EndContext();
                BeginContext(7189, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(7230, 80, true);
                WriteLiteral("\r\n                                </td>\r\n\r\n\r\n                            </tr>\r\n");
                EndContext();
#line 267 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Todo_Task\Task.cshtml"
                        }
                        else
                        {

#line default
#line hidden
                BeginContext(7394, 816, true);
                WriteLiteral(@"                            <tr class=""table-danger"">
                                <td style=""text-align:center"">
                                    <font style=""color:red"">ERROR</font>
                                </td>

                                <td style=""text-align:center"">
                                    <font style=""color:red"">ERROR</font>
                                </td>

                                <td style=""text-align:center"">
                                    <font style=""color:red"">ERROR</font>
                                </td>


                                <td style=""text-align:center"">
                                    <font style=""color:red"">ERROR</font>    

                                </td>


                            </tr>
");
                EndContext();
#line 291 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Todo_Task\Task.cshtml"
                        }



                    }

#line default
#line hidden
                BeginContext(8266, 90, true);
                WriteLiteral("                </tbody>\r\n            </table>\r\n\r\n\r\n\r\n\r\n\r\n        </div>\r\n\r\n    </div>\r\n\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(8363, 20, true);
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
#line 7 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Todo_Task\Task.cshtml"
            

//CONVERT DATE TO DISPLAY
string ConvertDatetoDisplay(string dIn)
{
    var sObj = dIn.Split("-");

    var sYear = dIn.Substring(0, 4);
    var sMonth = dIn.Substring(4, 2);
    var sDate = dIn.Substring(6, 2);

    return sDate + "/" + sMonth + "/" + sYear;
}

//INSERT TIME TO DISPLAY
string InsertTimeToDisplay(string timeIn)
{
    var timeObject = timeIn.Split("-");

    var timeHour = timeIn.Substring(0, 2);
    var timeMinute = timeIn.Substring(2, 2);



    return timeHour + ":" + timeMinute;
}


#line default
#line hidden
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GU.Models.ToDo_Task>> Html { get; private set; }
    }
}
#pragma warning restore 1591
