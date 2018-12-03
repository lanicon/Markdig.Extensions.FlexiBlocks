﻿using Jering.Markdig.Extensions.FlexiBlocks.FlexiCodeBlocks;
using Jering.Markdig.Extensions.FlexiBlocks.FlexiOptionsBlocks;
using Jering.Web.SyntaxHighlighters.HighlightJS;
using Jering.Web.SyntaxHighlighters.Prism;
using Markdig.Helpers;
using Markdig.Parsers;
using Markdig.Syntax;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Jering.Markdig.Extensions.FlexiBlocks.Tests.FlexiCodeBlocks
{
    public class FlexiCodeBlocksExtensionUnitTests
    {
        private readonly MockRepository _mockRepository = new MockRepository(MockBehavior.Default) { DefaultValue = DefaultValue.Mock };

        [Theory]
        [MemberData(nameof(ValidateLineRange_ThrowsFlexiBlocksExceptionIfLineRangeIsNotASubsetOfTheFullRangeOfLines_Data))]
        public void ValidateLineRange_ThrowsFlexiBlocksExceptionIfLineRangeIsNotASubsetOfTheFullRangeOfLines(SerializableWrapper<LineRange> lineRangeWrapper,
            int dummyNumLines)
        {
            // Arrange
            const string dummyPropertyName = "dummyPropertyName";
            FlexiCodeBlocksExtension testSubject = CreateFlexiCodeBlocksExtension();

            // Act and assert
            FlexiBlocksException result = Assert.Throws<FlexiBlocksException>(() => testSubject.ValidateLineRange(lineRangeWrapper.Value, dummyNumLines, dummyPropertyName));
            Assert.Equal(string.Format(Strings.FlexiBlocksException_OptionLineRangeNotASubset, lineRangeWrapper.Value.ToString(), dummyPropertyName, dummyNumLines),
                result.Message);
        }

        public static IEnumerable<object[]> ValidateLineRange_ThrowsFlexiBlocksExceptionIfLineRangeIsNotASubsetOfTheFullRangeOfLines_Data()
        {
            return new object[][]
            {
                // Line range begins after full range of lines
                new object[]
                {
                    new SerializableWrapper<LineRange>(new LineRange(10)),
                    9
                },
                // Start of line range overlaps full range of lines 
                new object[]
                {
                    new SerializableWrapper<LineRange>(new LineRange(5, 11)),
                    9
                },
                // No lines
                new object[]
                {
                    new SerializableWrapper<LineRange>(new LineRange()),
                    0
                }
            };
        }

        [Theory]
        [MemberData(nameof(ValidateLineRange_DoesNotThrowFlexiBlocksExceptionIfLineRangeIsASubsetOfTheFullRangeOfLines_Data))]
        public void ValidateLineRange_DoesNotThrowFlexiBlocksExceptionIfLineRangeIsASubsetOfTheFullRangeOfLines(SerializableWrapper<LineRange> lineRangeWrapper,
            int numLines)
        {
            // Arrange
            const string dummyPropertyName = "dummyPropertyName";
            FlexiCodeBlocksExtension testSubject = CreateFlexiCodeBlocksExtension();

            // Act and assert
            testSubject.ValidateLineRange(lineRangeWrapper.Value, numLines, dummyPropertyName); // Test passes as long as this doesn't throw
        }

        public static IEnumerable<object[]> ValidateLineRange_DoesNotThrowFlexiBlocksExceptionIfLineRangeIsASubsetOfTheFullRangeOfLines_Data()
        {
            return new object[][]
            {
                // Line range == full range
                new object[]
                {
                    new SerializableWrapper<LineRange>(new LineRange(1, 10)),
                    10
                },
                // Line range is a proper subset of the full range
                new object[]
                {
                    new SerializableWrapper<LineRange>(new LineRange(5, 8)),
                    10
                }
            };
        }

        [Fact]
        public void OnFlexiBlockClosed_CreatesFlexiCodeBlockOptionsAndValidatesContainedLineRanges()
        {
            // Arrange
            var dummyHighlightLineRanges = new List<LineRange>
            {
                { new LineRange(1, 5) },
                { new LineRange(6, -1) },
            };
            var dummyLineNumberLineRanges = new List<NumberedLineRange>
            {
                { new NumberedLineRange(1, 5) },
                { new NumberedLineRange(6, -1) },
            };
            var dummyFlexiCodeBlocksExtensionOptions = new FlexiCodeBlocksExtensionOptions
            {
                DefaultBlockOptions = new FlexiCodeBlockOptions(highlightLineRanges: dummyHighlightLineRanges, lineNumberLineRanges: dummyLineNumberLineRanges)
            };
            BlockProcessor dummyBlockProcessor = MarkdigTypesFactory.CreateBlockProcessor();
            var dummyLine1 = new StringSlice("dummyLine1");
            var dummyLine2 = new StringSlice("dummyLine2");
            var dummyLines = new StringLineGroup(2)
            {
                new StringLine(ref dummyLine1),
                new StringLine(ref dummyLine2)
            };
            const int dummyLineIndex = 2;
            var dummyBlock = new CodeBlock(null) { Line = dummyLineIndex, Lines = dummyLines };
            Mock<IFlexiOptionsBlockService> mockFlexiOptionsBlockService = _mockRepository.Create<IFlexiOptionsBlockService>();
            mockFlexiOptionsBlockService.Setup(f => f.TryPopulateOptions(dummyBlockProcessor, It.IsAny<FlexiCodeBlockOptions>(), dummyLineIndex));
            Mock<ExposedFlexiCodeBlocksExtension> mockTestSubject = CreateMockExposedFlexiCodeBlocksExtension(extensionOptions: dummyFlexiCodeBlocksExtensionOptions,
               flexiOptionsBlockService: mockFlexiOptionsBlockService.Object);
            mockTestSubject.CallBase = true;
            mockTestSubject.
                Setup(t => t.ValidateLineRange(dummyHighlightLineRanges.Last(), dummyLines.Count, nameof(FlexiCodeBlockOptions.HighlightLineRanges)));
            mockTestSubject.
                Setup(t => t.ValidateLineRange(dummyLineNumberLineRanges.Last(), dummyLines.Count, nameof(FlexiCodeBlockOptions.LineNumberLineRanges)));

            // Act
            mockTestSubject.Object.ExposedOnFlexiBlockClosed(dummyBlockProcessor, dummyBlock);

            // Assert
            _mockRepository.VerifyAll();
            var result = dummyBlock.GetData(FlexiCodeBlocksExtension.FLEXI_CODE_BLOCK_OPTIONS_KEY) as FlexiCodeBlockOptions;
            Assert.NotNull(result);
        }

        public class ExposedFlexiCodeBlocksExtension : FlexiCodeBlocksExtension
        {
            public ExposedFlexiCodeBlocksExtension(FlexiCodeBlockRenderer flexiCodeBlockRenderer,
                IFlexiOptionsBlockService flexiOptionsBlockService,
                FlexiCodeBlocksExtensionOptions extensionOptions) : base(flexiCodeBlockRenderer, flexiOptionsBlockService, extensionOptions)
            {
            }

            public void ExposedOnFlexiBlockClosed(BlockProcessor processor, Block block)
            {
                base.OnFlexiBlockClosed(processor, block);
            }
        }

        private Mock<ExposedFlexiCodeBlocksExtension> CreateMockExposedFlexiCodeBlocksExtension(FlexiCodeBlockRenderer flexiCodeBlockRenderer = null,
            FlexiCodeBlocksExtensionOptions extensionOptions = null,
            IFlexiOptionsBlockService flexiOptionsBlockService = null)
        {
            return _mockRepository.Create<ExposedFlexiCodeBlocksExtension>(flexiCodeBlockRenderer ?? CreateFlexiCodeBlockRenderer(),
                flexiOptionsBlockService ?? _mockRepository.Create<IFlexiOptionsBlockService>().Object,
                extensionOptions ?? new FlexiCodeBlocksExtensionOptions());
        }

        private FlexiCodeBlocksExtension CreateFlexiCodeBlocksExtension(FlexiCodeBlockRenderer flexiCodeBlockRenderer = null,
            IFlexiOptionsBlockService flexiOptionsBlockService = null,
            FlexiCodeBlocksExtensionOptions extensionOptions = null)
        {
            return new FlexiCodeBlocksExtension(flexiCodeBlockRenderer ?? CreateFlexiCodeBlockRenderer(),
                flexiOptionsBlockService ?? _mockRepository.Create<IFlexiOptionsBlockService>().Object,
                extensionOptions ?? new FlexiCodeBlocksExtensionOptions());
        }

        private FlexiCodeBlockRenderer CreateFlexiCodeBlockRenderer()
        {
            return new FlexiCodeBlockRenderer(_mockRepository.Create<IPrismService>().Object,
                _mockRepository.Create<IHighlightJSService>().Object,
                _mockRepository.Create<ILineEmbellisherService>().Object);
        }
    }
}