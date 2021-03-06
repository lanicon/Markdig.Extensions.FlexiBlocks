using BenchmarkDotNet.Attributes;
using Jering.Markdig.Extensions.FlexiBlocks.FlexiIncludeBlocks;
using Jering.Markdig.Extensions.FlexiBlocks.FlexiAlertBlocks;
using Jering.Markdig.Extensions.FlexiBlocks.FlexiCodeBlocks;
using Jering.Markdig.Extensions.FlexiBlocks.FlexiSectionBlocks;
using Jering.Markdig.Extensions.FlexiBlocks.FlexiTableBlocks;
using Markdig;
using System;
using System.IO;
using Jering.Markdig.Extensions.FlexiBlocks.FlexiBannerBlocks;
using Jering.Markdig.Extensions.FlexiBlocks.FlexiCardsBlocks;
using Jering.Markdig.Extensions.FlexiBlocks.FlexiFigureBlocks;
using Jering.Markdig.Extensions.FlexiBlocks.FlexiQuoteBlocks;
using Jering.Markdig.Extensions.FlexiBlocks.FlexiTabsBlocks;
using Jering.Markdig.Extensions.FlexiBlocks.FlexiPictureBlocks;
using Jering.Markdig.Extensions.FlexiBlocks.FlexiVideoBlocks;

namespace Jering.Markdig.Extensions.FlexiBlocks.Performance
{
    // TODO each block should have its own benchmarks class, every feature of each block should have its own benchmark.
    // Current benchmarks aren't very useful.
    [MemoryDiagnoser]
    public class Benchmarks
    {
        private MarkdownPipeline _pipeline;

        // FlexiIncludeBlocks
        [GlobalSetup(Target = nameof(FlexiIncludeBlocks_ParseAndRender))]
        public void FlexiIncludeBlocks_ParseAndRender_Setup()
        {
            var pipelineBuilder = new MarkdownPipelineBuilder();
            pipelineBuilder.
                UseFlexiIncludeBlocks().
                UseFlexiOptionsBlocks();
            _pipeline = pipelineBuilder.Build();

            WritePreview(nameof(FlexiIncludeBlocksExtension), FlexiIncludeBlocks_ParseAndRender());
        }

