using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Kontent.Ai.Delivery.Kiota.Models {
    /// <summary>The content item with metadata and individual elements.</summary>
    public class ContentItem : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The item&apos;s [elements](/learn/reference/delivery-api/#tag/Content-elements) with values for the specific language.&lt;div class=&quot;callout callout--info&quot;&gt;&lt;p&gt;The order of the element objects might not match the content element order in the UI.&lt;/p&gt;&lt;/div&gt;</summary>
        public ContentItem_elements Elements { get; set; }
        /// <summary>The content item&apos;s system properties.</summary>
        public ContentItem_system System { get; set; }
        /// <summary>
        /// Instantiates a new ContentItem and sets the default values.
        /// </summary>
        public ContentItem() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ContentItem CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ContentItem();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"elements", n => { Elements = n.GetObjectValue<ContentItem_elements>(ContentItem_elements.CreateFromDiscriminatorValue); } },
                {"system", n => { System = n.GetObjectValue<ContentItem_system>(ContentItem_system.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<ContentItem_elements>("elements", Elements);
            writer.WriteObjectValue<ContentItem_system>("system", System);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
