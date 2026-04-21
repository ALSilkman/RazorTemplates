using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RazorTemplates.Models
{
    [HtmlTargetElement("button", Attributes = "asp-button")]
    public class ButtonTagHelper : TagHelper
    {
        public string AspButton { get; set; } = "primary";
        public string AspSize { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var style = AspButton switch
            {
                "primary" => "btn-primary",
                "secondary" => "btn-secondary",
                "success" => "btn-success",
                "danger" => "btn-danger",
                "warning" => "btn-warning",
                _ => "btn-primary"
            };

            var size = AspSize switch
            {
                "sm" => "btn-sm",
                "lg" => "btn-lg",
                _ => ""
            };

            output.Attributes.SetAttribute("class", $"btn {style} {size}".Trim());
        }
    }
}
