#pragma checksum "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Users\ChangePassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3d6576e224af90f8826728a8c5be8a35ce88a5dd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_ChangePassword), @"mvc.1.0.view", @"/Views/Users/ChangePassword.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Users/ChangePassword.cshtml", typeof(AspNetCore.Views_Users_ChangePassword))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d6576e224af90f8826728a8c5be8a35ce88a5dd", @"/Views/Users/ChangePassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff57ca875f9df937fe78e46941148558c1432e42", @"/Views/_ViewImports.cshtml")]
    public class Views_Users_ChangePassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GU.Models.User>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChangePassword", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Users\ChangePassword.cshtml"
  
    ViewData["Title"] = "Register";

#line default
#line hidden
            BeginContext(67, 5422, true);
            WriteLiteral(@"
<script language=""javascript"" type=""text/javascript"">


   

    $(document).ready(function () {

     


        $('#Password2').blur(function () {


            var password = $(""#Password"").val();
            var password2 = $(""#Password2"").val();

            if (password == """" || password2 == """") {
                $('#Password').removeClass('pass');
                $('#Password2').removeClass('pass');
                $('#Password').removeClass('error');
                $('#Password2').removeClass('error');
                $('#msg_Password').hide();

            }
            else {
                if (password != password2) {
                    $('#Password').removeClass('pass');
                    $('#Password2').removeClass('pass');
                    $('#Password').addClass('error');
                    $('#Password2').addClass('error');

                    $('#msg_Password').show();
                    $(""#msg_Password"").text(""Password not matches."");
          ");
            WriteLiteral(@"          $(""#msg_Password"").css('color', 'red');

                }
                else if (password == password2) {
                    $('#Password').removeClass('error');
                    $('#Password2').removeClass('error');
                    $('#Password').addClass('pass');
                    $('#Password2').addClass('pass');

                    $('#msg_Password').show();
                    $(""#msg_Password"").text(""Password matches."");
                    $(""#msg_Password"").css('color', 'green');
                }
            }

            
            

        });


        $('#Password').blur(function () {


            var password = $(""#Password"").val();
            var password2 = $(""#Password2"").val();

            if (password == """" || password2 == """") {
                $('#Password').removeClass('pass');
                $('#Password2').removeClass('pass');
                $('#Password').removeClass('error');
                $('#Password2').removeClass('e");
            WriteLiteral(@"rror');
                $('#msg_Password').hide();

            }
            else {
                if (password != password2) {
                    $('#Password').removeClass('pass');
                    $('#Password2').removeClass('pass');
                    $('#Password').addClass('error');
                    $('#Password2').addClass('error');

                    $('#msg_Password').show();
                    $(""#msg_Password"").text(""Password not matches."");
                    $(""#msg_Password"").css('color', 'red');

                }
                else if (password == password2) {
                    $('#Password').removeClass('error');
                    $('#Password2').removeClass('error');
                    $('#Password').addClass('pass');
                    $('#Password2').addClass('pass');

                    $('#msg_Password').show();
                    $(""#msg_Password"").text(""Password matches."");
                    $(""#msg_Password"").css('color', 'green');
  ");
            WriteLiteral(@"              }
            }




        });

        $('#btnSubmit').click(function () {

           
            var password = $(""#Password"").val();
            var password2 = $(""#Password2"").val();
         
            var validateArray = [];


          
            if (password == """") {
                validateArray.push(""Please enter <b>'Password'</b> before submit."");
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

                if (password != password2) {
                    $('#msg_Password').show();
                    $(""#msg_Password"").text(");
            WriteLiteral(@"""Password not matches."");
                    $(""#msg_Password"").css('color', 'red');

                    $('#Password').addClass('error');
                    $('#Password2').addClass('error');

                    BootstrapDialog.show({ title: 'Password', type: BootstrapDialog.TYPE_WARNING, message: 'Password not matches.' });
                    return false;
                }

                if (userIsEmpty == ""N"") {
                    BootstrapDialog.show({ title: 'Email', type: BootstrapDialog.TYPE_WARNING, message: 'This Email is already used.' });
                    return false;
                }
                else if (userIsEmpty == ""Y"") {
                    return true;
                }
             
                

            }

        });

    });

</script>

<style>
    hr.style2 {
        border-top: 3px double #8c8b8b;
        background-color: cornflowerblue;
    }

    #sp1 {
        background-color: #cdc9c9;
    }

    .error {
        bor");
            WriteLiteral(@"der: 1px solid red;
    }

    .pass {
        border: 1px solid green;
    }

    .main-panel {
        border: 1px;
        background-color: #eaeaea;
        border-radius: 20px;
    }

    

</style>

<div>
    
    
    <br />
    
    
    <div class=""col-md-12"">
        ");
            EndContext();
            BeginContext(5489, 1986, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "06274aa07a7d4f439202eeb5728cf288", async() => {
                BeginContext(5553, 322, true);
                WriteLiteral(@"

            <div class=""row"">
                <div class=""col-md-12"">
                    <div class=""row"">
                        <div class=""col-md-12"">
                            <div class=""form-group"">
                                <label>Email:</label>
                                <input id=""Email""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 5875, "\"", 5895, 1);
#line 208 "C:\Users\Pond\source\repos\All_Project\GU\GU\Views\Users\ChangePassword.cshtml"
WriteAttributeValue("", 5883, Model.Email, 5883, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5896, 1248, true);
                WriteLiteral(@" type=""email"" class=""form-control"" readonly />

                            </div>
                        </div>
                    </div>

                    <div class=""row"">
                        <div class=""col-md-12"">
                            <div class=""form-group"">
                                <label>New-Password:</label>
                                <input id=""Password"" name=""Password"" type=""password"" class=""form-control"" />

                            </div>
                        </div>
                    </div>

                    <div class=""row"">
                        <div class=""col-md-12"">
                            <div class=""form-group"">
                                <label>Re-Password:</label>
                                <input id=""Password2"" name=""Password2"" type=""password"" class=""form-control"" />
                                <p id=""msg_Password""></p>
                            </div>
                        </div>
                    ");
                WriteLiteral("</div>\r\n\r\n                </div>\r\n            </div>\r\n\r\n            <br />\r\n\r\n            <div class=\"row\">\r\n                <div class=\"col-md-12\">\r\n                    <div class=\"form-group\">\r\n\r\n\r\n                        ");
                EndContext();
                BeginContext(7144, 131, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac367347cd9141b2836c3f052753759d", async() => {
                    BeginContext(7200, 71, true);
                    WriteLiteral("<button type=\"button\" class=\"btn btn-outline btn-primary\">Back</button>");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(7275, 193, true);
                WriteLiteral("\r\n                        <input type=\"submit\" id=\"btnSubmit\" value=\"Submit\" class=\"btn btn-primary\" />\r\n                    </div>\r\n                </div>\r\n\r\n\r\n            </div>\r\n\r\n\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(7475, 32, true);
            WriteLiteral("\r\n    </div>\r\n\r\n</div>\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GU.Models.User> Html { get; private set; }
    }
}
#pragma warning restore 1591
