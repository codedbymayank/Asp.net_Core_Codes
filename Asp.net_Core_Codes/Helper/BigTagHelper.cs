using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Asp.net_Core_Codes.Helper
{
    [HtmlTargetElement("big")]
    [HtmlTargetElement(Attributes ="big")]

    public class BigTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "h3";
            output.Attributes.RemoveAll("big");
        }
    }
}
