using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Kontent.Ai.Delivery.Kiota.Models {
    public class DateTimeInType : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The element&apos;s display name.</summary>
        public string Name { get; set; }
        /// <summary>The element&apos;s type.</summary>
        public DateTimeInType_type? Type { get; set; }
        /// <summary>
        /// Instantiates a new DateTimeInType and sets the default values.
        /// </summary>
        public DateTimeInType() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static DateTimeInType CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new DateTimeInType();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"name", n => { Name = n.GetStringValue(); } },
                {"type", n => { Type = n.GetEnumValue<DateTimeInType_type>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("name", Name);
            writer.WriteEnumValue<DateTimeInType_type>("type", Type);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
