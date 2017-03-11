# AzureFunctions
Sample Azure Functions
##ClosedLoopFunction
The ClosedLoop function binds to the Event Hub compatible name of an IoT Hub. Each message into the IoT Hub will trigger the function. The sample function reads the JSON message payload, deserializes it, adds the two integer values (DataPoint1 and DataPoint2), and sends the sum back to the device, via IoT Hub, using a C2D message. 

The device should send the following payload to IoT Hub:
```
private class DeviceData
{
    public string DeviceId { get; set; }
    public int DataPoint1 { get; set; }
    public int DataPoint2 { get; set; }
}
```

You will be prompted for the following settings:
- App Name - The name of your function. 
- Event Hub Compatible Name - Find this under IoT Hub -> Endpoints -> Events
- IoT Hub Conn String - Find this under IoT Hub -> Shared access policies. The policy needs at least ```Service connect``` permission, such as ```iothubowner```.
- Event Hub Endpoint - Find this under IoT Hub -> Endpoints -> Events. It will look like ```sb://iothub-ns-temphubkh1-126055-c0205f05d8.servicebus.windows.net/```. Now reformat this as follows:
  - Prepend ```Endpoint=``` and append the same ```SharedAccessKeyName``` and ```SharedAccessKey``` from the IoT Hub Conn String. 
  - The final product should look something like ```Endpoint=sb://somename.servicebus.windows.net/;SharedAccessKeyName=iothubowner;SharedAccessKey=1H8jjTSVaZOU2OlGYQovfp2C0Keudb5rmZFxJEZyyFp=```

<a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fkhilscher%2FAzureFunctions%2Fmaster%2FClosedLoopFunction%2Fdeploy%2Fazuredeploy.json" target="_blank">
    <img src="http://azuredeploy.net/deploybutton.png"/>
</a>
