using System.DirectoryServices;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Disc_Manager_Utility
{
    public partial class Form1 : Form
    {
        private List<Disc?> _discs;
        private readonly List<DriveInfo> _systemDiscs = GetAllDiscs();
        private bool _useDate = true;
        private Disc? _currentDisc;
        private int _discCounter = 0;

        public Form1()
        {
            InitializeComponent();
            foreach (var disc in _systemDiscs)
            {
                comboBox2.Items.Add(disc.Name);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate user input
                if (comboBox2.SelectedItem == null || string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Please select a disc and enter a name for the new disc.");
                    return;
                }

                string newDiscName = textBox2.Text;

                // Check if a disc with the same name already exists
                if (_discs.Any(disc => disc.Name == newDiscName))
                {
                    MessageBox.Show("A disc with this name already exists.");
                    return;
                }

                string selectedDiscPath = comboBox2.SelectedItem.ToString();

                // Check if the selected disc exists
                if (!Directory.Exists(selectedDiscPath))
                {
                    MessageBox.Show("Selected disc does not exist.");
                    return;
                }

                // Get the selected disc
                DriveInfo drive = _systemDiscs.Find(disc => disc.Name == selectedDiscPath);
                if (drive == null)
                {
                    MessageBox.Show("Selected drive information could not be found.");
                    return;
                }

                // Create a new disc
                var disc = new Disc(selectedDiscPath)
                {
                    Name = newDiscName
                };
                label6.Visible = true;
                button2.Enabled = false;

                // Add all files and directories from the disc in a background task
                await Task.Run(() => disc.AddEverythingFromDisc(drive, progressBar1));

                // Add the new disc to the list
                _discs.Add(disc);

                // Hide the progress bar and update the UI
                progressBar1.Visible = false;
                comboBox1.Items.Add(disc.Name);

                // Serialize the discs to XML in a background task
                label7.Visible = true;
                await Task.Run(() => SerializeDiscsWithProgress(_discs));
                label7.Visible = false;
                button2.Enabled = true;

                MessageBox.Show("Disc added and serialized successfully.");
            }
            catch (Exception ex)
            {
                button2.Enabled = true;
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private static List<DriveInfo> GetAllDiscs()
        {
            return DriveInfo.GetDrives().ToList();
        }


        private static async Task<List<Disc?>?> DeserializeDiscsAsync()
        {
            if (!File.Exists("discs.json")) return null;

            string json;
            using (var reader = new StreamReader("discs.json"))
            {
                json = await reader.ReadToEndAsync();
            }

            return JsonConvert.DeserializeObject<List<Disc>>(json);
        }

        private static void SerializeDiscsWithProgress(IReadOnlyList<Disc?> discs)
        {
            var discCount = discs.Count;

            using var writer = new StreamWriter("discs.json");
            writer.WriteLine("[");
            for (var i = 0; i < discCount; i++)
            {
                var json = JsonConvert.SerializeObject(discs[i], Formatting.Indented);
                writer.Write(json);
                if (i < discCount - 1)
                {
                    writer.WriteLine(",");
                }
            }
            writer.WriteLine("]");
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clearing the tree view
            treeView1.Nodes.Clear();
            // Getting the selected disc
            var disc = _discs.Find(disc => disc?.Name == comboBox1.SelectedItem?.ToString());
            // Showing the disc
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;
            comboBox1.Enabled = false;
            treeView1.Enabled = false;
            await Task.Run(() => disc?.ShowDisc(treeView1));
            progressBar1.Visible = false;
            treeView1.Enabled = true;
            comboBox1.Enabled = true;
            _currentDisc = disc;
            if (!label6.Visible)
            {
                label6.Visible = true;
            }

            if (!comboBox4.Visible)
            {
                comboBox4.Visible = true;
            }
        }

        private async void load_Disc(Disc? disc)
        {
            Invoke(new MethodInvoker(delegate
            {
                treeView1.Nodes.Clear();
                progressBar1.Visible = true;
                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 30;
                comboBox1.Enabled = false;
                treeView1.Enabled = false;
            }));

            // Perform the long-running task on a background thread
            await Task.Run(() => disc?.ShowDisc(treeView1));

            // Re-enable UI controls and hide the progress bar
            Invoke(new MethodInvoker(delegate
            {
                progressBar1.Visible = false;
                treeView1.Enabled = true;
                comboBox1.Enabled = true;
            }));
        }
        private async void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (comboBox3.Text)
                {
                    case "Alphabetical":
                        {
                            progressBar1.Visible = true;
                            progressBar1.Style = ProgressBarStyle.Marquee;
                            progressBar1.MarqueeAnimationSpeed = 30;
                            label8.Text = "Sorting discs by name...";
                            comboBox3.Enabled = false;
                            foreach (var disc in _discs)
                            {
                                await Task.Run(() => disc.SortByName());
                            }
                            label8.Text = "Sort By:";
                            comboBox3.Enabled = true;
                            progressBar1.Visible = false;
                            break;
                        }
                    case "Date":
                        {
                            progressBar1.Visible = true;
                            progressBar1.Style = ProgressBarStyle.Marquee;
                            progressBar1.MarqueeAnimationSpeed = 30;
                            label8.Text = "Sorting discs by date...";
                            comboBox3.Enabled = false;
                            foreach (var disc in _discs)
                            {
                                await Task.Run(() => disc.SortByDate());
                            }
                            label8.Text = "Sort By:";
                            comboBox3.Enabled = true;
                            progressBar1.Visible = false;
                            break;
                        }
                }
                // Serialize the discs to XML in a background task
                label7.Visible = true;
                await Task.Run(() => SerializeDiscsWithProgress(_discs));
                label7.Visible = false;
                button2.Enabled = true;
            }
            catch (Exception ex)
            {
                comboBox3.Enabled = true;
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // In your button click event:
        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter a search term.");
                return;
            }

            var tasks = _discs.Select(disc => Task.Run(() =>
            {
                var discResults = disc.SearchAll(textBox1.Text);
                return discResults.Select(result => (result.Item1, disc.Name + result.Item2)).ToArray();
            }));

            progressBar2.Style = ProgressBarStyle.Marquee;
            progressBar2.MarqueeAnimationSpeed = 30;
            progressBar2.Visible = true;
            var results = await Task.WhenAll(tasks);
            progressBar2.Visible = false;

            var displayResults = new List<SearchResult>();

            foreach (var result in results.SelectMany(r => r))
            {
                if (result.Item1 is { Value: not null })
                {
                    var fileSystemItem = result.Item1.Value;
                    var fullPath = result.Item2; // Include disc name in file path
                    displayResults.Add(new SearchResult
                    {
                        FileName = fileSystemItem.Name,
                        Directory = fullPath,
                        Date = fileSystemItem.Date
                    });
                }
            }

            dataGridView1.DataSource = displayResults;

            // Adjust column settings
            dataGridView1.Columns["FileName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Directory"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        public async Task<(TreeNode<FileSystemItem>, string)[]> Search(string search)
        {
            var results = _discs.Select(disc => Task.Run(() =>
            {
                var discResults = disc.SearchAll(search);
                return discResults.Select(result => (result.Item1, disc.Name + result.Item2)).ToArray();
            }));

            return (await Task.WhenAll(results)).SelectMany(r => r).ToArray();
        }

        private async Task<TreeNode<FileSystemItem>?> Search(Disc disc)
        {
            return await Task.Run(() => disc.Search(textBox1.Text, _useDate, dateTimePicker1.Value, dateTimePicker2.Value));
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                _useDate = true;
            }
            else
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                _useDate = false;
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Show loading indicators
            label9.Visible = true;
            button1.Enabled = false;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;
            progressBar1.Visible = true;

            // Deserialize discs asynchronously on a background thread
            var discsTask = Task.Run(DeserializeDiscsAsync);
            var discs = await discsTask;

            // Hide loading indicators
            progressBar1.Visible = false;
            label9.Visible = false;
            button1.Enabled = true;

            // Process deserialized discs
            if (discs == null)
            {
                _discs = new List<Disc?>();
                _discCounter = 0;
            }
            else
            {
                comboBox1.BeginUpdate();
                _discs = discs;
                foreach (var disc in _discs)
                {
                    comboBox1.Items.Add(disc.Name);
                }
                comboBox1.EndUpdate();
                _discCounter = _discs.Count;
            }
        }

        private async void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            // sort the current disc and save the change to the file
            switch (comboBox4.Text)
            {
                case "Alphabetical":
                    {
                        progressBar1.Visible = true;
                        progressBar1.Style = ProgressBarStyle.Marquee;
                        progressBar1.MarqueeAnimationSpeed = 30;
                        label8.Text = "Sorting the disc by name...";
                        comboBox4.Enabled = false;
                        await Task.Run(() => _currentDisc.SortByName());
                        label8.Text = "Sort By:";
                        comboBox4.Enabled = true;
                        progressBar1.Visible = false;
                        break;
                    }
                case "Date":
                    {
                        progressBar1.Visible = true;
                        progressBar1.Style = ProgressBarStyle.Marquee;
                        progressBar1.MarqueeAnimationSpeed = 30;
                        label8.Text = "Sorting the disc by date...";
                        comboBox4.Enabled = false;
                        await Task.Run(() => _currentDisc.SortByDate());
                        label8.Text = "Sort By:";
                        comboBox4.Enabled = true;
                        progressBar1.Visible = false;
                        break;
                    }
            }
            _discs.Remove(_currentDisc);
            _discs.Add(_currentDisc);
            await Task.Run(() => load_Disc(_currentDisc));
            // Serialize the discs to XML in a background task
            label7.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;
            await Task.Run(() => SerializeDiscsWithProgress(_discs));
            label7.Visible = false;
            progressBar1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(_currentDisc == null)
            {
                MessageBox.Show("Please select a disc to delete.");
                return;
            }
            _discs.Remove(_currentDisc);
            comboBox1.Items.Remove(_currentDisc.Name);
            _currentDisc = null;
            treeView1.Nodes.Clear();
            comboBox4.Visible = false;
            label6.Visible = false;
            // Serialize the discs to XML in a background task
            label7.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;
            SerializeDiscsWithProgress(_discs);
            label7.Visible = false;
            progressBar1.Visible = false;
        }
    }
    public class SearchResult
    {
        public string FileName { get; set; }
        public string Directory { get; set; }
        public DateTime Date { get; set; }
    }
}