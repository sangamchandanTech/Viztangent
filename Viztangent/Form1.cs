using System;
using System.Diagnostics;
using System.Net.Http;
using System.Security.Cryptography.Pkcs;
using System.Text.Json;
using System.Threading.Tasks;

namespace Viztangent
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();
        public Form1()
        {
            InitializeComponent();
        }

        private async void submitButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(userInput.Text))
                return;
            var userInputData = userInput.Text;
            submitButton.Text = "Loading..";
            submitButton.Enabled = false;
            AddLabel(userInputData, true);
            var apiResponse = await CallApi(userInputData);
            if (apiResponse != null)
            {
                if (apiResponse.status != "success")
                {
                    apiResponse.answer = "Error from API";
                }
                if (apiResponse.answer.Contains("json"))
                {
                    var answer = apiResponse.answer.ToString().Replace("```", "").Trim().Replace("json", "").Trim();
                    var addressDetails = JsonSerializer.Deserialize<Maps>(answer);
                    if (addressDetails != null)
                    {
                        //MessageBox.Show($"Address : {addressDetails.address}\nRadius : {addressDetails.radius} ");
                        ExecutePythonScript(addressDetails.address, addressDetails.radius);
                        AddLabel("Data Imported to AutoCAD");
                    }
                    else
                    {
                        AddLabel("Data not Imported to AutoCAD");
                    }
                }
                else
                {
                    AddLabel(apiResponse.answer);
                }
            }
            else
            {
                AddLabel("Null Response from API");
            }
            submitButton.Text = "Submit";
            submitButton.Enabled = true;
        }
        public void AddLabel(string labelText, bool isUserInput = false)
        {
            userInput.Text = string.Empty;
            RichTextBox rtb = new RichTextBox();
            rtb.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
            rtb.ReadOnly = true;
            rtb.BorderStyle = BorderStyle.None;
            rtb.BackColor = panel1.BackColor;
            rtb.ScrollBars = RichTextBoxScrollBars.None;
            rtb.Multiline = true;

            Font boldFont = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
            Font normalFont = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Pixel);

            string prefix = isUserInput ? "User :  " : "AI :  ";
            string fullText = prefix + labelText;
            rtb.Text = fullText;
            rtb.Select(0, prefix.Length);
            rtb.SelectionColor = isUserInput ? Color.Blue : Color.DarkGreen;
            rtb.SelectionFont = boldFont;
            rtb.Select(prefix.Length, labelText.Length);
            rtb.SelectionColor = Color.Black;
            rtb.SelectionFont = normalFont;
            int maxWidth = panel1.Width - 30;
            rtb.MaximumSize = new Size(maxWidth, 0);
            rtb.Width = maxWidth;
            rtb.AutoSize = false;
            using (Graphics g = rtb.CreateGraphics())
            {
                SizeF size = g.MeasureString(fullText, rtb.Font, maxWidth);
                rtb.Height = (int)Math.Ceiling(size.Height);
            }
            int y = 0;
            if (panel1.Controls.Count > 0)
            {
                Control last = panel1.Controls[panel1.Controls.Count - 1];
                y = last.Bottom ;
            }
            else
            {
                y = 10;
            }
            rtb.Location = new Point(10, y);
            panel1.Controls.Add(rtb);
        }

        public async Task<ApiResponse?> CallApi(string userInput)
        {
            var data = new
            {
                text = userInput// "How can i import data from arcgis"
            };
            string json = JsonSerializer.Serialize(data);
            HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            string apiUrl = "https://ai.viztangent.com/ask";
            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);
            string result = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(result))
            {
                return JsonSerializer.Deserialize<ApiResponse>(result);
            }
            return new ApiResponse();
        }

        public void ExecutePythonScript(string address, string radius)
        {
            string pythonExePath = @$"{System.Environment.GetEnvironmentVariable("USERPROFILE")}\AppData\Local\Programs\Python\Python311\python.exe";
            string scriptPath = @$"{Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent}\fetch.py";

            // Start info
            if (!File.Exists(scriptPath))
                return;
            ProcessStartInfo start = new ProcessStartInfo
            {
                FileName = pythonExePath,
                Arguments = $"\"{scriptPath}\" \"{address}\" \"{radius}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(start))
            {
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (!string.IsNullOrEmpty(error))
                {
                    Console.WriteLine("Python error: " + error);
                }

                Console.WriteLine("Python output: " + output);
            }
        }
    }
}
 