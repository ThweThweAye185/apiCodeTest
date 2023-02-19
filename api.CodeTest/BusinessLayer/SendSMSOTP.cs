using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.CodeTest.DAL;
using api.CodeTest.ViewModel;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace api.CodeTest.BusinessLayer
{
    #region Interface
    public interface ISendSMSOTP
    {
        string SendSmsOTP(OTPRequestModel model);
    }

    #endregion

    public class SendSMSOTP : ISendSMSOTP
    {
        #region Variable 
        private readonly AmazonSimpleNotificationServiceClient snsClient;
        #endregion

        #region Constructor
        public SendSMSOTP(ApplicationDbContext contex)
        {

        }

        #endregion

        public string SendSmsOTP(OTPRequestModel model)
        {

            string otp = this.GenerateOTP();
            var phoneNumber = model.MobileCode + model.Mobile;
            // Send OPT to user
            var isSuccess = this.SendUserOTP(model.MobileCode, model.Mobile, otp);
            if(isSuccess)
            {
                return "Send OTP Successful";
            }
            else
            {
                return "Send OTP Fail";
            }
        }

        public string GenerateOTP()
        {
            string otp = string.Empty;
            Random generator = new Random();
            int randomNo = generator.Next(1, 1000000);
            otp = randomNo.ToString().PadLeft(6, '0');
            return otp;

        }

        public bool SendUserOTP(int? code, string number, string otp)
        {
            var message = "This otp is from My Code Test" + otp;
            return SendOTPAsync(code, number, message).Result;
        }

        private async Task<bool> SendOTPAsync(int? code, string number, string message)
        {
            try
            {
                if (code is null
                    || string.IsNullOrEmpty(number)
                    || string.IsNullOrEmpty(message))
                {
                    return false;
                }

                var request = new PublishRequest
                {
                    Message = message,
                    PhoneNumber = $"{code}{number}",
                };

                var messageAttributes = new Dictionary<string, MessageAttributeValue>();
                messageAttributes.Add("AWS.SNS.SMS.SMSType", new MessageAttributeValue
                {
                    DataType = "String",
                    StringValue = "MyOTP"
                });

                messageAttributes.Add("AWS.SNS.SMS.SenderID", new MessageAttributeValue
                {
                    DataType = "String",
                    StringValue = "MyOTP"
                });
                request.MessageAttributes = messageAttributes;

                var result = await snsClient.PublishAsync(request);
                if (result.HttpStatusCode == System.Net.HttpStatusCode.OK)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error send in OTP: {ex.Message}");
                return false;
            }
        }
    }
}