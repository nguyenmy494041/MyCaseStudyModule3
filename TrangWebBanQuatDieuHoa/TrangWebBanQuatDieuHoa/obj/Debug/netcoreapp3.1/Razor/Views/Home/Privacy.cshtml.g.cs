#pragma checksum "C:\DataPersonal\Codegym\MyProjectMudule3\MyCaseStudyModule3\TrangWebBanQuatDieuHoa\TrangWebBanQuatDieuHoa\Views\Home\Privacy.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b63c236a6987e2e5fa7bf38f535ab10d80bc07a1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Privacy), @"mvc.1.0.view", @"/Views/Home/Privacy.cshtml")]
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
#line 1 "C:\DataPersonal\Codegym\MyProjectMudule3\MyCaseStudyModule3\TrangWebBanQuatDieuHoa\TrangWebBanQuatDieuHoa\Views\_ViewImports.cshtml"
using TrangWebBanQuatDieuHoa;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\DataPersonal\Codegym\MyProjectMudule3\MyCaseStudyModule3\TrangWebBanQuatDieuHoa\TrangWebBanQuatDieuHoa\Views\_ViewImports.cshtml"
using TrangWebBanQuatDieuHoa.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\DataPersonal\Codegym\MyProjectMudule3\MyCaseStudyModule3\TrangWebBanQuatDieuHoa\TrangWebBanQuatDieuHoa\Views\_ViewImports.cshtml"
using TrangWebBanQuatDieuHoa.Models.Products;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\DataPersonal\Codegym\MyProjectMudule3\MyCaseStudyModule3\TrangWebBanQuatDieuHoa\TrangWebBanQuatDieuHoa\Views\_ViewImports.cshtml"
using TrangWebBanQuatDieuHoa.Models.Ordersss;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\DataPersonal\Codegym\MyProjectMudule3\MyCaseStudyModule3\TrangWebBanQuatDieuHoa\TrangWebBanQuatDieuHoa\Views\_ViewImports.cshtml"
using TrangWebBanQuatDieuHoa.Models.Userss;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\DataPersonal\Codegym\MyProjectMudule3\MyCaseStudyModule3\TrangWebBanQuatDieuHoa\TrangWebBanQuatDieuHoa\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\DataPersonal\Codegym\MyProjectMudule3\MyCaseStudyModule3\TrangWebBanQuatDieuHoa\TrangWebBanQuatDieuHoa\Views\_ViewImports.cshtml"
using TrangWebBanQuatDieuHoa.Models.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b63c236a6987e2e5fa7bf38f535ab10d80bc07a1", @"/Views/Home/Privacy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e9e42ccfbd6097f6af772818a403ec8f4efa0c7", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Privacy : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\DataPersonal\Codegym\MyProjectMudule3\MyCaseStudyModule3\TrangWebBanQuatDieuHoa\TrangWebBanQuatDieuHoa\Views\Home\Privacy.cshtml"
  
    ViewData["Title"] = "Privacy Policy";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>");
#nullable restore
#line 4 "C:\DataPersonal\Codegym\MyProjectMudule3\MyCaseStudyModule3\TrangWebBanQuatDieuHoa\TrangWebBanQuatDieuHoa\Views\Home\Privacy.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
<style>
    .thumb {
        height: 100px;
        width: 150px;
        padding-left: 10px;
    }
   </style>
<script src=""https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js""></script>
<script>




    window.preview = function (input) {
        $('#previewImg').empty();
        if (input.files && input.files[0]) {
            $(input.files).each(function (i, value) {
                var reader = new FileReader();
                reader.readAsDataURL(this);
                reader.onload = function (e) {
                    $(""#previewImg"").append(""<img id='p""+ i +""' class='thumb'  onclick='xoa(""+i+"");' src='"" + e.target.result + ""'>"");
                }
            });
        }
        //console.log(input.files);
    }

    function xoa(i) {      

        $(`#p${i}`).remove();
        
    }

     
</script>


<input type='file' id=""imageInput"" name=""image"" onchange=""preview(this);"" multiple=""multiple"" />
<div id='previewImg'></div>");
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
