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
                    openFileDialog.Multiselect = true; // Позволяет выбрать несколько файлов
                    openFileDialog.Filter = "Executable Files|*.exe"; // Фильтр для .exe файлов

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string filePath in openFileDialog.FileNames)
                        {
                            AddAppToList(filePath); // Добавляем приложение в ListView
                            blockedApps.Add(filePath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void AddAppToList(string filePath)
        {
            try
            {
                // Проверяем, является ли файл исполняемым
                if (Path.GetExtension(filePath).ToLower() != ".exe")
                {
                    MessageBox.Show("Выбранный файл не является исполняемым (.exe). Пожалуйста, выберите другой файл.");
                    return; // Прерываем выполнение метода
                }

                // Получаем иконку для выбранного .exe файла
                Icon appIcon = Icon.ExtractAssociatedIcon(filePath);

                // Создаем элемент для ListView с названием приложения
                ListViewItem item = new ListViewItem(Path.GetFileNameWithoutExtension(filePath));
                item.Tag = filePath; // Сохраняем путь к приложению в Tag
                item.ImageIndex = imageListApps.Images.Count; // Индекс иконки

                // Добавляем иконку в ImageList
                imageListApps.Images.Add(appIcon);

                // Добавляем элемент в ListView
                listViewApps.Items.Add(item);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении приложения: {ex.Message}");
            }
        }

        private void buttonBlockApps_Click(object sender, EventArgs e)
        {
            DateTime unlockTime = dateTimePickerUnlock.Value;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100000; // Проверяем каждую минуту
            timer.Tick += (s, args) =>
            {
                if (DateTime.Now >= unlockTime)
                {
                    // Логика разблокировки приложений
                    timer.Stop();
                    apssblockedornot.Text = "Нет Заблокированных приложений";
                    
                }
                BlockApplications();
            };
            timer.Start();
            apssblockedornot.Text = ($"Приложения заблокированы до {unlockTime}");
            
        }


        private void BlockApplications()
        {
            foreach (string appPath in blockedApps)
            {
                string appName = Path.GetFileNameWithoutExtension(appPath); // Получаем имя приложения без расширения

                // Получаем все процессы с этим именем
                Process[] runningProcesses = Process.GetProcessesByName(appName);
                foreach (Process process in runningProcesses)
                {
                    try
                    {
                        // Завершаем процесс
                        process.Kill();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Не удалось завершить {appName}: {ex.Message}");
                    }
                }
            }
        }


    }
}
