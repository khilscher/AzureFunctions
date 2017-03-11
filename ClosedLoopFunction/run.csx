using System;
using Microsoft.Azure.Devices;
using System.Text;

static ServiceClient serviceClient;
static string iotHubConnString = GetEnvironmentVariable("IOT_HUB_CONNECTION_STRING");

public static async Task<string> Run(string myEventHubMessage, TraceWriter log)
{
    log.Info($"C# Event Hub trigger function processed a message: {myEventHubMessage}");
    
    serviceClient = serviceClient ?? ServiceClient.CreateFromConnectionString(iotHubConnString);

    DeviceData deviceData = new DeviceData();

    deviceData = Newtonsoft.Json.JsonConvert.DeserializeObject<DeviceData>(myEventHubMessage);
    
    log.Info("Message details...");
    log.Info($"DeviceId: {deviceData.DeviceId}");
    log.Info($"DataPoint1: {deviceData.DataPoint1}");
    log.Info($"DataPoint2: {deviceData.DataPoint2}");

    int sumtotal = deviceData.DataPoint1 + deviceData.DataPoint2;

    var responseMessage = new Message(Encoding.ASCII.GetBytes(sumtotal.ToString()));

    await serviceClient.SendAsync(deviceData.DeviceId, responseMessage);
    
    log.Info($"Response message sent to: {deviceData.DeviceId}");

    return null;
}


private class DeviceData
{
    public string DeviceId {get; set;}
    public int DataPoint1 {get; set;}
    public int DataPoint2 {get; set;}
}

public static string GetEnvironmentVariable(string name)
{
    return name + ": " + 
        System.Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
}
