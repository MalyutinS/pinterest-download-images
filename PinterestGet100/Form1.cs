using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;

namespace PinterestGet100
{
    public partial class Form1 : Form
    {
        //  Current image link format http://media-cache-ak0.pinimg.com/236x/65/71/cd/6571cd9e7d8b782e1db0981feb3892e2.jpg
        private const string ImageRegExp = "(http://media-cache-[A-z0-9]{3}.pinimg.com/[A-z0-9]{4}/[A-z0-9]{2}/[A-z0-9]{2}/[A-z0-9]{2}/[A-z0-9]{32}\\.jpg)";

        public Form1()
        {
            InitializeComponent();
        }


        public static Image GetImageFromUrl(string url)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            using (var httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (Stream stream = httpWebReponse.GetResponseStream())
                {
                    return stream != null ? Image.FromStream(stream) : null;
                }
            }
        }

        private DownloadResult SaveImagesFromResponce(HttpWebResponse response, string url, DownloadResult downloadResult)
        {
            var dowloadResult = new DownloadResult
                                    {
                                        ImagesLeftToDownload = downloadResult.ImagesLeftToDownload,
                                        TotalImagesRequested = downloadResult.TotalImagesRequested
                                    };
            if (response != null)
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var html = reader.ReadToEnd();
                    var r = new Regex(ImageRegExp, RegexOptions.IgnoreCase);
                    MatchCollection matchCollection = r.Matches(html);

                    var bookmarksRegex = new Regex("\"bookmarks\": \\[\"([A-z0-9=]*)\"\\]", RegexOptions.IgnoreCase);

                    Match bookmarksMatch = bookmarksRegex.Match(html);
                    dowloadResult.Bookmarks = bookmarksMatch.Groups[1].ToString();

                    var i = 0;

                    lbxOutput.Items.Add(string.Format("{0}: Requesting {1} {2} (images left to download {3} from {4}) images from {5}",
                                                      DateTime.Now,
                                                      url.Contains("?") ? "additional" : "top",
                                                      Math.Min(matchCollection.Count, dowloadResult.ImagesLeftToDownload),
                                                      dowloadResult.ImagesLeftToDownload,
                                                      dowloadResult.TotalImagesRequested,
                                                      url.Contains("?") ? url.Substring(0, url.IndexOf('?')) : url));

                    int alreadyExistsCount = 0;
                    foreach (Match match in matchCollection)
                    {
                        if (dowloadResult.ImagesLeftToDownload > 0)
                        {
                            var link = match.Groups[1].ToString();

                            var fullImageName = string.Format("{0}/{1}", tbxDir.Text,
                                                              link.Substring(link.LastIndexOf("/") + 1));

                            string status;
                            if (File.Exists(fullImageName))
                            {
                                status = "Image exists";
                                alreadyExistsCount++;
                            }
                            else
                            {
                                status = "Image saved!";
                                var image = GetImageFromUrl(link);
                                image.Save(fullImageName);
                            }
                            lbxOutput.Items.Add(string.Format("{0,3} - {1,12} - {2}", (++i), status, link));
                            dowloadResult.ImagesLeftToDownload--;
                        }
                        else
                        {
                            break;
                        }

                    }
                    if (alreadyExistsCount > 0)
                    {
                        lbxOutput.Items.Add(string.Format("{0} image(s) already exists in the specified folder", alreadyExistsCount));
                    }
                    lbxOutput.Items.Add(string.Empty);

                }
            }
            return dowloadResult;
        }

        private DownloadResult LoadMore(DownloadResult downloadResult)
        {
            try
            {
                 string url =
                "http://www.pinterest.com/resource/CategoryFeedResource/get/?source_url=%2Fpopular%2F&data=%7B%22options%22%3A%7B%22feed%22%3A%22popular%22%2C%22bookmarks%22%3A%5B%22" +
                HttpUtility.UrlEncode(downloadResult.Bookmarks)+
                "%22%5D%2C%22is_category_feed%22%3Afalse%7D%2C%22context%22%3A%7B%22app_version%22%3A%22531ed88%22%2C%22https_exp%22%3Afalse%7D%2C%22module%22%3A%7B%22name%22%3A%22GridItems%22%2C%22options%22%3A%7B%22scrollable%22%3Atrue%2C%22show_grid_footer%22%3Atrue%2C%22centered%22%3Atrue%2C%22reflow_all%22%3Atrue%2C%22virtualize%22%3Atrue%2C%22item_options%22%3A%7B%22show_pinner%22%3Atrue%2C%22show_pinned_from%22%3Afalse%2C%22show_board%22%3Atrue%7D%2C%22layout%22%3A%22variable_height%22%2C%22track_item_impressions%22%3Atrue%7D%7D%2C%22append%22%3Atrue%2C%22error_strategy%22%3A1%7D&_=1390777210435";
                
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                request.Accept = "application/json, text/javascript, */*; q=0.01";
                request.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
                request.Headers.Add("Accept-Language", "en-US,en;q=0.8,ru;q=0.6");
                request.KeepAlive = true;
                request.Host = "www.pinterest.com";
                request.Referer = "http://www.pinterest.com/popular/";
                request.UserAgent =
                    "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/32.0.1700.76 Safari/537.36";
                request.Headers.Add("X-APP-VERSION", "531ed88");
                request.Headers.Add("X-CSRFToken", "null");
                request.Headers.Add("X-NEW-APP", "1");
                request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                var response = request.GetResponse() as HttpWebResponse;

                return SaveImagesFromResponce(response, url, downloadResult);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return downloadResult;
            }

            
        }

        private void GetImages(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(tbxDir.Text))
                {
                    MessageBox.Show("Please choose directory to save images");
                    return;
                }

                const string url = "http://www.pinterest.com/popular/";

                var request = (HttpWebRequest) WebRequest.Create(url);
                request.Method = "GET";
                if (request.CookieContainer == null)
                {
                    request.CookieContainer = new CookieContainer();
                }

                var response = request.GetResponse() as HttpWebResponse;

                DownloadResult downloadResult = SaveImagesFromResponce(response, url, new DownloadResult
                {
                    ImagesLeftToDownload = int.Parse(tbxAmount.Text),
                    TotalImagesRequested = int.Parse(tbxAmount.Text)
                });

                while (downloadResult.ImagesLeftToDownload > 0)
                {
                    downloadResult = LoadMore(downloadResult);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChooseDir(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbxDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void SpacePress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                Clipboard.SetText(lbxOutput.SelectedItem.ToString());
            }
        }

        private void TbxAmountValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(tbxAmount.Text, out parsedValue) || parsedValue < 1 || parsedValue > 9999)
            {
                e.Cancel = true;
                MessageBox.Show("Value for the amount of images should be integer between 1 and 9999","Warning");
            }
        }
    

        private class DownloadResult
        {
            public string Bookmarks { get; set; }

            public int ImagesLeftToDownload { get; set; }

            public int TotalImagesRequested { get; set; }
        }

        
    }
}
