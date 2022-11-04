using Kontent.Ai.Delivery.Kiota.Item.Items.Item;
using Kontent.Ai.Delivery.Kiota.Models;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Kontent.Ai.Delivery.Kiota.Item.Items {
    /// <summary>Builds and executes requests for operations under \{project_id}\items</summary>
    public class ItemsRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>Gets an item from the Kontent.Ai.Delivery.Kiota.item.items.item collection</summary>
        public WithItem_codenameItemRequestBuilder this[string position] { get {
            var urlTplParams = new Dictionary<string, object>(PathParameters);
            urlTplParams.Add("item_codename", position);
            return new WithItem_codenameItemRequestBuilder(urlTplParams, RequestAdapter);
        } }
        /// <summary>
        /// Instantiates a new ItemsRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public ItemsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/{project_id}/items{?language*,elements,order*,depth*,skip*,limit*,includeTotalCount*}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Instantiates a new ItemsRequestBuilder and sets the default values.
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public ItemsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) {
            if(string.IsNullOrEmpty(rawUrl)) throw new ArgumentNullException(nameof(rawUrl));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/{project_id}/items{?language*,elements,order*,depth*,skip*,limit*,includeTotalCount*}";
            var urlTplParams = new Dictionary<string, object>();
            urlTplParams.Add("request-raw-url", rawUrl);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Retrieve a list of content items from your project. By default, the API returns an unfiltered paginated list of content items ordered alphabetically by codename. The [response size](#section/Response-size) is limited to 2000 items.The `modular_content` object property will contain both components and linked items in the API response. See [Linked content and components](/learn/reference/delivery-api/#tag/Linked-content-and-components) for more details.If you need to export all content items from your project, we recommend using the [Enumerate content items](/learn/reference/delivery-api/#operation/enumerate-content-items) endpoint.You can change the order by specifying the `order` query parameter. You can customize pagination by specifying both the `skip` and `limit` query parameters. Note that the `limit` parameter affects only the `items` property, not `modular_content`.&lt;div class=&quot;callout callout--tip&quot;&gt;&lt;p&gt;&lt;strong&gt;Get only the items you need&lt;/strong&gt;&lt;/p&gt;&lt;p&gt;To retrieve specific content items, use the &lt;a data-item-id=&quot;b6cf1d73-471a-4f1e-b0a9-f0e041e2d905&quot; href=&quot;https://kontent.ai/learn/link-to/filtering_content&quot;&gt;filtering parameters&lt;/a&gt; in your requests. For example, you can request items tagged with a taxonomy term, items of a specific type, or items modified in the past three days.&lt;/p&gt;&lt;/div&gt;
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<ItemsRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new ItemsRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Retrieve a list of content items from your project. By default, the API returns an unfiltered paginated list of content items ordered alphabetically by codename. The [response size](#section/Response-size) is limited to 2000 items.The `modular_content` object property will contain both components and linked items in the API response. See [Linked content and components](/learn/reference/delivery-api/#tag/Linked-content-and-components) for more details.If you need to export all content items from your project, we recommend using the [Enumerate content items](/learn/reference/delivery-api/#operation/enumerate-content-items) endpoint.You can change the order by specifying the `order` query parameter. You can customize pagination by specifying both the `skip` and `limit` query parameters. Note that the `limit` parameter affects only the `items` property, not `modular_content`.&lt;div class=&quot;callout callout--tip&quot;&gt;&lt;p&gt;&lt;strong&gt;Get only the items you need&lt;/strong&gt;&lt;/p&gt;&lt;p&gt;To retrieve specific content items, use the &lt;a data-item-id=&quot;b6cf1d73-471a-4f1e-b0a9-f0e041e2d905&quot; href=&quot;https://kontent.ai/learn/link-to/filtering_content&quot;&gt;filtering parameters&lt;/a&gt; in your requests. For example, you can request items tagged with a taxonomy term, items of a specific type, or items modified in the past three days.&lt;/p&gt;&lt;/div&gt;
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public async Task<ItemsResponse> GetAsync(Action<ItemsRequestBuilderGetRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreateGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"400", DeliveryError.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<ItemsResponse>(requestInfo, ItemsResponse.CreateFromDiscriminatorValue, errorMapping, cancellationToken);
        }
        /// <summary>Retrieve a list of content items from your project. By default, the API returns an unfiltered paginated list of content items ordered alphabetically by codename. The [response size](#section/Response-size) is limited to 2000 items.The `modular_content` object property will contain both components and linked items in the API response. See [Linked content and components](/learn/reference/delivery-api/#tag/Linked-content-and-components) for more details.If you need to export all content items from your project, we recommend using the [Enumerate content items](/learn/reference/delivery-api/#operation/enumerate-content-items) endpoint.You can change the order by specifying the `order` query parameter. You can customize pagination by specifying both the `skip` and `limit` query parameters. Note that the `limit` parameter affects only the `items` property, not `modular_content`.&lt;div class=&quot;callout callout--tip&quot;&gt;&lt;p&gt;&lt;strong&gt;Get only the items you need&lt;/strong&gt;&lt;/p&gt;&lt;p&gt;To retrieve specific content items, use the &lt;a data-item-id=&quot;b6cf1d73-471a-4f1e-b0a9-f0e041e2d905&quot; href=&quot;https://kontent.ai/learn/link-to/filtering_content&quot;&gt;filtering parameters&lt;/a&gt; in your requests. For example, you can request items tagged with a taxonomy term, items of a specific type, or items modified in the past three days.&lt;/p&gt;&lt;/div&gt;</summary>
        public class ItemsRequestBuilderGetQueryParameters {
            /// <summary>Determines the level of nesting for content items that the API returns. By default, only the first level of linked items is returned, which is the same as setting `depth=1`.If you want to include more than one level of linked items in response, set the `depth` query parameter to `2` or more.If you need to exclude all linked items from the response, set the parameter to `0`.&lt;div class=&quot;callout callout--info&quot;&gt;&lt;p&gt;Components are always present in response. See &lt;a data-item-id=&quot;286dbb0e-f673-494f-abfd-3f39c7ec3446&quot; href=&quot;https://kontent.ai/learn/link-to/linked_content_and_components&quot;&gt;Linked content and components&lt;/a&gt; for more details.&lt;/p&gt;&lt;/div&gt;</summary>
            public int? Depth { get; set; }
            /// <summary>Determines the elements to retrieve using a comma-separated list of element codenames. The `elements` query parameter applies to all content items within the response.If not specified, all elements are retrieved. For more details, see [Projection](/learn/reference/delivery-api/#tag/Projection).</summary>
            public string[] Elements { get; set; }
            /// <summary>Adds the information about the total number of content items matching your query. Only [the content filtering parameters](/learn/reference/delivery-api/#tag/Filtering-content) affect the resulting number. Other parameters in your query, such as `limit,` `skip`, or `order`, don&apos;t have an effect on it.The number doesn&apos;t include linked items returned as part of the `modular_content` property. For the total number of items returned within the response, see the `X-Request-Charge` header.When set to `true`, the pagination object returned in the API response contains an additional `total_count` property.</summary>
            public bool? IncludeTotalCount { get; set; }
            /// <summary>Determines which language variant of content items to return. By default, the API returns content in the default language.&lt;div class=&quot;callout callout--info&quot;&gt;&lt;p&gt;If the requested content is not available in the specified language variant, the API follows the &lt;a data-item-id=&quot;9e0f560c-5ee4-4649-818a-c5f934b82f4a&quot; href=&quot;https://kontent.ai/learn/link-to/set_up_langauges&quot;&gt;language fallbacks&lt;/a&gt; as configured in the &lt;a data-item-id=&quot;9e0f560c-5ee4-4649-818a-c5f934b82f4a&quot; href=&quot;https://kontent.ai/learn/link-to/set_up_langauges&quot;&gt;Localization&lt;/a&gt; settings of your project.&lt;/p&gt;&lt;/div&gt;</summary>
            public string Language { get; set; }
            /// <summary>Sets the number of objects to retrieve in a single request. If the `limit` parameter is not specified, the API returns all requested objects by default.If `limit` is lower than the total number of objects matching your query, the `next_page` property in the `pagination` object of the API response will contain a URL to the next page of results.The `limit` parameter affects only the number of items in the `items` property. It doesn&apos;t reduce the number of linked items in the `modular_content` property so you may hit the [response size limit](#section/Response-size) unexpectedly. You can set `depth=0` to avoid that.</summary>
            public int? Limit { get; set; }
            /// <summary>Determines the order of the retrieved objects. By default, the objects are sorted alphabetically by their codenames from A to Z in descending order.To sort the requested objects in ascending order, set the `order` to `&lt;property_name&gt;[asc]` where `&lt;property_name&gt;` is the name of the object property you want to sort by. For example, `order=elements.title[asc]` or `order=system.codename[asc]`. Similarly, to sort in descending order, use the `[desc]` modifier. You can sort by any properties in the API response.**Examples*** Sort by date – `order=system.last_modified[desc]`* Sort by a content item name – `order=system.name[asc]`* Sort by an element value – `order=elements.&lt;element_codename&gt;[asc]`</summary>
            public string Order { get; set; }
            /// <summary>Sets the number of objects to skip when requesting a list of objects. The `skip` parameter must be combined with the `limit` parameter to work. If `skip` is not specified, the API returns the first page of results.You can combine the `limit` and `skip` parameters to specify page size and page number. For example, using `limit=10&amp;skip=10` sets the page size to 10 and gets the second page of results.</summary>
            public int? Skip { get; set; }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class ItemsRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public ItemsRequestBuilderGetQueryParameters QueryParameters { get; set; } = new ItemsRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new itemsRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public ItemsRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
    }
}
