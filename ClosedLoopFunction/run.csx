using System;
using Microsoft.Azure.Devices;
using System.Text;

static ServiceClient serviceClient;

//Add IoT Hub Connection String
private const string IOT_HUB_CONNECTION_STRING = "";

public static async Task<string> Run(string myEventHubMessage, TraceWriter log)
{
    log.Info($"C# Event Hub trigger function processed a message: {myEventHubMessage}");

    serviceClient = serviceClient ?? ServiceClient.CreateFromConnectionString(IOT_HUB_CONNECTION_STRING);

    DeviceData deviceData = new DeviceData();

    deviceData= Newtonsoft.Json.JsonConvert.DeserializeObject<DeviceData>(myEventHubMessage);

    int sumtotal = deviceData.DataPoint1 + deviceData.DataPoint2;

    var responseMessage = new Message(Encoding.ASCII.GetBytes(sumtotal.ToString()));

    await serviceClient.SendAsync(deviceData.DeviceId, responseMessage);

    return null;
}


private class DeviceData
{
    public string DeviceId {get; set;}
    public int DataPoint1 {get; set;}
    public int DataPoint2 {get; set;}
}
