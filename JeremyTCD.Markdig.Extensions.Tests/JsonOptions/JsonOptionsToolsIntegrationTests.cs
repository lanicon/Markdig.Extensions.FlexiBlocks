﻿using JeremyTCD.Markdig.Extensions.JsonOptions;
using Markdig.Helpers;
using Newtonsoft.Json;
using System;
using Xunit;

namespace JeremyTCD.Markdig.Extensions.Tests
{
    public class JsonOptionsToolsIntegrationTests
    {
        [Fact]
        public void ExtractObject_ExtractsObjectFromJsonOptionsBlock()
        {
            // Arrange
            string value1 = "value1";
            int value2 = 2;
            JsonOptionsBlock dummyJsonOptionsBlock = new JsonOptionsBlock(null)
            {
                Lines = new StringLineGroup($"{{\"Option1\": \"{value1}\", \"Option2\": {value2}}}")
            };

            // Act
            TestOptions result = JsonOptionsTools.ExtractObject<TestOptions>(dummyJsonOptionsBlock);

            // Assert
            Assert.Equal(value1, result.Option1);
            Assert.Equal(value2, result.Option2);
        }

        [Fact]
        public void ExtractObject_ThrowsExceptionIfJsonParsingFails()
        {
            // Arrange
            string json = "{invalid json}";
            int line = 1;
            int column = 2;
            JsonOptionsBlock dummyJsonOptionsBlock = new JsonOptionsBlock(null)
            {
                Lines = new StringLineGroup(json),
                Line = line,
                Column = column
            };

            // Act and assert
            InvalidOperationException result = Assert.Throws<InvalidOperationException>(() => JsonOptionsTools.ExtractObject<TestOptions>(dummyJsonOptionsBlock));
            Assert.Equal(string.Format(Strings.InvalidOperationException_UnableToParseJson, json, line, column), result.Message);
            Assert.True(result.InnerException is JsonException);
        }

        [Fact]
        public void PopulateObject_PopulatesObjectFromJsonOptionsBlock()
        {
            // Arrange
            string value1 = "value1";
            int value2 = 2;
            JsonOptionsBlock dummyJsonOptionsBlock = new JsonOptionsBlock(null)
            {
                Lines = new StringLineGroup($"{{\"Option1\": \"{value1}\"}}")
            };
            TestOptions dummyTestOptions = new TestOptions()
            {
                Option2 = value2
            };

            // Act
            JsonOptionsTools.PopulateObject(dummyJsonOptionsBlock, dummyTestOptions);

            // Assert
            // Properties specified in JSON get overwritten, other properties are left as is
            Assert.Equal(value1, dummyTestOptions.Option1);
            Assert.Equal(value2, dummyTestOptions.Option2);
        }

        [Fact]
        public void PopulateObject_ThrowsExceptionIfJsonParsingFails()
        {
            // Arrange
            string json = "{invalid json}";
            int line = 1;
            int column = 2;
            JsonOptionsBlock dummyJsonOptionsBlock = new JsonOptionsBlock(null)
            {
                Lines = new StringLineGroup(json),
                Line = line,
                Column = column
            };
            TestOptions dummyTestOptions = new TestOptions();

            // Act and assert
            InvalidOperationException result = Assert.Throws<InvalidOperationException>(() => JsonOptionsTools.PopulateObject(dummyJsonOptionsBlock, dummyTestOptions));
            Assert.Equal(string.Format(Strings.InvalidOperationException_UnableToParseJson, json, line, column), result.Message);
            Assert.True(result.InnerException is JsonException);
        }

        private class TestOptions
        {
            public string Option1 { get; set; }
            public int Option2 { get; set; }
        }
    }
}