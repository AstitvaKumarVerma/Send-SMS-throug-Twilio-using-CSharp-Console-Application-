// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio_SMS_Normal_Code;



string accountSid = "ACf0b59a3388c408a48c46050a2f505ccb";
string authToken = "ff5ea15032030131c5d0eeef1021eef4";


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
        from: new Twilio.Types.PhoneNumber("+16562231054"),
        to: new Twilio.Types.PhoneNumber("+919520359532"));

    Console.WriteLine(message.Status);
}
