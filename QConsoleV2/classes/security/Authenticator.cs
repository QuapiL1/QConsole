using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Google.Authenticator;
using Imgur.API.Authentication;
using Imgur.API.Endpoints;

namespace QConsole.classes.security
{
    public class Authenticator
    {
        private const int MaxValue = 999999;
        private const int MinValue = 100000;

        public bool ValidateTwoFactorPIN(string key, string pin)  
        {  
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();  
            return tfa.ValidateTwoFactorPIN(key, pin);  
        }  
  
        public string GenerateTwoFactorAuthentication(string accountName)  
        {  
            Guid guid = Guid.NewGuid();

            string uniqueUserKey = Convert.ToString(guid).Replace("-", "").Substring(0, 10);

            Dictionary<string, string> result = new Dictionary<string, string>();  
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();  
            var setupInfo = tfa.GenerateSetupCode("QSystems", accountName, uniqueUserKey, false, 10);
            
            Console.Write("ACCOUNT KEY: ");
            Console.Write(setupInfo.ManualEntryKey);
            Console.Write("\nOpen QR code in web browser? ");
            bool openUrl = bool.Parse(Console.ReadLine());

            if (openUrl)
            {

                upload(setupInfo.QrCodeSetupImageUrl);

                Console.ReadLine();
            }

            return uniqueUserKey;  
        }

        private async void upload(string path)
        {
            var apiClient = new ApiClient("40384920f21c008", "4369fb8f5fcdaa64aab2a3e65849235b899895f7");
            var httpClient = new HttpClient();

            var filePath = path;
            using var fileStream = File.OpenRead(filePath);

            var imageEndpoint = new ImageEndpoint(apiClient, httpClient);
            var imageUpload = await imageEndpoint.UploadImageAsync(fileStream);
        }

        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                } else
                {
                    throw;
                }
            }
        }
    }
}