using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Zadatak_1.View
{
    /// <summary>
    /// Interaction logic for SMSWidnow.xaml
    /// </summary>
    public partial class SMSWidnow : Window
    {
        public SMSWidnow()
        {
            InitializeComponent();
        }

        private void SendMessage(object sender, RoutedEventArgs e)
        {
            try
            {
                var client = new RestClient("https://rest-api.d7networks.com/secure/send");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddHeader("Authorization", "Basic Y2FkbDE4OTc6S2ZuYnd3SnY=");

                string num = PhoneNumber.Text;
                string msg = Message.Text;

                request.AddParameter("application/x-www-form-urlencoded", "{\n\t\"to\":\"" + num + "\",\n\t\"content\":\""+msg+"\",\n\t\"from\":\"SMSINFO\",\n\t\"dlr\":\"yes\",\n\t\"dlr-method\":\"GET\", \n\t\"dlr-level\":\"2\", \n\t\"dlr-url\":\"http://yourcustompostbackurl.com\"\n}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("SMS sent successfully.", "Notification");
                Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            PanPizzaWindow window = new PanPizzaWindow();
            window.Show();
            Close();
        }
    }
}
