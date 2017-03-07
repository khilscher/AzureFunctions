# AzureFunctions
Sample Azure Functions
##ClosedLoopFunction
The ClosedLoop function binds to the Event Hub compatible name of an IoT Hub. Each message into the IoT Hub will trigger the function. The sample function reads the JSON message payload, deserializes it, adds the two integer values, and sends the sum back to the device, via IoT Hub, using a C2D message. 

<a href="https://portal.azure.com/#create/Microsoft.Template/uri/https://raw.githubusercontent.com/khilscher/AzureFunctions/master/ClosedLoopFunction/deploy/azuredeploy.json" target="_blank">
    <img src="http://azuredeploy.net/deploybutton.png"/>
</a>
