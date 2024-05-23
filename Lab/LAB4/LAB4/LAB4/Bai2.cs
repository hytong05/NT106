using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace LAB4
{
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
            webBrowser.ScriptErrorsSuppressed = true;
            comboBoxUserAgent.Items.AddRange(new string[] { "Safari - iPhone", "Safari - iPad", "Chrome - Windows" });
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string URL = textURL.Text;

            if (!Uri.TryCreate(URL, UriKind.Absolute, out Uri uri))
            {
                MessageBox.Show("Invalid URL format. Please enter a valid URL.");
                return;
            }

            // Tạo yêu cầu HTTP
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            try
            {
                // Thay đổi User-Agent của yêu cầu HTTP
                string userAgent = GetUserAgentFromComboBox(comboBoxUserAgent.Text);
                request.UserAgent = userAgent;

                // Gửi yêu cầu và nhận phản hồi
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    // Đọc nội dung của phản hồi từ máy chủ
                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        string responseText = streamReader.ReadToEnd();
                        richTextBox1.Text = responseText;

                        // Hiển thị nội dung HTML trong WebBrowser control
                        webBrowser.DocumentText = responseText;
                    }
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show($"Error accessing URL: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private string GetUserAgentFromComboBox(string selection)
        {
            switch (selection)
            {
                case "Safari - iPhone":
                    return "Mozilla/5.0 (iPhone; CPU iPhone OS 15_0 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148";
                case "Safari - iPad":
                    return "Mozilla/5.0 (iPad; CPU OS 15_0 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148";
                case "Chrome - Windows":
                    return "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/94.0.4606.81 Safari/537.36";
                default:
                    throw new ArgumentException("Invalid User-Agent selection.");
            }
        }
    }
}
