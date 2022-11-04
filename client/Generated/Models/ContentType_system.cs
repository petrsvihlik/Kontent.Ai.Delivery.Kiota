using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Kontent.Ai.Delivery.Kiota.Models {
    /// <summary>The content type&apos;s system properties.</summary>
    public class ContentType_system : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Codename of the content type, generated from the content types&apos;s `name`.</summary>
        public string Codename { get; set; }
        /// <summary>Unique internal identifier of the content type.</summary>
        public string Id { get; set; }
        /// <summary>[ISO-8601](https://en.wikipedia.org/wiki/ISO_8601 &quot;International standard covering the exchange of date- and time-related data&quot;) formatted date-time of the last content type change.</summary>
        public DateTimeOffset? Last_modified { get; set; }
        /// <summary>Display name of the content type.</summary>
        public string Name { get; set; }
        /// <summary>
        /// Instantiates a new ContentType_system and sets the default values.
        /// </summary>
        public ContentType_system() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ContentType_system CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ContentType_system();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"codename", n => { Codename = n.GetStringValue(); } },
                {"id", n => { Id = n.GetStringValue(); } },
                {"last_modified", n => { Last_modified = n.GetDateTimeOffsetValue(); } },
                {"name", n => { Name = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("codename", Codename);
            writer.WriteStringValue("id", Id);
            writer.WriteDateTimeOffsetValue("last_modified", Last_modified);
            writer.WriteStringValue("name", Name);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
