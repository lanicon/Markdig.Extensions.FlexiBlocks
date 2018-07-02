﻿using FlexiBlocks.Sections;
using Markdig.Renderers;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace FlexiBlocks.Tests.Sections
{
    public class FlexiSectionBlockRendererIntegrationTests
    {
        [Fact]
        public void Write_WritesWrapperAttributesAndChildren()
        {
            // Arrange
            const string dummyChildText = "dummyChildText";
            const string dummyAttributeName = "dummyAttributeName";
            const string dummyAttributeValue = "dummyAttributeValue";
            const SectioningContentElement dummySectioningContentElement = SectioningContentElement.Article;
            var dummyContainerInline = new ContainerInline();
            dummyContainerInline.AppendChild(new LiteralInline(dummyChildText));
            var dummyParagraphBlock = new ParagraphBlock()
            {
                Inline = dummyContainerInline
            };
            var dummySectionBlock = new FlexiSectionBlock(null)
            {
                SectionBlockOptions = new FlexiSectionBlockOptions()
                {
                    WrapperElement = dummySectioningContentElement,
                    Attributes = new HtmlAttributeDictionary() { { dummyAttributeName, dummyAttributeValue } }
                }
            };
            dummySectionBlock.Add(dummyParagraphBlock);
            string result = null;
            using (var dummyStringWriter = new StringWriter())
            {
                var dummyHtmlRenderer = new HtmlRenderer(dummyStringWriter); // Note that markdig changes dummyStringWriter.NewLine to '\n'
                var sectionBlockRenderer = new FlexiSectionBlockRenderer();

                // Act
                sectionBlockRenderer.Write(dummyHtmlRenderer, dummySectionBlock);
                result = dummyStringWriter.ToString();
            }

            // Assert
            string expectedResultElementName = dummySectioningContentElement.ToString().ToLower();
            Assert.Equal($"<{expectedResultElementName} {dummyAttributeName}=\"{dummyAttributeValue}\">\n<p>{dummyChildText}</p>\n</{expectedResultElementName}>\n", result);
        }

        [Theory]
        [MemberData(nameof(Write_OnlyWritesChildrenIfWrapperElementIsUndefinedOrNone_Data))]
        public void Write_OnlyWritesChildrenIfWrapperElementIsUndefinedOrNone(SectioningContentElement sectioningContentElement)
        {
            // Arrange
            const string dummyChildText = "dummyChildText";
            var dummyContainerInline = new ContainerInline();
            dummyContainerInline.AppendChild(new LiteralInline(dummyChildText));
            var dummyParagraphBlock = new ParagraphBlock()
            {
                Inline = dummyContainerInline
            };
            var dummySectionBlock = new FlexiSectionBlock(null)
            {
                SectionBlockOptions = new FlexiSectionBlockOptions()
                {
                    WrapperElement = sectioningContentElement
                }
            };
            dummySectionBlock.Add(dummyParagraphBlock);
            string result = null;
            using (var dummyStringWriter = new StringWriter())
            {
                var dummyHtmlRenderer = new HtmlRenderer(dummyStringWriter); // Note that markdig changes dummyStringWriter.NewLine to '\n'
                var sectionBlockRenderer = new FlexiSectionBlockRenderer();

                // Act
                sectionBlockRenderer.Write(dummyHtmlRenderer, dummySectionBlock);
                result = dummyStringWriter.ToString();
            }

            // Assert
            Assert.Equal($"<p>{dummyChildText}</p>\n", result);
        }

        public static IEnumerable<object[]> Write_OnlyWritesChildrenIfWrapperElementIsUndefinedOrNone_Data()
        {
            return new object[][]
            {
                new object[]{SectioningContentElement.None},
                new object[]{SectioningContentElement.Undefined}
            };
        }
    }
}