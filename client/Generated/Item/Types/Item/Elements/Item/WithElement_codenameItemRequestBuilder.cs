using Kontent.Ai.Delivery.Kiota.Models;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Kontent.Ai.Delivery.Kiota.Item.Types.Item.Elements.Item {
    /// <summary>Builds and executes requests for operations under \{project_id}\types\{type_codename}\elements\{element_codename}</summary>
    public class WithElement_codenameItemRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Instantiates a new WithElement_codenameItemRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public WithElement_codenameItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/{project_id}/types/{type_codename}/elements/{element_codename}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Instantiates a new WithElement_codenameItemRequestBuilder and sets the default values.
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public WithElement_codenameItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) {
            if(string.IsNullOrEmpty(rawUrl)) throw new ArgumentNullException(nameof(rawUrl));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/{project_id}/types/{type_codename}/elements/{element_codename}";
            var urlTplParams = new Dictionary<string, object>();
            urlTplParams.Add("request-raw-url", rawUrl);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Retrieve a content element defined in a specific content type. Both must be specified by their codenames.
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<WithElement_codenameItemRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new WithElement_codenameItemRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Retrieve a content element defined in a specific content type. Both must be specified by their codenames.
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public async Task<WithElement_codenameResponse> GetAsync(Action<WithElement_codenameItemRequestBuilderGetRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreateGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"404", DeliveryError.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<WithElement_codenameResponse>(requestInfo, WithElement_codenameResponse.CreateFromDiscriminatorValue, errorMapping, cancellationToken);
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class WithElement_codenameItemRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new WithElement_codenameItemRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public WithElement_codenameItemRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
        /// <summary>Composed type wrapper for classes AssetElement, CustomElement, DateTimeElement, LinkedItemsElement, MultipleChoiceElement, NumberElement, SubpagesElement, TaxonomyElement, TextElement, RichTextElement, UrlSlugElement</summary>
        public class WithElement_codenameResponse : IAdditionalDataHolder, IParsable {
            /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
            public IDictionary<string, object> AdditionalData { get; set; }
            /// <summary>Composed type representation for type AssetElement</summary>
            public Kontent.Ai.Delivery.Kiota.Models.AssetElement AssetElement { get; set; }
            /// <summary>Composed type representation for type CustomElement</summary>
            public Kontent.Ai.Delivery.Kiota.Models.CustomElement CustomElement { get; set; }
            /// <summary>Composed type representation for type DateTimeElement</summary>
            public Kontent.Ai.Delivery.Kiota.Models.DateTimeElement DateTimeElement { get; set; }
            /// <summary>Composed type representation for type LinkedItemsElement</summary>
            public Kontent.Ai.Delivery.Kiota.Models.LinkedItemsElement LinkedItemsElement { get; set; }
            /// <summary>Composed type representation for type MultipleChoiceElement</summary>
            public Kontent.Ai.Delivery.Kiota.Models.MultipleChoiceElement MultipleChoiceElement { get; set; }
            /// <summary>Composed type representation for type NumberElement</summary>
            public Kontent.Ai.Delivery.Kiota.Models.NumberElement NumberElement { get; set; }
            /// <summary>Composed type representation for type RichTextElement</summary>
            public Kontent.Ai.Delivery.Kiota.Models.RichTextElement RichTextElement { get; set; }
            /// <summary>Serialization hint for the current wrapper.</summary>
            public string SerializationHint { get; set; }
            /// <summary>Composed type representation for type SubpagesElement</summary>
            public Kontent.Ai.Delivery.Kiota.Models.SubpagesElement SubpagesElement { get; set; }
            /// <summary>Composed type representation for type TaxonomyElement</summary>
            public Kontent.Ai.Delivery.Kiota.Models.TaxonomyElement TaxonomyElement { get; set; }
            /// <summary>Composed type representation for type TextElement</summary>
            public Kontent.Ai.Delivery.Kiota.Models.TextElement TextElement { get; set; }
            /// <summary>Composed type representation for type UrlSlugElement</summary>
            public Kontent.Ai.Delivery.Kiota.Models.UrlSlugElement UrlSlugElement { get; set; }
            /// <summary>
            /// Instantiates a new WithElement_codenameResponse and sets the default values.
            /// </summary>
            public WithElement_codenameResponse() {
                AdditionalData = new Dictionary<string, object>();
            }
            /// <summary>
            /// Creates a new instance of the appropriate class based on discriminator value
            /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
            /// </summary>
            public static WithElement_codenameResponse CreateFromDiscriminatorValue(IParseNode parseNode) {
                _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
                var mappingValue = parseNode.GetChildNode("")?.GetStringValue();
                var result = new WithElement_codenameResponse();
                if("AssetElement".Equals(mappingValue, StringComparison.OrdinalIgnoreCase)) {
                    result.AssetElement = new Kontent.Ai.Delivery.Kiota.Models.AssetElement();
                }
                else if("CustomElement".Equals(mappingValue, StringComparison.OrdinalIgnoreCase)) {
                    result.CustomElement = new Kontent.Ai.Delivery.Kiota.Models.CustomElement();
                }
                else if("DateTimeElement".Equals(mappingValue, StringComparison.OrdinalIgnoreCase)) {
                    result.DateTimeElement = new Kontent.Ai.Delivery.Kiota.Models.DateTimeElement();
                }
                else if("LinkedItemsElement".Equals(mappingValue, StringComparison.OrdinalIgnoreCase)) {
                    result.LinkedItemsElement = new Kontent.Ai.Delivery.Kiota.Models.LinkedItemsElement();
                }
                else if("MultipleChoiceElement".Equals(mappingValue, StringComparison.OrdinalIgnoreCase)) {
                    result.MultipleChoiceElement = new Kontent.Ai.Delivery.Kiota.Models.MultipleChoiceElement();
                }
                else if("NumberElement".Equals(mappingValue, StringComparison.OrdinalIgnoreCase)) {
                    result.NumberElement = new Kontent.Ai.Delivery.Kiota.Models.NumberElement();
                }
                else if("RichTextElement".Equals(mappingValue, StringComparison.OrdinalIgnoreCase)) {
                    result.RichTextElement = new Kontent.Ai.Delivery.Kiota.Models.RichTextElement();
                }
                else if("SubpagesElement".Equals(mappingValue, StringComparison.OrdinalIgnoreCase)) {
                    result.SubpagesElement = new Kontent.Ai.Delivery.Kiota.Models.SubpagesElement();
                }
                else if("TaxonomyElement".Equals(mappingValue, StringComparison.OrdinalIgnoreCase)) {
                    result.TaxonomyElement = new Kontent.Ai.Delivery.Kiota.Models.TaxonomyElement();
                }
                else if("TextElement".Equals(mappingValue, StringComparison.OrdinalIgnoreCase)) {
                    result.TextElement = new Kontent.Ai.Delivery.Kiota.Models.TextElement();
                }
                else if("UrlSlugElement".Equals(mappingValue, StringComparison.OrdinalIgnoreCase)) {
                    result.UrlSlugElement = new Kontent.Ai.Delivery.Kiota.Models.UrlSlugElement();
                }
                return result;
            }
            /// <summary>
            /// The deserialization information for the current model
            /// </summary>
            public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
                if(AssetElement != null) {
                    return AssetElement.GetFieldDeserializers();
                }
                else if(CustomElement != null) {
                    return CustomElement.GetFieldDeserializers();
                }
                else if(DateTimeElement != null) {
                    return DateTimeElement.GetFieldDeserializers();
                }
                else if(LinkedItemsElement != null) {
                    return LinkedItemsElement.GetFieldDeserializers();
                }
                else if(MultipleChoiceElement != null) {
                    return MultipleChoiceElement.GetFieldDeserializers();
                }
                else if(NumberElement != null) {
                    return NumberElement.GetFieldDeserializers();
                }
                else if(RichTextElement != null) {
                    return RichTextElement.GetFieldDeserializers();
                }
                else if(SubpagesElement != null) {
                    return SubpagesElement.GetFieldDeserializers();
                }
                else if(TaxonomyElement != null) {
                    return TaxonomyElement.GetFieldDeserializers();
                }
                else if(TextElement != null) {
                    return TextElement.GetFieldDeserializers();
                }
                else if(UrlSlugElement != null) {
                    return UrlSlugElement.GetFieldDeserializers();
                }
                return new Dictionary<string, Action<IParseNode>>();
            }
            /// <summary>
            /// Serializes information the current object
            /// <param name="writer">Serialization writer to use to serialize this model</param>
            /// </summary>
            public void Serialize(ISerializationWriter writer) {
                _ = writer ?? throw new ArgumentNullException(nameof(writer));
                if(AssetElement != null) {
                    writer.WriteObjectValue<Kontent.Ai.Delivery.Kiota.Models.AssetElement>(null, AssetElement);
                }
                else if(CustomElement != null) {
                    writer.WriteObjectValue<Kontent.Ai.Delivery.Kiota.Models.CustomElement>(null, CustomElement);
                }
                else if(DateTimeElement != null) {
                    writer.WriteObjectValue<Kontent.Ai.Delivery.Kiota.Models.DateTimeElement>(null, DateTimeElement);
                }
                else if(LinkedItemsElement != null) {
                    writer.WriteObjectValue<Kontent.Ai.Delivery.Kiota.Models.LinkedItemsElement>(null, LinkedItemsElement);
                }
                else if(MultipleChoiceElement != null) {
                    writer.WriteObjectValue<Kontent.Ai.Delivery.Kiota.Models.MultipleChoiceElement>(null, MultipleChoiceElement);
                }
                else if(NumberElement != null) {
                    writer.WriteObjectValue<Kontent.Ai.Delivery.Kiota.Models.NumberElement>(null, NumberElement);
                }
                else if(RichTextElement != null) {
                    writer.WriteObjectValue<Kontent.Ai.Delivery.Kiota.Models.RichTextElement>(null, RichTextElement);
                }
                else if(SubpagesElement != null) {
                    writer.WriteObjectValue<Kontent.Ai.Delivery.Kiota.Models.SubpagesElement>(null, SubpagesElement);
                }
                else if(TaxonomyElement != null) {
                    writer.WriteObjectValue<Kontent.Ai.Delivery.Kiota.Models.TaxonomyElement>(null, TaxonomyElement);
                }
                else if(TextElement != null) {
                    writer.WriteObjectValue<Kontent.Ai.Delivery.Kiota.Models.TextElement>(null, TextElement);
                }
                else if(UrlSlugElement != null) {
                    writer.WriteObjectValue<Kontent.Ai.Delivery.Kiota.Models.UrlSlugElement>(null, UrlSlugElement);
                }
                writer.WriteAdditionalData(AdditionalData);
            }
        }
    }
}
