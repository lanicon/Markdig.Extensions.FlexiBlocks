﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Jering.Markdig.Extensions.FlexiBlocks {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Jering.Markdig.Extensions.FlexiBlocks.Strings", typeof(Strings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value cannot be null, whitespace or an empty string..
        /// </summary>
        internal static string ArgumentException_Shared_ValueCannotBeNullWhitespaceOrAnEmptyString {
            get {
                return ResourceManager.GetString("ArgumentException_Shared_ValueCannotBeNullWhitespaceOrAnEmptyString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value cannot be negative. The specified value &quot;{0}&quot; is invalid..
        /// </summary>
        internal static string ArgumentOutOfRangeException_Shared_ValueCannotBeNegative {
            get {
                return ResourceManager.GetString("ArgumentOutOfRangeException_Shared_ValueCannotBeNegative", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value must be within range {0}. The specified value &quot;{1}&quot; is invalid..
        /// </summary>
        internal static string ArgumentOutOfRangeException_Shared_ValueMustBeWithinRange {
            get {
                return ResourceManager.GetString("ArgumentOutOfRangeException_Shared_ValueMustBeWithinRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The option {0} must be within the range &quot;{1}&quot;. The specified value &quot;{2}&quot; is invalid..
        /// </summary>
        internal static string FlexiBlocksException_Clipping_OptionMustBeWithinRange {
            get {
                return ResourceManager.GetString("FlexiBlocksException_Clipping_OptionMustBeWithinRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The disk cache directory &quot;{0}&quot; is invalid. Refer to the inner exception for more details..
        /// </summary>
        internal static string FlexiBlocksException_DiskCacheService_InvalidDiskCacheDirectory {
            get {
                return ResourceManager.GetString("FlexiBlocksException_DiskCacheService_InvalidDiskCacheDirectory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An unexpected exception occurred when attempting to retrieve the source for &quot;{0}&quot;, from the disk cache at &quot;{1}&quot;. Refer to the inner exception for more information..
        /// </summary>
        internal static string FlexiBlocksException_DiskCacheService_UnexpectedDiskCacheException {
            get {
                return ResourceManager.GetString("FlexiBlocksException_DiskCacheService_UnexpectedDiskCacheException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An exception occurred in &quot;{0}&quot; while attempting to open a block. Refer to the inner exception for more details..
        /// </summary>
        internal static string FlexiBlocksException_FlexiBlockParser_ExceptionOccurredWhileAttemptingToOpenBlock {
            get {
                return ResourceManager.GetString("FlexiBlocksException_FlexiBlockParser_ExceptionOccurredWhileAttemptingToOpenBlock" +
                        "", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An exception occurred while processing the block. Refer to the inner exception for more details..
        /// </summary>
        internal static string FlexiBlocksException_FlexiBlocksException_ExceptionOccurredWhileProcessingABlock {
            get {
                return ResourceManager.GetString("FlexiBlocksException_FlexiBlocksException_ExceptionOccurredWhileProcessingABlock", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} starting at line &quot;{1}&quot;, column &quot;{2}&quot;, is invalid:
        ///{3}.
        /// </summary>
        internal static string FlexiBlocksException_FlexiBlocksException_InvalidFlexiBlock {
            get {
                return ResourceManager.GetString("FlexiBlocksException_FlexiBlocksException_InvalidFlexiBlock", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The markdown at line &quot;{0}&quot;, column &quot;{1}&quot; is invalid:
        ///{2}.
        /// </summary>
        internal static string FlexiBlocksException_FlexiBlocksException_InvalidMarkdown {
            get {
                return ResourceManager.GetString("FlexiBlocksException_FlexiBlocksException_InvalidMarkdown", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The line ranges in option {0} are invalid. These line ranges must not overlap, but the line ranges &quot;{1}&quot; and &quot;{2}&quot; do..
        /// </summary>
        internal static string FlexiBlocksException_FlexiCodeBlockOptions_OptionLineRangesCannotOverlap {
            get {
                return ResourceManager.GetString("FlexiBlocksException_FlexiCodeBlockOptions_OptionLineRangesCannotOverlap", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The line ranges in option {0} are invalid. These line ranges must be sequential, the line range &quot;{1}&quot; must be specified after line range &quot;{2}&quot;..
        /// </summary>
        internal static string FlexiBlocksException_FlexiCodeBlockOptions_OptionLineRangesMustBeSequential {
            get {
                return ResourceManager.GetString("FlexiBlocksException_FlexiCodeBlockOptions_OptionLineRangesMustBeSequential", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The line range &quot;{0}&quot; in option {1} is not a subset of the full range of lines, &quot;[1, {2}]&quot;..
        /// </summary>
        internal static string FlexiBlocksException_FlexiCodeBlocksExtension_OptionLineRangeNotASubset {
            get {
                return ResourceManager.GetString("FlexiBlocksException_FlexiCodeBlocksExtension_OptionLineRangeNotASubset", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The option {0} must be an absolute URI. The specified value &quot;{1}&quot; is invalid..
        /// </summary>
        internal static string FlexiBlocksException_FlexiIncludeBlock_OptionMustBeAnAbsoluteUri {
            get {
                return ResourceManager.GetString("FlexiBlocksException_FlexiIncludeBlock_OptionMustBeAnAbsoluteUri", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The option {0} must be a URI with scheme FILE, HTTP or HTTPS. The specified URI &quot;{1}&quot; has invalid scheme &quot;{2}&quot;..
        /// </summary>
        internal static string FlexiBlocksException_FlexiIncludeBlock_OptionMustBeAUriWithASupportedScheme {
            get {
                return ResourceManager.GetString("FlexiBlocksException_FlexiIncludeBlock_OptionMustBeAUriWithASupportedScheme", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The option {0} must be a valid URI. The specified value &quot;{1}&quot; is invalid..
        /// </summary>
        internal static string FlexiBlocksException_FlexiIncludeBlock_OptionMustBeAValidUri {
            get {
                return ResourceManager.GetString("FlexiBlocksException_FlexiIncludeBlock_OptionMustBeAValidUri", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The following cycle was found in the FlexiIncludeBlock tree: 
        ///{0}.
        /// </summary>
        internal static string FlexiBlocksException_FlexiIncludeBlockParser_CycleFound {
            get {
                return ResourceManager.GetString("FlexiBlocksException_FlexiIncludeBlockParser_CycleFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An exception occured while processing the FlexiIncludeBlock..
        /// </summary>
        internal static string FlexiBlocksException_FlexiIncludeBlockParser_ExceptionOccurredWhileProcessingBlock {
            get {
                return ResourceManager.GetString("FlexiBlocksException_FlexiIncludeBlockParser_ExceptionOccurredWhileProcessingBloc" +
                        "k", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An exception occured while processing the FlexiIncludeBlock&apos;s {0}. Refer to the inner exception for more details..
        /// </summary>
        internal static string FlexiBlocksException_FlexiIncludeBlockParser_ExceptionOccurredWhileProcessingContent {
            get {
                return ResourceManager.GetString("FlexiBlocksException_FlexiIncludeBlockParser_ExceptionOccurredWhileProcessingCont" +
                        "ent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An exception occured while processing the FlexiIncludeBlock&apos;s source, &quot;{0}&quot;. Refer to the inner exception for more details..
        /// </summary>
        internal static string FlexiBlocksException_FlexiIncludeBlockParser_ExceptionOccurredWhileProcessingSource {
            get {
                return ResourceManager.GetString("FlexiBlocksException_FlexiIncludeBlockParser_ExceptionOccurredWhileProcessingSour" +
                        "ce", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid clipping, no line contains end line substring &quot;{0}&quot;..
        /// </summary>
        internal static string FlexiBlocksException_FlexiIncludeBlockParser_InvalidClippingNoLineContainsEndLineSubstring {
            get {
                return ResourceManager.GetString("FlexiBlocksException_FlexiIncludeBlockParser_InvalidClippingNoLineContainsEndLine" +
                        "Substring", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid clipping, no line contains start line substring &quot;{0}&quot;..
        /// </summary>
        internal static string FlexiBlocksException_FlexiIncludeBlockParser_InvalidClippingNoLineContainsStartLineSubstring {
            get {
                return ResourceManager.GetString("FlexiBlocksException_FlexiIncludeBlockParser_InvalidClippingNoLineContainsStartLi" +
                        "neSubstring", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to FlexiOptionsBlock must be consumed..
        /// </summary>
        internal static string FlexiBlocksException_FlexiOptionsBlockParser_UnconsumedBlock {
            get {
                return ResourceManager.GetString("FlexiBlocksException_FlexiOptionsBlockParser_UnconsumedBlock", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to FlexiOptionsBlock must immediately precede the block that consumes it..
        /// </summary>
        internal static string FlexiBlocksException_FlexiOptionsBlockService_MispositionedBlock {
            get {
                return ResourceManager.GetString("FlexiBlocksException_FlexiOptionsBlockService_MispositionedBlock", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The option {0} must be  -1 or not less than its associated start line number. The specified value &quot;{1}&quot; with associated start line number &quot;{2}&quot; is invalid. .
        /// </summary>
        internal static string FlexiBlocksException_Shared_EndLineNumberMustBeMinus1OrGreaterThanOrEqualToStartLineNumber {
            get {
                return ResourceManager.GetString("FlexiBlocksException_Shared_EndLineNumberMustBeMinus1OrGreaterThanOrEqualToStartL" +
                        "ineNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The option {0} has invalid value &quot;{1}&quot;. Refer to the inner exception for more details..
        /// </summary>
        internal static string FlexiBlocksException_Shared_OptionIsAnInvalidFormat {
            get {
                return ResourceManager.GetString("FlexiBlocksException_Shared_OptionIsAnInvalidFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value &quot;{0}&quot; for option {1} is not within the range of valid values for the enum {2}..
        /// </summary>
        internal static string FlexiBlocksException_Shared_OptionMustBeAValidEnumValue {
            get {
                return ResourceManager.GetString("FlexiBlocksException_Shared_OptionMustBeAValidEnumValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The option {0} must be greater than 0. The specified value &quot;{1}&quot; is invalid..
        /// </summary>
        internal static string FlexiBlocksException_Shared_OptionMustBeGreaterThan0 {
            get {
                return ResourceManager.GetString("FlexiBlocksException_Shared_OptionMustBeGreaterThan0", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The option {0} cannot be null..
        /// </summary>
        internal static string FlexiBlocksException_Shared_OptionsMustNotBeNull {
            get {
                return ResourceManager.GetString("FlexiBlocksException_Shared_OptionsMustNotBeNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to parse JSON &quot;{0}&quot;. Refer to the inner exception for more details..
        /// </summary>
        internal static string FlexiBlocksException_Shared_UnableToParseJson {
            get {
                return ResourceManager.GetString("FlexiBlocksException_Shared_UnableToParseJson", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Multiple attempts to retrieve content from the remote URI &quot;{0}&quot; have failed. Please ensure that the URI is valid and that your network connection is stable. Enable debug level logging and try again for more information on why requests are failing..
        /// </summary>
        internal static string FlexiBlocksException_SourceRetrieverService_FailedAfterMultipleAttempts {
            get {
                return ResourceManager.GetString("FlexiBlocksException_SourceRetrieverService_FailedAfterMultipleAttempts", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The local URI &quot;{0}&quot; is invalid. Refer to the inner exception for more details..
        /// </summary>
        internal static string FlexiBlocksException_SourceRetrieverService_InvalidLocalUri {
            get {
                return ResourceManager.GetString("FlexiBlocksException_SourceRetrieverService_InvalidLocalUri", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Access to the remote URI &quot;{0}&quot; is forbidden..
        /// </summary>
        internal static string FlexiBlocksException_SourceRetrieverService_RemoteUriAccessForbidden {
            get {
                return ResourceManager.GetString("FlexiBlocksException_SourceRetrieverService_RemoteUriAccessForbidden", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The remote URI &quot;{0}&quot; does not exist..
        /// </summary>
        internal static string FlexiBlocksException_SourceRetrieverService_RemoteUriDoesNotExist {
            get {
                return ResourceManager.GetString("FlexiBlocksException_SourceRetrieverService_RemoteUriDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The markup fragment &quot;{0}&quot; is invalid. An exception was thrown while attempting to split multi-line elements within it..
        /// </summary>
        internal static string InvalidOperationException_LineEmbellisherService_InvalidMarkupFragment {
            get {
                return ResourceManager.GetString("InvalidOperationException_LineEmbellisherService_InvalidMarkupFragment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The markup fragment &quot;{0}&quot; is invalid. An exception was thrown while attempting to split multi-line elements within it. Refer to the inner exception for more details..
        /// </summary>
        internal static string InvalidOperationException_LineEmbellisherService_InvalidMarkupFragmentWithInnerException {
            get {
                return ResourceManager.GetString("InvalidOperationException_LineEmbellisherService_InvalidMarkupFragmentWithInnerEx" +
                        "ception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The file &quot;{0}&quot; is in use. {1} tries remaining..
        /// </summary>
        internal static string LogWarning_DiskCacheService_FileInUse {
            get {
                return ResourceManager.GetString("LogWarning_DiskCacheService_FileInUse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Http request to &quot;{0}&quot; failed with status code &quot;{1}&quot;, {2} tries remaining..
        /// </summary>
        internal static string LogWarning_SourceRetrieverService_FailureStatusCode {
            get {
                return ResourceManager.GetString("LogWarning_SourceRetrieverService_FailureStatusCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A HttpRequestException with message &quot;{0}&quot; occurred when attempting to retrieve content from &quot;{1}&quot;, {2} tries remaining..
        /// </summary>
        internal static string LogWarning_SourceRetrieverService_HttpRequestException {
            get {
                return ResourceManager.GetString("LogWarning_SourceRetrieverService_HttpRequestException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attempt to retrieve content from &quot;{0}&quot; timed out, {1} tries remaining..
        /// </summary>
        internal static string LogWarning_SourceRetrieverService_Timeout {
            get {
                return ResourceManager.GetString("LogWarning_SourceRetrieverService_Timeout", resourceCulture);
            }
        }
    }
}
