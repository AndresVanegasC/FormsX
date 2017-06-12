using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DevAzt.FormsX.ApplicationModel.Programming.Facebook
{
    public class OauthExample : ContentPage
    {

        public string ClientId { get; set; }

        public string RedirectUrl { get; set; }

        public OauthExample(string clientid, string redirecturl = "http://www.facebook.com/connect/login_success.html", Action<FacebookOAuthResult> accesstokenresult = null)
        {
            ClientId = clientid;
            RedirectUrl = redirecturl;
            AccessTokenResult += async (s, r) =>
            {
                await Navigation.PopAsync();
                accesstokenresult(r);
            };
            Content = RequestAccessToken();
        }

        public event EventHandler<FacebookOAuthResult> AccessTokenResult;

        private void OnAccessTokenResult(FacebookOAuthResult oauthresult)
        {
            if (AccessTokenResult != null)
            {
                AccessTokenResult.Invoke(this, oauthresult);
            }
        }

        public WebView RequestAccessToken()
        {
            var apiurl = $"https://www.facebook.com/dialog/oauth?client_id={ClientId}&display=popup&response_type=token&redirect_uri={RedirectUrl}";
            var webview = new WebView
            {
                Source = apiurl,
                HeightRequest = 1
            };

            webview.Navigated += Webview_Navigated;
            return webview;
        }

        private void Webview_Navigated(object sender, WebNavigatedEventArgs e)
        {
            var accesstoken = ExtractAccessTokenFromUrl(e.Url);
            if (!string.IsNullOrEmpty(accesstoken))
            {
                OnAccessTokenResult(new FacebookOAuthResult
                {
                    AccessToken = accesstoken
                });
            }
        }

        private string ExtractAccessTokenFromUrl(string url)
        {
            if (url.Contains("access_token") && url.Contains("&expires_in="))
            {
                var at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");
                /*
                if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
                {
                    at = url.Replace("http://www.facebook.com/connect/login_success.html#access_token=", "");
                }
                */
                var accessToken = at.Remove(at.IndexOf("&expires_in="));
                return accessToken;
            }
            return string.Empty;
        }
    }
}
