using Kontent.Ai.Delivery.Kiota.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Kontent.Ai.Delivery.Kiota.Item.ItemsFeed {
    public class ItemsFeedResponse : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>A list of content items</summary>
        public List<ContentItem> Items { get; set; }
        /// <summary>A list of components used in rich text elements. See [Linked content and components](/learn/reference/delivery-api/#tag/Linked-content-and-components) for more details.</summary>
        public ItemsFeedResponse_modular_content Modular_content { get; set; }
        /// <summary>
        /// Instantiates a new itemsFeedResponse and sets the default values.
        /// </summary>
        public ItemsFeedResponse() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ItemsFeedResponse CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ItemsFeedResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"items", n => { Items = n.GetCollectionOfObjectValues<ContentItem>(ContentItem.CreateFromDiscriminatorValue)?.ToList(); } },
                {"modular_content", n => { Modular_content = n.GetObjectValue<ItemsFeedResponse_modular_content>(ItemsFeedResponse_modular_content.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<ContentItem>("items", Items);
            writer.WriteObjectValue<ItemsFeedResponse_modular_content>("modular_content", Modular_content);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
