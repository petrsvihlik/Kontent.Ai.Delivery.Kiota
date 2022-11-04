using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Kontent.Ai.Delivery.Kiota.Models {
    /// <summary>A content type object.</summary>
    public class ContentType : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>A list of [elements](/learn/reference/delivery-api/#tag/Content-elements) that define the content type.&lt;div class=&quot;callout callout--info&quot;&gt;&lt;p&gt;&lt;strong&gt;Order may not match the order in UI&lt;/strong&gt;&lt;/p&gt;&lt;p&gt;The order of the elements in the API response might not match their order in the UI.&lt;/p&gt;&lt;/div&gt;</summary>
        public ContentType_elements Elements { get; set; }
        /// <summary>The content type&apos;s system properties.</summary>
        public ContentType_system System { get; set; }
        /// <summary>
        /// Instantiates a new ContentType and sets the default values.
        /// </summary>
        public ContentType() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ContentType CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ContentType();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"elements", n => { Elements = n.GetObjectValue<ContentType_elements>(ContentType_elements.CreateFromDiscriminatorValue); } },
                {"system", n => { System = n.GetObjectValue<ContentType_system>(ContentType_system.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<ContentType_elements>("elements", Elements);
            writer.WriteObjectValue<ContentType_system>("system", System);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
