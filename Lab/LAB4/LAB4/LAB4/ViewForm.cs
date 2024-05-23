using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB4
{
    public partial class ViewForm : Form
    {
        string url = string.Empty;
        public ViewForm(string URL)
        {
            InitializeComponent();
            url = URL;
        }

        private string GetHTML(string URL)
        {
            try
            {
                // Validate the URL format before making the request
                if (!Uri.IsWellFormedUriString(URL, UriKind.Absolute))
                {
                    MessageBox.Show("Invalid URL format. Please enter a valid URL.");
                    return "ERROR";
                }

                // Create a request for the URL
                WebRequest request = WebRequest.Create(URL);

                // Get the response
                WebResponse response = request.GetResponse();

                // Get the stream containing content returned by server
                Stream dataStream = response.GetResponseStream();

                // Open the stream using a StreamReader for easy access
                StreamReader reader = new StreamReader(dataStream);

                // Read the content. 
                string responseFromServer = reader.ReadToEnd();

                // Close the response
                dataStream.Close();

                return responseFromServer;
            }
            catch (WebException ex)
            {
                // Handle web exceptions like timeouts or server errors
                MessageBox.Show($"Failed to access URL: {ex.Message}");
                return "ERROR";
            }
            catch (Exception ex)
            {
                // Catch other exceptions
                MessageBox.Show($"An error occurred: {ex.Message}");
                return "ERROR";
            }
        }

        private void GetHeader(string URL)
        {
            try
            {
                // Create a 'WebRequest' object with the specified url. 	
                WebRequest myWebRequest = WebRequest.Create(URL);

                // Send the 'WebRequest' and wait for response.
                WebResponse myWebResponse = myWebRequest.GetResponse();

                int index = 1;

                // Display each header and it's key , associated with the response object.
                for (int i = 0; i < myWebResponse.Headers.Count; ++i)
                {
                    // Create a new ListViewItem object
                    ListViewItem item = new ListViewItem();

                    // Set the values for each column
                    item.Text = index.ToString();
                    index++;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = myWebResponse.Headers.Keys[i] });
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = myWebResponse.Headers[i] });

                    // Add the new ListViewItem to the ListView
                    listHeaderInfo.Items.Add(item);
                }

                // Release resources of response object.
                myWebResponse.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting headers: {ex.Message}");
            }
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {
            // Clear the ListView before download attempt (optional)
            listHeaderInfo.Items.Clear();

            try
            {
                // Download content and get headers (assuming these methods work)
                HTTPContent.Text = GetHTML(url);
                GetHeader(url);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., display error message to user)
                MessageBox.Show($"Error downloading or getting headers: {ex.Message}");
            }
        }
    }
}
