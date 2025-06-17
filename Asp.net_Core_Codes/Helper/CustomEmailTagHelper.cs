using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Asp.net_Core_Codes.Helper
{
    public class CustomEmailTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //Here we  are doing everything for custom tag helper
            output.TagName = "a";
            output.Attributes.SetAttribute("href","abc@gmail.com");
            output.Content.SetContent("abc@gmail.com");
        }
    }
}
