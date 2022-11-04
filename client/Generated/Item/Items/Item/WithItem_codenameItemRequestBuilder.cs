using Kontent.Ai.Delivery.Kiota.Models;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Kontent.Ai.Delivery.Kiota.Item.Items.Item {
    /// <summary>Builds and executes requests for operations under \{project_id}\items\{item_codename}</summary>
    public class WithItem_codenameItemRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Instantiates a new WithItem_codenameItemRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public WithItem_codenameItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/{project_id}/items/{item_codename}{?language*,elements,depth*}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Instantiates a new WithItem_codenameItemRequestBuilder and sets the default values.
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public WithItem_codenameItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) {
            if(string.IsNullOrEmpty(rawUrl)) throw new ArgumentNullException(nameof(rawUrl));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/{project_id}/items/{item_codename}{?language*,elements,depth*}";
            var urlTplParams = new Dictionary<string, object>();
            urlTplParams.Add("request-raw-url", rawUrl);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Retrieve a specific content item by specifying its codename.The [response size](#section/Response-size) is limited to 2000 items.
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<WithItem_codenameItemRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new WithItem_codenameItemRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Retrieve a specific content item by specifying its codename.The [response size](#section/Response-size) is limited to 2000 items.
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public async Task<WithItem_codenameResponse> GetAsync(Action<WithItem_codenameItemRequestBuilderGetRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreateGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"404", DeliveryError.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<WithItem_codenameResponse>(requestInfo, WithItem_codenameResponse.CreateFromDiscriminatorValue, errorMapping, cancellationToken);
        }
        /// <summary>Retrieve a specific content item by specifying its codename.The [response size](#section/Response-size) is limited to 2000 items.</summary>
        public class WithItem_codenameItemRequestBuilderGetQueryParameters {
            /// <summary>Determines the level of nesting for content items that the API returns. By default, only the first level of linked items is returned, which is the same as setting `depth=1`.If you want to include more than one level of linked items in response, set the `depth` query parameter to `2` or more.If you need to exclude all linked items from the response, set the parameter to `0`.&lt;div class=&quot;callout callout--info&quot;&gt;&lt;p&gt;Components are always present in response. See &lt;a data-item-id=&quot;286dbb0e-f673-494f-abfd-3f39c7ec3446&quot; href=&quot;https://kontent.ai/learn/link-to/linked_content_and_components&quot;&gt;Linked content and components&lt;/a&gt; for more details.&lt;/p&gt;&lt;/div&gt;</summary>
            public int? Depth { get; set; }
            /// <summary>Determines the elements to retrieve using a comma-separated list of element codenames. The `elements` query parameter applies to all content items within the response.If not specified, all elements are retrieved. For more details, see [Projection](/learn/reference/delivery-api/#tag/Projection).</summary>
            public string[] Elements { get; set; }
            /// <summary>Determines which language variant of content items to return. By default, the API returns content in the default language.&lt;div class=&quot;callout callout--info&quot;&gt;&lt;p&gt;If the requested content is not available in the specified language variant, the API follows the &lt;a data-item-id=&quot;9e0f560c-5ee4-4649-818a-c5f934b82f4a&quot; href=&quot;https://kontent.ai/learn/link-to/set_up_langauges&quot;&gt;language fallbacks&lt;/a&gt; as configured in the &lt;a data-item-id=&quot;9e0f560c-5ee4-4649-818a-c5f934b82f4a&quot; href=&quot;https://kontent.ai/learn/link-to/set_up_langauges&quot;&gt;Localization&lt;/a&gt; settings of your project.&lt;/p&gt;&lt;/div&gt;</summary>
            public string Language { get; set; }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class WithItem_codenameItemRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public WithItem_codenameItemRequestBuilderGetQueryParameters QueryParameters { get; set; } = new WithItem_codenameItemRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new WithItem_codenameItemRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public WithItem_codenameItemRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
    }
}
