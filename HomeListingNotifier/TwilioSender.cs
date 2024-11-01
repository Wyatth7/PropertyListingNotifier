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
    
    public static async Task<bool> Send(string message)
    {
        try
        {
            TwilioClient.Init(AccountSid, AuthToken);

            var options = new CreateMessageOptions(new PhoneNumber(ToNumber))
            {
                From = new PhoneNumber(HostNumber),
                Body = message
            };

            var response = await MessageResource.CreateAsync(options);

            if (response.ErrorMessage is null) return true;
            
            Console.WriteLine($"Twilio responded with an error while sending an SMS message. " +
                              $"Code: {response.ErrorCode}, Error: {response.ErrorMessage}");

            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}