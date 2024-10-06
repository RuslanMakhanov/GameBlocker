using System.Diagnostics;

namespace GameBlocker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private List<string> blockedApps = new List<string>();
        private void buttonSelectApps_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true; // ��������� ������� ��������� ������
                    openFileDialog.Filter = "Executable Files|*.exe"; // ������ ��� .exe ������

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string filePath in openFileDialog.FileNames)
                        {
                            AddAppToList(filePath); // ��������� ���������� � ListView
                            blockedApps.Add(filePath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"��������� ������: {ex.Message}");
            }
        }

        private void AddAppToList(string filePath)
        {
            try
            {
                // ���������, �������� �� ���� �����������
                if (Path.GetExtension(filePath).ToLower() != ".exe")
                {
                    MessageBox.Show("��������� ���� �� �������� ����������� (.exe). ����������, �������� ������ ����.");
                    return; // ��������� ���������� ������
                }

                // �������� ������ ��� ���������� .exe �����
                Icon appIcon = Icon.ExtractAssociatedIcon(filePath);

                // ������� ������� ��� ListView � ��������� ����������
                ListViewItem item = new ListViewItem(Path.GetFileNameWithoutExtension(filePath));
                item.Tag = filePath; // ��������� ���� � ���������� � Tag
                item.ImageIndex = imageListApps.Images.Count; // ������ ������

                // ��������� ������ � ImageList
                imageListApps.Images.Add(appIcon);

                // ��������� ������� � ListView
                listViewApps.Items.Add(item);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ���������� ����������: {ex.Message}");
            }
        }

        private void buttonBlockApps_Click(object sender, EventArgs e)
        {
            DateTime unlockTime = dateTimePickerUnlock.Value;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100000; // ��������� ������ ������
            timer.Tick += (s, args) =>
            {
                if (DateTime.Now >= unlockTime)
                {
                    // ������ ������������� ����������
                    timer.Stop();
                    apssblockedornot.Text = "��� ��������������� ����������";
                    
                }
                BlockApplications();
            };
            timer.Start();
            apssblockedornot.Text = ($"���������� ������������� �� {unlockTime}");
            
        }


        private void BlockApplications()
        {
            foreach (string appPath in blockedApps)
            {
                string appName = Path.GetFileNameWithoutExtension(appPath); // �������� ��� ���������� ��� ����������

                // �������� ��� �������� � ���� ������
                Process[] runningProcesses = Process.GetProcessesByName(appName);
                foreach (Process process in runningProcesses)
                {
                    try
                    {
                        // ��������� �������
                        process.Kill();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"�� ������� ��������� {appName}: {ex.Message}");
                    }
                }
            }
        }


    }
}
