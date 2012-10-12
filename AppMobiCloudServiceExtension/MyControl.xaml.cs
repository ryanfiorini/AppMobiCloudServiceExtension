using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace appMobi.AppMobiCloudServiceExtension
{
    /// <summary>
    /// Interaction logic for MyControl.xaml
    /// </summary>
    public partial class MyControl : UserControl
    {
        private const string verbOpen = "Open";
        private string userToken = "";
        private string userName = "";
        
        private CollectionView _appMobiApps;
        public CollectionView AppMobiApps
        {
            get { return _appMobiApps; }
        }

        public MyControl()
        {
            InitializeComponent();

            grpWelcome.Visibility = System.Windows.Visibility.Hidden;

            txtUserName.Text = "ryanwfiorini@gmail.com";
            txtPassword.Password = "";
        }

        /*private void serviceClient_Completed(object sender, VisualStudioUserService.HelloWorldCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }*/

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")]
        private void btnSignin_Click(object sender, RoutedEventArgs e)
        {
            userName = txtUserName.Text;

            var request = new BReq();
            JObject json = (JObject)JsonConvert.DeserializeObject<object>(request.HttpPost("http://enterprise.appmobi.com/vs/VisualStudioService.asmx/SignIn", "{\"userName\":\"" + txtUserName.Text + "\",\"password\":\"" + txtPassword.Password + "\"}"));
            JObject jObject = JObject.FromObject(json);
            JObject d = (JObject)jObject.SelectToken("d");

            if (jObject["d"]["Status"].Value<string>() == "SUCCESS")
            {
                userToken = jObject["d"]["Token"].Value<string>();
                grpSignin.Visibility = System.Windows.Visibility.Hidden;
                grpWelcome.Visibility = System.Windows.Visibility.Visible;
                btnWindowsLive.Visibility = System.Windows.Visibility.Hidden;

                lblUserName.Content = userName;

                string response = request.HttpGet("http://services.appmobi.com/external/sdkservices.aspx?cmd=getapplist&userid=" + userToken + "&rnd=95570673");

                string[] jsons = response.Split('=');
                string[] theend = jsons[1].Split(';');

                json = (JObject)JsonConvert.DeserializeObject<object>(theend[0]);
                if (json["rtn"].Value<string>().Equals("ok"))
                {
                    IList<AppmobiApp> appMobiApps = new List<AppmobiApp>();

                    JArray results = (JArray)json.SelectToken("appmobiapps");
                    foreach (var result in results)
                    {
                        AppmobiApp aa = new AppmobiApp
                        {
                            Name = result["name"].Value<string>(),
                            Password = result["password"].Value<string>(),
                            Release = result["releases"][0]["name"].Value<string>()
                        };

                        appMobiApps.Add(aa);
                    }
                    _appMobiApps = new CollectionView(appMobiApps);

                    cboAppMobiApps.DataContext = AppMobiApps;
                }
            }
            else
            {
            }
        }

        #region event handlers
        private void btnGotoApphub_Click(object sender, RoutedEventArgs e)
        {
            string url ="";

            if (userName != "")
            {
                url = "http://apphub.appmobi.com/csd/Cloud-Services-Dashboard-Login.aspx?userid=" + userToken + "&returnurl=http%3A%2F%2Fapphub.appmobi.com%2Fcsd%2Fcontrolpanel.aspx";
            }
            else
            {
                url = "http://apphub.appmobi.com";
            }

            LaunchWebBrowser(BrowserService, url, true);

        }
        #endregion

        #region service handlers

        #endregion

        #region Browser Handler
        private IVsWebBrowsingService browserService = null;
        /// <summary>
        /// Get the IVsWebBrowserService to use for navigating to the internal browser.
        /// </summary>
        private IVsWebBrowsingService BrowserService
        {
            get
            {
                if (browserService == null)
                {
                    // if we don't already have the internal browser service, get it from the global service provider.
                    browserService = Package.GetGlobalService(typeof(SVsWebBrowsingService)) as IVsWebBrowsingService;
                }


                return browserService;
            }
        }

        private ProcessStartInfo startInfo;
        /// <summary>
        /// Gets the initialized instance of ProcessStartInfo for a ShellExecute Open command.
        /// </summary>
        public ProcessStartInfo StartInfo
        {
            get
            {
                if (startInfo == null)
                {
                    startInfo = new ProcessStartInfo();
                    startInfo.UseShellExecute = true;
                    startInfo.Verb = verbOpen;
                }
 
                return startInfo;
            }
        }
        /// <summary>
        /// Launches the specified Url either in the internal VS browser or the
        /// user's default web browser.
        /// </summary>
        /// <param name="browserService">VS's browser service for interacting with the internal browser.</param>
        /// <param name="launchUrl">Url to launch.</param>
        /// <param name="useInternalBrowser">true to use the internal browser; false to use the default browser.</param>
        private void LaunchWebBrowser(IVsWebBrowsingService browserService, string launchUrl, bool useInternalBrowser)
        {
            try
            {
                if (useInternalBrowser == true)
                {
                    // if set to use internal browser, then navigate via the browser service.
                    IVsWindowFrame ppFrame;
 
                    // passing 0 to the NavigateFlags allows the browser service to reuse open instances
                    // of the internal browser.
                    browserService.Navigate(launchUrl, 0, out ppFrame);
                }
                else
                {
                    // if not, launch the user's default browser by starting a new one.
                    StartInfo.FileName = launchUrl;
                    Process.Start(StartInfo);
                }
            }
            catch
            {
                // if the process could not be started, show an error.
                MessageBox.Show("Cannot launch this url.", "Extension Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        private void btnWindowsLive_Click(object sender, RoutedEventArgs e)
        {
            string url = Globals.ENDPOINT_OAUTH +
                               Globals.ENDPOINT_PATH_AUTHORIZE +
                               Globals.PARAM_CLIENT_ID +
                               Globals.APP_CLIENT_ID +
                               Globals.PARAM_SCOPE +
                               Globals.REQUESTED_SCOPES +
                               Globals.PARAM_RESPONSE_TYPE +
                               Globals.PARAM_RESPONSE_TYPE_CODE +
                               Globals.PARAM_REDIRECT_URI +
                               Globals.APP_REDIRECT_URI;

            LaunchWebBrowser(BrowserService, url, true);


        }

        private void btnUploadPackage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDownloadPackage_Click(object sender, RoutedEventArgs e)
        {
            AppmobiApp cboValue = (AppmobiApp)cboAppMobiApps.SelectedItem;

            var request = new BReq();

            string response = request.HttpGet("http://services.appmobi.com/external/clientservices.aspx?feed=getappconfig&app=" + cboValue.Name + "&pkg=QA&pw=&rel=" + cboValue.Release + "&redirect=1");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response);
            string jsonText = JsonConvert.SerializeXmlNode(doc);

            JObject json = (JObject)JsonConvert.DeserializeObject<object>(jsonText);

            string bundleUrl = json["XML"]["CONFIG"]["BUNDLE"]["@base"].Value<string>();


            using (var client = new WebClient())
            {
                client.DownloadFile(bundleUrl, @"C:\temp\1.zip");
            }

        }

    }
}