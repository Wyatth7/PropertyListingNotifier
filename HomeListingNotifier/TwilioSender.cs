using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace HomeListingNotifier;

public class TwilioSender
{
    private const string AccountSid = "";
    private const string AuthToken = "";
    private const string HostNumber = "";
    private const string ToNumber = "";
    
    public async Task Send(string message)
    {
        TwilioClient.Init(AccountSid, AuthToken);

        var options = new CreateMessageOptions(new PhoneNumber(ToNumber))
        {
            From = new PhoneNumber(HostNumber),
            Body = message
        };

        var response = await MessageResource.CreateAsync(options);
        Console.WriteLine(response.Body);
    }
}