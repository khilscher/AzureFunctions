using System;
using Microsoft.Azure.Devices;
using System.Text;

private const string iotHubConnString = GetEnvironmentVariable("IOT_HUB_CONNECTION_STRING");
static ServiceClient serviceClient;

public static async Task<string> Run(string myIoTHubMessage, TraceWriter log)
{
    log.Info($"C# Event Hub trigger function processed a message: {myIoTHubMessage}");

    serviceClient = serviceClient ?? ServiceClient.CreateFromConnectionString(iotHubConnString);

    DeviceData deviceData = new DeviceData();

    deviceData= Newtonsoft.Json.JsonConvert.DeserializeObject<DeviceData>(myIoTHubMessage);

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

public static string GetEnvironmentVariable(string name)
{
    return name + ": " + 
        System.Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
}
