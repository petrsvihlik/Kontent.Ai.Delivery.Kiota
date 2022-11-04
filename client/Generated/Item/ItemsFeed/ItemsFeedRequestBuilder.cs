using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Kontent.Ai.Delivery.Kiota.Item.ItemsFeed {
    /// <summary>Builds and executes requests for operations under \{project_id}\items-feed</summary>
    public class ItemsFeedRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Instantiates a new ItemsFeedRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public ItemsFeedRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/{project_id}/items-feed{?language*,elements,order*}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Instantiates a new ItemsFeedRequestBuilder and sets the default values.
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public ItemsFeedRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) {
            if(string.IsNullOrEmpty(rawUrl)) throw new ArgumentNullException(nameof(rawUrl));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/{project_id}/items-feed{?language*,elements,order*}";
            var urlTplParams = new Dictionary<string, object>();
            urlTplParams.Add("request-raw-url", rawUrl);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Retrieve a dynamically paginated list of content items in your project. The items are ordered alphabetically by codename.If the response comes with the `X-Continuation` header, it means that there are more pages to retrieve. To get the next page of results, send the `X-Continuation` header with your request as you received it.This endpoint, unlike the [List content items](/learn/reference/delivery-api/#operation/list-content-items) endpoint, guarantees to enumerate all content items in the specified project. The `modular_content` object property will contain only components used in rich text elements in the API response. See [Linked content and components](/learn/reference/delivery-api/#tag/Linked-content-and-components) for more details.We recommend using this endpoint for warming up your app&apos;s cache (that is getting all content into the cache after the app starts) or for exporting the content of your project.&lt;div class=&quot;callout callout--tip&quot;&gt;&lt;p&gt;&lt;strong&gt;Get only the items you need&lt;/strong&gt;&lt;/p&gt;&lt;p&gt;To retrieve specific content items, use the &lt;a data-item-id=&quot;b6cf1d73-471a-4f1e-b0a9-f0e041e2d905&quot; href=&quot;https://kontent.ai/learn/link-to/filtering_content&quot;&gt;filtering parameters&lt;/a&gt; in your requests. For example, you can request items tagged with a taxonomy term, items of a specific type, or items modified in the past three days.&lt;/p&gt;&lt;/div&gt;
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<ItemsFeedRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new ItemsFeedRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Retrieve a dynamically paginated list of content items in your project. The items are ordered alphabetically by codename.If the response comes with the `X-Continuation` header, it means that there are more pages to retrieve. To get the next page of results, send the `X-Continuation` header with your request as you received it.This endpoint, unlike the [List content items](/learn/reference/delivery-api/#operation/list-content-items) endpoint, guarantees to enumerate all content items in the specified project. The `modular_content` object property will contain only components used in rich text elements in the API response. See [Linked content and components](/learn/reference/delivery-api/#tag/Linked-content-and-components) for more details.We recommend using this endpoint for warming up your app&apos;s cache (that is getting all content into the cache after the app starts) or for exporting the content of your project.&lt;div class=&quot;callout callout--tip&quot;&gt;&lt;p&gt;&lt;strong&gt;Get only the items you need&lt;/strong&gt;&lt;/p&gt;&lt;p&gt;To retrieve specific content items, use the &lt;a data-item-id=&quot;b6cf1d73-471a-4f1e-b0a9-f0e041e2d905&quot; href=&quot;https://kontent.ai/learn/link-to/filtering_content&quot;&gt;filtering parameters&lt;/a&gt; in your requests. For example, you can request items tagged with a taxonomy term, items of a specific type, or items modified in the past three days.&lt;/p&gt;&lt;/div&gt;
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public async Task<ItemsFeedResponse> GetAsync(Action<ItemsFeedRequestBuilderGetRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreateGetRequestInformation(requestConfiguration);
            return await RequestAdapter.SendAsync<ItemsFeedResponse>(requestInfo, ItemsFeedResponse.CreateFromDiscriminatorValue, default, cancellationToken);
        }
        /// <summary>Retrieve a dynamically paginated list of content items in your project. The items are ordered alphabetically by codename.If the response comes with the `X-Continuation` header, it means that there are more pages to retrieve. To get the next page of results, send the `X-Continuation` header with your request as you received it.This endpoint, unlike the [List content items](/learn/reference/delivery-api/#operation/list-content-items) endpoint, guarantees to enumerate all content items in the specified project. The `modular_content` object property will contain only components used in rich text elements in the API response. See [Linked content and components](/learn/reference/delivery-api/#tag/Linked-content-and-components) for more details.We recommend using this endpoint for warming up your app&apos;s cache (that is getting all content into the cache after the app starts) or for exporting the content of your project.&lt;div class=&quot;callout callout--tip&quot;&gt;&lt;p&gt;&lt;strong&gt;Get only the items you need&lt;/strong&gt;&lt;/p&gt;&lt;p&gt;To retrieve specific content items, use the &lt;a data-item-id=&quot;b6cf1d73-471a-4f1e-b0a9-f0e041e2d905&quot; href=&quot;https://kontent.ai/learn/link-to/filtering_content&quot;&gt;filtering parameters&lt;/a&gt; in your requests. For example, you can request items tagged with a taxonomy term, items of a specific type, or items modified in the past three days.&lt;/p&gt;&lt;/div&gt;</summary>
        public class ItemsFeedRequestBuilderGetQueryParameters {
            /// <summary>Determines the elements to retrieve using a comma-separated list of element codenames. The `elements` query parameter applies to all content items within the response.If not specified, all elements are retrieved. For more details, see [Projection](/learn/reference/delivery-api/#tag/Projection).</summary>
            public string[] Elements { get; set; }
            /// <summary>Determines which language variant of content items to return. By default, the API returns content in the default language.&lt;div class=&quot;callout callout--info&quot;&gt;&lt;p&gt;If the requested content is not available in the specified language variant, the API follows the &lt;a data-item-id=&quot;9e0f560c-5ee4-4649-818a-c5f934b82f4a&quot; href=&quot;https://kontent.ai/learn/link-to/set_up_langauges&quot;&gt;language fallbacks&lt;/a&gt; as configured in the &lt;a data-item-id=&quot;9e0f560c-5ee4-4649-818a-c5f934b82f4a&quot; href=&quot;https://kontent.ai/learn/link-to/set_up_langauges&quot;&gt;Localization&lt;/a&gt; settings of your project.&lt;/p&gt;&lt;/div&gt;</summary>
            public string Language { get; set; }
            /// <summary>Determines the order of the retrieved objects. By default, the objects are sorted alphabetically by their codenames from A to Z in descending order.To sort the requested objects in ascending order, set the `order` to `&lt;property_name&gt;[asc]` where `&lt;property_name&gt;` is the name of the object property you want to sort by. For example, `order=elements.title[asc]` or `order=system.codename[asc]`. Similarly, to sort in descending order, use the `[desc]` modifier. You can sort by any properties in the API response.**Examples*** Sort by date – `order=system.last_modified[desc]`* Sort by a content item name – `order=system.name[asc]`* Sort by an element value – `order=elements.&lt;element_codename&gt;[asc]`</summary>
            public string Order { get; set; }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class ItemsFeedRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public ItemsFeedRequestBuilderGetQueryParameters QueryParameters { get; set; } = new ItemsFeedRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new itemsFeedRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public ItemsFeedRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
    }
}
