using Kontent.Ai.Delivery.Kiota;
using Microsoft.Kiota.Http.HttpClientLibrary;

DeliveryClient deliveryApiClient = new DeliveryClient(new HttpClientRequestAdapter(new KontentAuthProvider()));

var item = await deliveryApiClient["4d0fc084-2515-01c7-1a39-53146da3d8a8"].Items["author"].GetAsync();

foreach (var element in item.Item.Elements.AdditionalData)
{
    Console.WriteLine(element.Key);
    Console.WriteLine(element.Value);
}