﻿using Markdig;
using System;

namespace Jering.Markdig.Extensions.FlexiBlocks.FlexiOptionsBlocks
{
    /// <summary>
    /// A Markdig extension for <see cref="FlexiOptionsBlock"/>s.
    /// </summary>
    public class FlexiOptionsBlocksExtension : FlexiBlocksExtension
    {
        private readonly FlexiOptionsBlockParser _flexiOptionsBlockParser;

        /// <summary>
        /// Creates a <see cref="FlexiOptionsBlocksExtension"/> instance.
        /// </summary>
        /// <param name="flexiOptionsBlockParser">The parser for creating <see cref="FlexiOptionsBlock"/>s from markdown.</param>
        public FlexiOptionsBlocksExtension(FlexiOptionsBlockParser flexiOptionsBlockParser)
        {
            _flexiOptionsBlockParser = flexiOptionsBlockParser ?? throw new ArgumentNullException(nameof(flexiOptionsBlockParser));
        }

        /// <summary>
        /// Registers a <see cref="FlexiOptionsBlockParser"/> if one isn't already registered.
        /// </summary>
        /// <param name="pipeline">The pipeline builder to register the parser for.</param>
        public override void Setup(MarkdownPipelineBuilder pipeline)
        {
            if(pipeline == null)
            {
                throw new ArgumentNullException(nameof(pipeline));
            }

            if (!pipeline.BlockParsers.Contains<FlexiOptionsBlockParser>())
            {
                pipeline.BlockParsers.Insert(0, _flexiOptionsBlockParser);
            }
        }
    }
}
