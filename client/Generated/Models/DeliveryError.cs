using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Kontent.Ai.Delivery.Kiota.Models {
    /// <summary>Error response</summary>
    public class DeliveryError : ApiException, IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The internal error code for the type of error. Used for finding patterns among error requests.</summary>
        public int? Error_code { get; set; }
        /// <summary>The error message explaining what caused the error.</summary>
        public string Message { get; set; }
        /// <summary>The performed request&apos;s unique ID.</summary>
        public string Request_id { get; set; }
        /// <summary>Only useful for finding reasons behind failed requests in specific cases.</summary>
        public int? Specific_code { get; set; }
        /// <summary>
        /// Instantiates a new DeliveryError and sets the default values.
        /// </summary>
        public DeliveryError() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static DeliveryError CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new DeliveryError();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"error_code", n => { Error_code = n.GetIntValue(); } },
                {"message", n => { Message = n.GetStringValue(); } },
                {"request_id", n => { Request_id = n.GetStringValue(); } },
                {"specific_code", n => { Specific_code = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("error_code", Error_code);
            writer.WriteStringValue("message", Message);
            writer.WriteStringValue("request_id", Request_id);
            writer.WriteIntValue("specific_code", Specific_code);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
