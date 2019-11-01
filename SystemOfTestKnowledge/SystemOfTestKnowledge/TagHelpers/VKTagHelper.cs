using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SystemOfTestKnowledge.TagHelpers
{
    public class VKTagHelper: TagHelper
    {
        private const string address = "https://vk.com/ivanchib";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";    
            output.Attributes.SetAttribute("href", address);
            output.Content.SetContent("Связь с админом в ВК");
        }
    }
}
