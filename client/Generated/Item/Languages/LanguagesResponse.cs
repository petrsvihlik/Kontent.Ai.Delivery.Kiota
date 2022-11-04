using Kontent.Ai.Delivery.Kiota.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Kontent.Ai.Delivery.Kiota.Item.Languages {
    public class LanguagesResponse : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Active languages available in the project.</summary>
        public List<Language> Languages { get; set; }
        /// <summary>Information about the current page of results.</summary>
        public Kontent.Ai.Delivery.Kiota.Models.Pagination Pagination { get; set; }
        /// <summary>
        /// Instantiates a new languagesResponse and sets the default values.
        /// </summary>
        public LanguagesResponse() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static LanguagesResponse CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new LanguagesResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"languages", n => { Languages = n.GetCollectionOfObjectValues<Language>(Language.CreateFromDiscriminatorValue)?.ToList(); } },
                {"pagination", n => { Pagination = n.GetObjectValue<Kontent.Ai.Delivery.Kiota.Models.Pagination>(Kontent.Ai.Delivery.Kiota.Models.Pagination.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<Language>("languages", Languages);
            writer.WriteObjectValue<Kontent.Ai.Delivery.Kiota.Models.Pagination>("pagination", Pagination);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
