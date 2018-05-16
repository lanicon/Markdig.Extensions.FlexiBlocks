﻿using Markdig.Helpers;
using Markdig.Parsers;
using Markdig.Syntax;

namespace JeremyTCD.Markdig.Extensions.JsonOptions
{
    public class JsonOptionsParser : BlockParser
    {
        public JsonOptionsParser()
        {
            // If options block is not consumed by the following block, it is rendered as a paragraph or in the preceding paragraph, so {, despite being common, should work fine.
            OpeningCharacters = new[] { '@' };
        }

        // TODO test 
        /// <summary>
        /// Opens a JsonOptionsBlock if a line begins with @{
        /// </summary>
        /// <param name="processor"></param>
        /// <returns>
        /// <see cref="BlockState.None"/> if the current line has code indent or if the current line does not start with @{.
        /// <see cref="BlockState.Break"/> if the current line contains the entire JSON string.
        /// <see cref="BlockState.Continue"/> if the current line contains part of the JSON string.
        /// </returns>
        public override BlockState TryOpen(BlockProcessor processor)
        {
            if (processor.IsCodeIndent)
            {
                return BlockState.None;
            }

            // First line of JSON options must begin with @{
            if (processor.Line.PeekChar() != '{')
            {
                return BlockState.None;
            }

            // Discard "@" by starting line at "{" (BlockProcessor appends processor.Line to the new JsonOptionsBlock, so it must start at the curly bracket)
            processor.Line.Start = 1;

            var jsonOptionsblock = new JsonOptionsBlock(this)
            {
                Column = processor.Column,
                Span = { Start = processor.Line.Start }
            };
            processor.NewBlocks.Push(jsonOptionsblock);

            return TryContinue(processor, jsonOptionsblock);
        }

        /// <summary>
        /// Determines whether or not the <see cref="JsonOptionsBlock"/> is complete by checking whether all opening curly brackets have been closed. 
        /// The JSON spec allows for unescaped curly brackets within strings - https://www.json.org/, so this method ignores everything between unescaped quotes.
        /// 
        /// This function can be improved on - it does not verify that the line is valid JSON.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="jsonOptionsBlock"></param>
        /// <returns>
        /// True if JSON is complete, false otherwise.
        /// </returns>
        public override BlockState TryContinue(BlockProcessor processor, Block block)
        {
            JsonOptionsBlock jsonOptionsBlock = (JsonOptionsBlock)block;
            StringSlice line = processor.Line;
            char pc = line.PeekCharExtra(-1);
            char c = line.CurrentChar;

            while (c != '\0')
            {
                if (!jsonOptionsBlock.EndsInString)
                {
                    if (c == '{')
                    {
                        jsonOptionsBlock.NumOpenBrackets++;
                    }
                    else if (c == '}')
                    {
                        if (--jsonOptionsBlock.NumOpenBrackets == 0)
                        {
                            jsonOptionsBlock.UpdateSpanEnd(line.End);
                            return BlockState.Break;
                        }
                    }
                    else if (pc != '\\' && c == '"')
                    {
                        jsonOptionsBlock.EndsInString = true;
                    }
                }
                else if (pc != '\\' && c == '"')
                {
                    jsonOptionsBlock.EndsInString = false;
                }

                pc = c;
                c = line.NextChar();
            }

            return BlockState.Continue;
        }
    }
}