using Kontent.Ai.Delivery.Kiota.Item.Taxonomies.Item;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Kontent.Ai.Delivery.Kiota.Item.Taxonomies {
    /// <summary>Builds and executes requests for operations under \{project_id}\taxonomies</summary>
    public class TaxonomiesRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>Gets an item from the Kontent.Ai.Delivery.Kiota.item.taxonomies.item collection</summary>
        public WithTaxonomy_group_codenameItemRequestBuilder this[string position] { get {
            var urlTplParams = new Dictionary<string, object>(PathParameters);
            urlTplParams.Add("taxonomy_group_codename", position);
            return new WithTaxonomy_group_codenameItemRequestBuilder(urlTplParams, RequestAdapter);
        } }
        /// <summary>
        /// Instantiates a new TaxonomiesRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public TaxonomiesRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/{project_id}/taxonomies{?skip*,limit*}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Instantiates a new TaxonomiesRequestBuilder and sets the default values.
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public TaxonomiesRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) {
            if(string.IsNullOrEmpty(rawUrl)) throw new ArgumentNullException(nameof(rawUrl));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/{project_id}/taxonomies{?skip*,limit*}";
            var urlTplParams = new Dictionary<string, object>();
            urlTplParams.Add("request-raw-url", rawUrl);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Retrieve a paginated list of taxonomy groups in your project. By default, the API returns all taxonomy groups ordered alphabetically by codename. You can customize pagination by specifying both the `skip` and `limit` query parameters.
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<TaxonomiesRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new TaxonomiesRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Retrieve a paginated list of taxonomy groups in your project. By default, the API returns all taxonomy groups ordered alphabetically by codename. You can customize pagination by specifying both the `skip` and `limit` query parameters.
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public async Task<TaxonomiesResponse> GetAsync(Action<TaxonomiesRequestBuilderGetRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreateGetRequestInformation(requestConfiguration);
            return await RequestAdapter.SendAsync<TaxonomiesResponse>(requestInfo, TaxonomiesResponse.CreateFromDiscriminatorValue, default, cancellationToken);
        }
        /// <summary>Retrieve a paginated list of taxonomy groups in your project. By default, the API returns all taxonomy groups ordered alphabetically by codename. You can customize pagination by specifying both the `skip` and `limit` query parameters.</summary>
        public class TaxonomiesRequestBuilderGetQueryParameters {
            /// <summary>Sets the number of objects to retrieve in a single request. If the `limit` parameter is not specified, the API returns all requested objects by default.If `limit` is lower than the total number of objects matching your query, the `next_page` property in the `pagination` object of the API response will contain a URL to the next page of results.The `limit` parameter affects only the number of items in the `items` property. It doesn&apos;t reduce the number of linked items in the `modular_content` property so you may hit the [response size limit](#section/Response-size) unexpectedly. You can set `depth=0` to avoid that.</summary>
            public int? Limit { get; set; }
            /// <summary>Sets the number of objects to skip when requesting a list of objects. The `skip` parameter must be combined with the `limit` parameter to work. If `skip` is not specified, the API returns the first page of results.You can combine the `limit` and `skip` parameters to specify page size and page number. For example, using `limit=10&amp;skip=10` sets the page size to 10 and gets the second page of results.</summary>
            public int? Skip { get; set; }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class TaxonomiesRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public TaxonomiesRequestBuilderGetQueryParameters QueryParameters { get; set; } = new TaxonomiesRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new taxonomiesRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public TaxonomiesRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
    }
}
