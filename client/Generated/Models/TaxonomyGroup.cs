using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Kontent.Ai.Delivery.Kiota.Models {
    public class TaxonomyGroup : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The taxonomy group&apos;s system properties.</summary>
        public TaxonomyGroup_system System { get; set; }
        /// <summary>A list of taxonomy terms.</summary>
        public List<TaxonomyTerm> Terms { get; set; }
        /// <summary>
        /// Instantiates a new TaxonomyGroup and sets the default values.
        /// </summary>
        public TaxonomyGroup() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static TaxonomyGroup CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new TaxonomyGroup();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"system", n => { System = n.GetObjectValue<TaxonomyGroup_system>(TaxonomyGroup_system.CreateFromDiscriminatorValue); } },
                {"terms", n => { Terms = n.GetCollectionOfObjectValues<TaxonomyTerm>(TaxonomyTerm.CreateFromDiscriminatorValue)?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<TaxonomyGroup_system>("system", System);
            writer.WriteCollectionOfObjectValues<TaxonomyTerm>("terms", Terms);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
