using Kontent.Ai.Delivery.Kiota.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Kontent.Ai.Delivery.Kiota.Item.Items {
    public class ItemsResponse : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>A list of content items.</summary>
        public List<ContentItem> Items { get; set; }
        /// <summary>A dictionary of [components and linked items](/learn/reference/delivery-api/#tag/Linked-content-and-components).**Note**: The items and components are not in any particular order.</summary>
        public ItemsResponse_modular_content Modular_content { get; set; }
        /// <summary>Information about the current page of results.</summary>
        public Kontent.Ai.Delivery.Kiota.Models.Pagination Pagination { get; set; }
        /// <summary>
        /// Instantiates a new itemsResponse and sets the default values.
        /// </summary>
        public ItemsResponse() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ItemsResponse CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ItemsResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"items", n => { Items = n.GetCollectionOfObjectValues<ContentItem>(ContentItem.CreateFromDiscriminatorValue)?.ToList(); } },
                {"modular_content", n => { Modular_content = n.GetObjectValue<ItemsResponse_modular_content>(ItemsResponse_modular_content.CreateFromDiscriminatorValue); } },
                {"pagination", n => { Pagination = n.GetObjectValue<Kontent.Ai.Delivery.Kiota.Models.Pagination>(Kontent.Ai.Delivery.Kiota.Models.Pagination.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<ContentItem>("items", Items);
            writer.WriteObjectValue<ItemsResponse_modular_content>("modular_content", Modular_content);
            writer.WriteObjectValue<Kontent.Ai.Delivery.Kiota.Models.Pagination>("pagination", Pagination);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
