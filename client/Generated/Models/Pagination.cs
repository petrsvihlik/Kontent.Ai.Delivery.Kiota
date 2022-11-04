using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Kontent.Ai.Delivery.Kiota.Models {
    /// <summary>Information about the current page of results.</summary>
    public class Pagination : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The number of retrieved objects.If the `limit` and `skip` query parameters are not specified, the `count` property reflects the total number of objects in the project.</summary>
        public int? Count { get; set; }
        /// <summary>The number of objects returned in the response. Reflects the value specified by the `limit` query parameter.</summary>
        public int? Limit { get; set; }
        /// <summary>A URL to the next page of results.</summary>
        public string Next_page { get; set; }
        /// <summary>The number of objects skipped from the response. Reflects the value specified by the `skip` query parameter.</summary>
        public int? Skip { get; set; }
        /// <summary>The total number of objects matching the query.The property is present only when [listing content items](/learn/reference/delivery-api/#operation/list-content-items) and using the `includeTotalCount` query parameter.</summary>
        public int? Total_count { get; set; }
        /// <summary>
        /// Instantiates a new Pagination and sets the default values.
        /// </summary>
        public Pagination() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static Pagination CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Pagination();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"count", n => { Count = n.GetIntValue(); } },
                {"limit", n => { Limit = n.GetIntValue(); } },
                {"next_page", n => { Next_page = n.GetStringValue(); } },
                {"skip", n => { Skip = n.GetIntValue(); } },
                {"total_count", n => { Total_count = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("count", Count);
            writer.WriteIntValue("limit", Limit);
            writer.WriteStringValue("next_page", Next_page);
            writer.WriteIntValue("skip", Skip);
            writer.WriteIntValue("total_count", Total_count);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
