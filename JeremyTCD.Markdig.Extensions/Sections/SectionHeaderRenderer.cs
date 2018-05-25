﻿using Markdig.Renderers;
using Markdig.Renderers.Html;
using Markdig.Syntax;

namespace JeremyTCD.Markdig.Extensions.Sections
{
    /// <summary>
    /// An HTML renderer for a <see cref="HeadingBlock"/>.
    /// </summary>
    public class SectionHeaderRenderer : HtmlObjectRenderer<HeadingBlock>
    {
        protected override void Write(HtmlRenderer renderer, HeadingBlock obj)
        {
            if (renderer.EnableHtmlForBlock)
            {
                renderer.Write("<header");
                if(obj.GetData(SectionBlockParser.HEADER_CLASS_NAME_FORMAT_KEY) is string headerClassNameFormat &&
                    !string.IsNullOrWhiteSpace(headerClassNameFormat))
                {
                    renderer.Write($" class=\"{string.Format(headerClassNameFormat, obj.Level)}\"");
                }
                renderer.WriteLine(">");
                renderer.Write($"<h{obj.Level}>");
            }

            renderer.WriteLeafInline(obj);

            if (renderer.EnableHtmlForBlock)
            {
                renderer.WriteLine($"</h{obj.Level}>");

                if (renderer.EnableHtmlForBlock &&
                    obj.GetData(SectionBlockParser.HEADER_ICON_MARKUP_KEY) is string headerIconMarkup &&
                    !string.IsNullOrWhiteSpace(headerIconMarkup))
                {
                    renderer.WriteLine(headerIconMarkup);
                }

                renderer.WriteLine("</header>");
            }
        }
    }
}
