using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Kontent.Ai.Delivery.Kiota.Models {
    /// <summary>The content item&apos;s system properties.</summary>
    public class ContentItem_system : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The content item&apos;s codename. By default, generated from the item&apos;s display name.</summary>
        public string Codename { get; set; }
        /// <summary>The content item&apos;s [collection](/learn/tutorials/manage-kontent-ai/projects/set-up-collections/) codename. For projects without collections enabled, the value is `default`.</summary>
        public string Collection { get; set; }
        /// <summary>The content item&apos;s internal ID.</summary>
        public string Id { get; set; }
        /// <summary>The codename of the language that the content is in.For details on retrieving content in different languages, see [Getting localized content](/learn/tutorials/develop-apps/get-content/localized-content-items/).</summary>
        public string Language { get; set; }
        /// <summary>[ISO-8601](https://en.wikipedia.org/wiki/ISO_8601) formatted date and time of the last change to user-content of the content item.&lt;div class=&quot;callout callout--info&quot;&gt;&lt;p&gt;Moving content items through workflow doesn&apos;t affect the &lt;code&gt;last_modified&lt;/code&gt; value.&lt;/p&gt;&lt;/div&gt;</summary>
        public DateTimeOffset? Last_modified { get; set; }
        /// <summary>The content item&apos;s display name.</summary>
        public string Name { get; set; }
        /// <summary>A list of sitemap locations that the content item is in.</summary>
        public List<string> Sitemap_locations { get; set; }
        /// <summary>The codename of the item&apos;s type.</summary>
        public string Type { get; set; }
        /// <summary>The codename of the item&apos;s current workflow step. By default, generated from the workflow step&apos;s display name.This property is not present for [components](/learn/reference/delivery-api/#tag/Linked-content-and-components).</summary>
        public string Workflow_step { get; set; }
        /// <summary>
        /// Instantiates a new ContentItem_system and sets the default values.
        /// </summary>
        public ContentItem_system() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ContentItem_system CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ContentItem_system();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"codename", n => { Codename = n.GetStringValue(); } },
                {"collection", n => { Collection = n.GetStringValue(); } },
                {"id", n => { Id = n.GetStringValue(); } },
                {"language", n => { Language = n.GetStringValue(); } },
                {"last_modified", n => { Last_modified = n.GetDateTimeOffsetValue(); } },
                {"name", n => { Name = n.GetStringValue(); } },
                {"sitemap_locations", n => { Sitemap_locations = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"type", n => { Type = n.GetStringValue(); } },
                {"workflow_step", n => { Workflow_step = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("codename", Codename);
            writer.WriteStringValue("collection", Collection);
            writer.WriteStringValue("id", Id);
            writer.WriteStringValue("language", Language);
            writer.WriteDateTimeOffsetValue("last_modified", Last_modified);
            writer.WriteStringValue("name", Name);
            writer.WriteCollectionOfPrimitiveValues<string>("sitemap_locations", Sitemap_locations);
            writer.WriteStringValue("type", Type);
            writer.WriteStringValue("workflow_step", Workflow_step);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
