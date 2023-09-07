// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio_SMS_Normal_Code;



string accountSid = "YOUR_TWILIO_AccountSID";   //replace it with your Actual Twilio AccountSID
string authToken = "YOUR_TWILIO_AuthToken";   //replace it with your Actual Twilio AuthToken


Console.WriteLine("--------------------------------------------------------");
// Verify that your credentials are set correctly
Console.WriteLine($"||   Account SID: {accountSid}  ||");

Console.WriteLine($"||   Auth Token: {authToken}     ||");
Console.WriteLine("--------------------------------------------------------");

// Read the JSON config string
var twilioConfigString = File.ReadAllText("twilioConfig.json");

// Deserialize the JSON string
using (var reader = new StringReader(twilioConfigString))
{
    var serializer = new JsonSerializer();
    var twilioConfig = serializer.Deserialize<TwilioConfig>(new JsonTextReader(reader));

    TwilioClient.Init(accountSid, authToken);

    var message = MessageResource.Create(
        body: "Hii, Astitva This Side From Twilio",
        from: new Twilio.Types.PhoneNumber("YOUR_TWILIO_PHONE_NUMBER"),     //replace it("YOUR_TWILIO_PHONE_NUMBER") with your actual Twilio Phone Number
        to: new Twilio.Types.PhoneNumber("+9195xxxxxxxx"));     

    Console.WriteLine(message.Status);
}
