using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace LAB4
{
    public partial class Bai4 : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public Bai4()
        {
            InitializeComponent();
            webBrowser.ScriptErrorsSuppressed = true;
        }

        private void Go_btn_Click(object sender, EventArgs e)
        {
            string url = URLtxt.Text;

            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                try
                {
                    // Thêm tiền tố "http://" nếu thiếu
                    if (!url.StartsWith("https://"))
                    {
                        url = "https://" + url;
                    }

                    // Render trang web bằng WebBrowser control
                    webBrowser.Navigate(new Uri(url));
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi nếu không thể điều hướng
                    MessageBox.Show("Không thể điều hướng đến URL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Hiển thị thông báo lỗi nếu URL không hợp lệ
                MessageBox.Show("URL không hợp lệ. Vui lòng nhập URL đúng định dạng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void Download_btn_Click(object sender, EventArgs e)
        {
            string url = URLtxt.Text.Trim();
            string destinationFolder = AppDomain.CurrentDomain.BaseDirectory; 

            try
            {
                await DownloadWebsiteAsync(url);
                MessageBox.Show("Tải trang web và các tài nguyên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải trang web: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static async Task DownloadWebsiteAsync(string url)
        {
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                throw new ArgumentException("URL không hợp lệ.");
            }

            // Thư mục đích là thư mục 'src' trong thư mục hiện tại của ứng dụng
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string destinationFolder = Path.Combine(currentDirectory, "src");

            // Xóa tất cả các tệp và thư mục trong 'src' nếu tồn tại
            if (Directory.Exists(destinationFolder))
            {
                Directory.Delete(destinationFolder, true);
            }

            // Tạo lại thư mục 'src'
            Directory.CreateDirectory(destinationFolder);

            // Tải HTML của trang web
            string html = await client.GetStringAsync(url);

            // Lưu trang HTML vào file
            string htmlFilePath = Path.Combine(destinationFolder, "index.html");
            await WriteTextToFileAsync(htmlFilePath, html);

            // Phân tích HTML để tìm các tài nguyên
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);

            // Tải và lưu các tài nguyên (hình ảnh, CSS, JS, ...)
            await DownloadResourcesAsync(htmlDoc, url, destinationFolder);
        }


        private static async Task DownloadResourcesAsync(HtmlAgilityPack.HtmlDocument htmlDoc, string baseUrl, string destinationFolder)
        {
            // Các thẻ HTML mà chúng ta quan tâm (img, link, script, ...)
            string[] tags = { "img", "link", "script" };

            foreach (string tag in tags)
            {
                HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes($"//{tag}");
                if (nodes != null)
                {
                    foreach (HtmlNode node in nodes)
                    {
                        string attribute = GetResourceAttribute(tag);

                        if (node.Attributes.Contains(attribute))
                        {
                            string resourceUrl = node.Attributes[attribute].Value;
                            string absoluteUrl = new Uri(new Uri(baseUrl), resourceUrl).AbsoluteUri;

                            // Tải và lưu tài nguyên
                            await DownloadResourceAsync(absoluteUrl, destinationFolder);
                        }
                    }
                }
            }
        }

        private static string GetResourceAttribute(string tag)
        {
            switch (tag)
            {
                case "img":
                    return "src";
                case "link":
                    return "href";
                case "script":
                    return "src";
                default:
                    throw new ArgumentException("Tag không hợp lệ.");
            }
        }

        private static async Task DownloadResourceAsync(string resourceUrl, string destinationFolder)
        {
            try
            {
                // Tải tài nguyên
                byte[] data = await client.GetByteArrayAsync(resourceUrl);

                // Xác định đường dẫn lưu trữ tài nguyên
                Uri uri = new Uri(resourceUrl);
                string fileName = Path.GetFileName(uri.LocalPath);

                // Xác định loại tài nguyên dựa trên đuôi mở rộng của tệp
                string fileExtension = Path.GetExtension(fileName).ToLowerInvariant();
                string resourceTypeFolder = GetResourceTypeFolder(fileExtension);

                // Tạo đường dẫn thư mục cho loại tài nguyên nếu chưa tồn tại
                string resourceTypeFolderPath = Path.Combine(destinationFolder, resourceTypeFolder);
                Directory.CreateDirectory(resourceTypeFolderPath);

                // Lưu tài nguyên vào thư mục tương ứng
                string resourcePath = Path.Combine(resourceTypeFolderPath, fileName);
                await WriteBytesToFileAsync(resourcePath, data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Không thể tải tài nguyên {resourceUrl}: {ex.Message}");
            }
        }

        private static async Task WriteTextToFileAsync(string filePath, string content)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                await writer.WriteAsync(content);
            }
        }

        private static async Task WriteBytesToFileAsync(string filePath, byte[] data)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
            {
                await stream.WriteAsync(data, 0, data.Length);
            }
        }

        private static string GetResourceTypeFolder(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".gif":
                    return "img";
                case ".css":
                    return "css";
                case ".js":
                    return "js";
                default:
                    return "other"; // Thư mục "other" cho các loại tài nguyên khác
            }
        }

        private void View_btn_Click(object sender, EventArgs e)
        {
            ViewForm vf = new ViewForm(URLtxt.Text);
            vf.ShowDialog();
        }
    }

}
