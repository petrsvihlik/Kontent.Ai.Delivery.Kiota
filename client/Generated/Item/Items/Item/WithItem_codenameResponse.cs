using Kontent.Ai.Delivery.Kiota.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Kontent.Ai.Delivery.Kiota.Item.Items.Item {
    public class WithItem_codenameResponse : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The content item with metadata and individual elements.</summary>
        public ContentItem Item { get; set; }
        /// <summary>The collection of related Content item objects (including component objects).</summary>
        public WithItem_codenameResponse_modular_content Modular_content { get; set; }
        /// <summary>
        /// Instantiates a new WithItem_codenameResponse and sets the default values.
        /// </summary>
        public WithItem_codenameResponse() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static WithItem_codenameResponse CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WithItem_codenameResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"item", n => { Item = n.GetObjectValue<ContentItem>(ContentItem.CreateFromDiscriminatorValue); } },
                {"modular_content", n => { Modular_content = n.GetObjectValue<WithItem_codenameResponse_modular_content>(WithItem_codenameResponse_modular_content.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<ContentItem>("item", Item);
            writer.WriteObjectValue<WithItem_codenameResponse_modular_content>("modular_content", Modular_content);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
