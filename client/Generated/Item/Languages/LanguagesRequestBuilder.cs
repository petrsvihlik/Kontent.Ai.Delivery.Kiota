using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Kontent.Ai.Delivery.Kiota.Item.Languages {
    /// <summary>Builds and executes requests for operations under \{project_id}\languages</summary>
    public class LanguagesRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Instantiates a new LanguagesRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public LanguagesRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/{project_id}/languages{?skip*,limit*,order*}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Instantiates a new LanguagesRequestBuilder and sets the default values.
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public LanguagesRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) {
            if(string.IsNullOrEmpty(rawUrl)) throw new ArgumentNullException(nameof(rawUrl));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/{project_id}/languages{?skip*,limit*,order*}";
            var urlTplParams = new Dictionary<string, object>();
            urlTplParams.Add("request-raw-url", rawUrl);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Retrieve a list of active languages from your project. By default, the API returns all languages ordered alphabetically by codename.&lt;div class=&quot;callout callout--tip&quot;&gt;&lt;p&gt;&lt;strong&gt;Get only the languages you need&lt;/strong&gt;&lt;/p&gt;&lt;p&gt;To retrieve specific languages, use the &lt;a data-item-id=&quot;b6cf1d73-471a-4f1e-b0a9-f0e041e2d905&quot; href=&quot;https://kontent.ai/learn/link-to/filtering_content&quot;&gt;filtering parameters&lt;/a&gt; in your requests. For example, you can request two specific languages (using the &lt;code&gt;[in]&lt;/code&gt; filter) or all but one language (using the &lt;code&gt;[neq]&lt;/code&gt; filter).&lt;/p&gt;&lt;/div&gt;
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<LanguagesRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new LanguagesRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Retrieve a list of active languages from your project. By default, the API returns all languages ordered alphabetically by codename.&lt;div class=&quot;callout callout--tip&quot;&gt;&lt;p&gt;&lt;strong&gt;Get only the languages you need&lt;/strong&gt;&lt;/p&gt;&lt;p&gt;To retrieve specific languages, use the &lt;a data-item-id=&quot;b6cf1d73-471a-4f1e-b0a9-f0e041e2d905&quot; href=&quot;https://kontent.ai/learn/link-to/filtering_content&quot;&gt;filtering parameters&lt;/a&gt; in your requests. For example, you can request two specific languages (using the &lt;code&gt;[in]&lt;/code&gt; filter) or all but one language (using the &lt;code&gt;[neq]&lt;/code&gt; filter).&lt;/p&gt;&lt;/div&gt;
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public async Task<LanguagesResponse> GetAsync(Action<LanguagesRequestBuilderGetRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreateGetRequestInformation(requestConfiguration);
            return await RequestAdapter.SendAsync<LanguagesResponse>(requestInfo, LanguagesResponse.CreateFromDiscriminatorValue, default, cancellationToken);
        }
        /// <summary>Retrieve a list of active languages from your project. By default, the API returns all languages ordered alphabetically by codename.&lt;div class=&quot;callout callout--tip&quot;&gt;&lt;p&gt;&lt;strong&gt;Get only the languages you need&lt;/strong&gt;&lt;/p&gt;&lt;p&gt;To retrieve specific languages, use the &lt;a data-item-id=&quot;b6cf1d73-471a-4f1e-b0a9-f0e041e2d905&quot; href=&quot;https://kontent.ai/learn/link-to/filtering_content&quot;&gt;filtering parameters&lt;/a&gt; in your requests. For example, you can request two specific languages (using the &lt;code&gt;[in]&lt;/code&gt; filter) or all but one language (using the &lt;code&gt;[neq]&lt;/code&gt; filter).&lt;/p&gt;&lt;/div&gt;</summary>
        public class LanguagesRequestBuilderGetQueryParameters {
            /// <summary>Sets the number of objects to retrieve in a single request. If the `limit` parameter is not specified, the API returns all requested objects by default.If `limit` is lower than the total number of objects matching your query, the `next_page` property in the `pagination` object of the API response will contain a URL to the next page of results.The `limit` parameter affects only the number of items in the `items` property. It doesn&apos;t reduce the number of linked items in the `modular_content` property so you may hit the [response size limit](#section/Response-size) unexpectedly. You can set `depth=0` to avoid that.</summary>
            public int? Limit { get; set; }
            /// <summary>Determines the order of the retrieved objects. By default, the objects are sorted alphabetically by their codenames from A to Z in descending order.To sort the requested objects in ascending order, set the `order` to `&lt;property_name&gt;[asc]` where `&lt;property_name&gt;` is the name of the object property you want to sort by. For example, `order=elements.title[asc]` or `order=system.codename[asc]`. Similarly, to sort in descending order, use the `[desc]` modifier. You can sort by any properties in the API response.**Examples*** Sort by date – `order=system.last_modified[desc]`* Sort by a content item name – `order=system.name[asc]`* Sort by an element value – `order=elements.&lt;element_codename&gt;[asc]`</summary>
            public string Order { get; set; }
            /// <summary>Sets the number of objects to skip when requesting a list of objects. The `skip` parameter must be combined with the `limit` parameter to work. If `skip` is not specified, the API returns the first page of results.You can combine the `limit` and `skip` parameters to specify page size and page number. For example, using `limit=10&amp;skip=10` sets the page size to 10 and gets the second page of results.</summary>
            public int? Skip { get; set; }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class LanguagesRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public LanguagesRequestBuilderGetQueryParameters QueryParameters { get; set; } = new LanguagesRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new languagesRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public LanguagesRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
    }
}