        [Benchmark]
        public string FlexiIncludeBlocks_ParseAndRender()
        {
            return Markdown.ToHtml(@"i{
    ""source"": ""https://raw.githubusercontent.com/JeringTech/Markdig.Extensions.FlexiBlocks/6998b1c27821d8393ad39beb54f782515c39d98b/test/FlexiBlocks.Tests/exampleInclude.js"",
    ""clippings"":[{""startLine"": 7, ""endString"": ""#endregion utility methods"", ""dedent"": 1, ""collapse"": 0.5}]
}", _pipeline);
        }

        // FlexiAlertBlocks
        [GlobalSetup(Target = nameof(FlexiAlertBlocks_ParseAndRender))]
        public void FlexiAlertBlocks_ParseAndRender_Setup()
        {
            var pipelineBuilder = new MarkdownPipelineBuilder();
            pipelineBuilder.
                UseFlexiAlertBlocks().
                UseFlexiOptionsBlocks();
            _pipeline = pipelineBuilder.Build();

            WritePreview(nameof(FlexiAlertBlocksExtension), FlexiAlertBlocks_ParseAndRender());
        }

        [Benchmark]
        public string FlexiAlertBlocks_ParseAndRender()
        {
            return Markdown.ToHtml(@"o{ ""type"": ""warning"" }
! This is a warning.", _pipeline);
        }

        // FlexiCodeBlocks
        // TODO really slow
        [GlobalSetup(Target = nameof(FlexiCodeBlocks_ParseAndRender))]
        public void FlexiCodeBlocks_ParseAndRender_Setup()
        {
            var pipelineBuilder = new MarkdownPipelineBuilder();
            pipelineBuilder.
                UseFlexiCodeBlocks().
                UseFlexiOptionsBlocks();
            _pipeline = pipelineBuilder.Build();

            WritePreview(nameof(FlexiCodeBlocksExtension), FlexiCodeBlocks_ParseAndRender());
        }

        [Benchmark]
        public string FlexiCodeBlocks_ParseAndRender()
        {
            return Markdown.ToHtml(@"o{
    ""language"": ""csharp"",
    ""lineNumbers"": [
        {
            ""startLine"": 1,
            ""endLine"": 8,
            ""startNumber"": 1
        },
        {
            ""startLine"": 11,
            ""endLine"": -1,
            ""startNumber"": 32
        }
    ],
    ""highlightedLines"": [
        {
            ""startLine"": 3,
            ""endLine"": 7
        },
        {
            ""startLine"": 12,
            ""endLine"": 16
        }
    ],
    ""highlightedPhrases"": [
        { ""regex"": ""public .*?\\)"", ""includedMatches"": [1] }
    ]
}
```
public class ExampleClass
{
    public string ExampleFunction1(string arg)
    {
        // Example comment
        return arg + ""dummyString"";
    }

    // Some functions omitted for brevity
    // ...

    public string ExampleFunction3(string arg)
    {
        // Example comment
        return arg + ""dummyString"";
    }
}
```", _pipeline);
        }

        // FlexiSectionBlocks
        // TODO allocates way more than expected.
        // Try pooling using ConcurrentBags.
        [GlobalSetup(Target = nameof(FlexiSectionBlocks_ParseAndRender))]
        public void FlexiSectionBlocks_ParseAndRender_Setup()
        {
            var pipelineBuilder = new MarkdownPipelineBuilder();
            pipelineBuilder.
                UseFlexiSectionBlocks().
                UseFlexiOptionsBlocks();
            _pipeline = pipelineBuilder.Build();

            WritePreview(nameof(FlexiSectionBlocksExtension), FlexiSectionBlocks_ParseAndRender());
        }

        [Benchmark]
        public string FlexiSectionBlocks_ParseAndRender()
        {
            return Markdown.ToHtml(@"o{
    ""element"": ""article""
}
# foo

> # foo
> ## foo

## foo", _pipeline);
        }

        // FlexiTableBlocks
        [GlobalSetup(Target = nameof(FlexiTableBlocks_ParseAndRender))]
        public void FlexiTableBlocks_ParseAndRender_Setup()
        {
            var pipelineBuilder = new MarkdownPipelineBuilder();
            pipelineBuilder.
                UseFlexiTableBlocks().
                UseFlexiOptionsBlocks();
            _pipeline = pipelineBuilder.Build();

            WritePreview(nameof(FlexiTableBlocksExtension), FlexiTableBlocks_ParseAndRender());
        }

        [Benchmark]
        public string FlexiTableBlocks_ParseAndRender()
        {
            return Markdown.ToHtml(@"
+-----+-----+
| a   | b   |
+=====+=====+
| `0` | *1* |
+-----+-----+
| > 2 | ``` |
|     | 3   |
|     | ``` |", _pipeline);
        }

        // FlexiBannerBlocks
        [GlobalSetup(Target = nameof(FlexiBannerBlocks_ParseAndRender))]
        public void FlexiBannerBlocks_ParseAndRender_Setup()
        {
            var pipelineBuilder = new MarkdownPipelineBuilder();
            pipelineBuilder.
                UseFlexiBannerBlocks().
                UseFlexiOptionsBlocks();
            _pipeline = pipelineBuilder.Build();

            WritePreview(nameof(FlexiBannerBlocksExtension), FlexiBannerBlocks_ParseAndRender());
        }

        [Benchmark]
        public string FlexiBannerBlocks_ParseAndRender()
        {
            return Markdown.ToHtml(@"+++ banner
Title
+++
Blurb
+++", _pipeline);
        }

        // FlexiCardsBlocks
        [GlobalSetup(Target = nameof(FlexiCardsBlocks_ParseAndRender))]
        public void FlexiCardsBlocks_ParseAndRender_Setup()
        {
            var pipelineBuilder = new MarkdownPipelineBuilder();
            pipelineBuilder.
                UseFlexiCardsBlocks().
                UseFlexiOptionsBlocks();
            _pipeline = pipelineBuilder.Build();

            WritePreview(nameof(FlexiCardsBlocksExtension), FlexiCardsBlocks_ParseAndRender());
        }

        [Benchmark]
        public string FlexiCardsBlocks_ParseAndRender()
        {
            return Markdown.ToHtml(@"[[[
+++ card
Title
+++
Content
+++
Footnote
+++

+++ card
Title
+++
Content
+++
Footnote
+++
[[[", _pipeline);
        }

        // FlexiFigureBlocks
        [GlobalSetup(Target = nameof(FlexiFigureBlocks_ParseAndRender))]
        public void FlexiFigureBlocks_ParseAndRender_Setup()
        {
            var pipelineBuilder = new MarkdownPipelineBuilder();
            pipelineBuilder.
                UseFlexiFigureBlocks().
                UseFlexiOptionsBlocks();
            _pipeline = pipelineBuilder.Build();

            WritePreview(nameof(FlexiFigureBlocksExtension), FlexiFigureBlocks_ParseAndRender());
        }

        [Benchmark]
        public string FlexiFigureBlocks_ParseAndRender()
        {
            return Markdown.ToHtml(@"+++ figure
Content
+++
Caption
+++", _pipeline);
        }

        // FlexiPictureBlocks
        [GlobalSetup(Target = nameof(FlexiPictureBlocks_ParseAndRender))]
        public void FlexiPictureBlocks_ParseAndRender_Setup()
        {
            var pipelineBuilder = new MarkdownPipelineBuilder();
            pipelineBuilder.
                UseFlexiPictureBlocks(new FlexiPictureBlocksExtensionOptions(localMediaDirectory: Directory.GetCurrentDirectory())).
                UseFlexiOptionsBlocks();
            _pipeline = pipelineBuilder.Build();

            WritePreview(nameof(FlexiPictureBlocksExtension), FlexiPictureBlocks_ParseAndRender());
        }

        [Benchmark]
        public string FlexiPictureBlocks_ParseAndRender()
        {
            return Markdown.ToHtml(@"p{
    ""src"": ""/url/exampleImage.png"",
    ""alt"": ""Alternative text""
}", _pipeline);
        }

        // FlexiQuoteBlocks
        [GlobalSetup(Target = nameof(FlexiQuoteBlocks_ParseAndRender))]
        public void FlexiQuoteBlocks_ParseAndRender_Setup()
        {
            var pipelineBuilder = new MarkdownPipelineBuilder();
            pipelineBuilder.
                UseFlexiQuoteBlocks().
                UseFlexiOptionsBlocks();
            _pipeline = pipelineBuilder.Build();

            WritePreview(nameof(FlexiQuoteBlocksExtension), FlexiQuoteBlocks_ParseAndRender());
        }

        [Benchmark]
        public string FlexiQuoteBlocks_ParseAndRender()
        {
            return Markdown.ToHtml(@"+++ quote
Quote
+++
Citation
+++", _pipeline);
        }

        // FlexiTabsBlocks
        [GlobalSetup(Target = nameof(FlexiTabsBlocks_ParseAndRender))]
        public void FlexiTabsBlocks_ParseAndRender_Setup()
        {
            var pipelineBuilder = new MarkdownPipelineBuilder();
            pipelineBuilder.
                UseFlexiTabsBlocks().
                UseFlexiOptionsBlocks();
            _pipeline = pipelineBuilder.Build();

            WritePreview(nameof(FlexiTabsBlocksExtension), FlexiTabsBlocks_ParseAndRender());
        }

        [Benchmark]
        public string FlexiTabsBlocks_ParseAndRender()
        {
            return Markdown.ToHtml(@"///
+++ tab
Title
+++
Content
+++

+++ tab
Title
+++
Content
+++
///", _pipeline);
        }

        // TODO FlexiVideoBlocks is extremely slow (100ms+ per operation) when file operations are enabled. 
        // We need to do two things:
        // - Cache metadata and posters. To do this in a performant manner, we'll have to add a guid to the video filenames.
        // - Optimize FFmpeg
        //   - If we need both metadata and poster, use a single process
        //   - Are our FFmpeg arguments efficient?
        // FlexiVideoBlocks
        [GlobalSetup(Target = nameof(FlexiVideoBlocks_ParseAndRender))]
        public void FlexiVideoBlocks_ParseAndRender_Setup()
        {
            var pipelineBuilder = new MarkdownPipelineBuilder();
            pipelineBuilder.
                UseFlexiVideoBlocks(new FlexiVideoBlocksExtensionOptions(localMediaDirectory: Directory.GetCurrentDirectory())).
                UseFlexiOptionsBlocks();
            _pipeline = pipelineBuilder.Build();

            WritePreview(nameof(FlexiVideoBlocksExtension), FlexiVideoBlocks_ParseAndRender());
        }

        [Benchmark]
        public string FlexiVideoBlocks_ParseAndRender()
        {
            return Markdown.ToHtml(@"v{
    ""src"": ""/url/exampleVideo.mp4"",
    ""generatePoster"": true
}", _pipeline);
        }

        private void WritePreview(string extensionName, string preview)
        {
            Console.WriteLine($"// {extensionName} Benchmark Preview:");
            Console.WriteLine("//");

            using (var stringReader = new StringReader(preview))
            {
                string line;
                while ((line = stringReader.ReadLine()) != null)
                {
                    Console.WriteLine($"// {line}");
                }
            }

            Console.WriteLine();
        }
    }
}
