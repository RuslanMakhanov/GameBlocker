namespace GameBlocker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dateTimePickerUnlock = new DateTimePicker();
            buttomSelectApps = new Button();
            labelGreeting = new Label();
            listViewApps = new ListView();
            imageListApps = new ImageList(components);
            buttonBlockApps = new Button();
            apssblockedornot = new Label();
            SuspendLayout();
            // 
            // dateTimePickerUnlock
            // 
            dateTimePickerUnlock.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePickerUnlock.Format = DateTimePickerFormat.Custom;
            dateTimePickerUnlock.Location = new Point(480, 44);
            dateTimePickerUnlock.Name = "dateTimePickerUnlock";
            dateTimePickerUnlock.Size = new Size(200, 23);
            dateTimePickerUnlock.TabIndex = 0;
            // 
            // buttomSelectApps
            // 
            buttomSelectApps.Location = new Point(12, 147);
            buttomSelectApps.Name = "buttomSelectApps";
            buttomSelectApps.Size = new Size(145, 23);
            buttomSelectApps.TabIndex = 1;
            buttomSelectApps.Text = "Выбрать Приложения";
            buttomSelectApps.UseVisualStyleBackColor = true;
            buttomSelectApps.Click += buttonSelectApps_Click;
            // 
            // labelGreeting
            // 
            labelGreeting.AutoSize = true;
            labelGreeting.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelGreeting.Location = new Point(12, 9);
            labelGreeting.Name = "labelGreeting";
            labelGreeting.Size = new Size(668, 32);
            labelGreeting.TabIndex = 2;
            labelGreeting.Text = "Привет! Какие Приложения вы хотите заблокировать?";
            // 
            // listViewApps
            // 
            listViewApps.LargeImageList = imageListApps;
            listViewApps.Location = new Point(12, 44);
            listViewApps.Name = "listViewApps";
            listViewApps.Size = new Size(121, 97);
            listViewApps.TabIndex = 3;
            listViewApps.UseCompatibleStateImageBehavior = false;
            // 
            // imageListApps
            // 
            imageListApps.ColorDepth = ColorDepth.Depth32Bit;
            imageListApps.ImageSize = new Size(16, 16);
            imageListApps.TransparentColor = Color.Transparent;
            // 
            // buttonBlockApps
            // 
            buttonBlockApps.Location = new Point(279, 147);
            buttonBlockApps.Name = "buttonBlockApps";
            buttonBlockApps.Size = new Size(107, 23);
            buttonBlockApps.TabIndex = 4;
            buttonBlockApps.Text = "Заблокировать";
            buttonBlockApps.UseVisualStyleBackColor = true;
            buttonBlockApps.Click += buttonBlockApps_Click;
            // 
            // apssblockedornot
            // 
            apssblockedornot.AutoSize = true;
            apssblockedornot.Location = new Point(76, 211);
            apssblockedornot.Name = "apssblockedornot";
            apssblockedornot.Size = new Size(38, 15);
            apssblockedornot.TabIndex = 5;
            apssblockedornot.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(689, 257);
            Controls.Add(apssblockedornot);
            Controls.Add(buttonBlockApps);
            Controls.Add(listViewApps);
            Controls.Add(labelGreeting);
            Controls.Add(buttomSelectApps);
            Controls.Add(dateTimePickerUnlock);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePickerUnlock;
        private Button buttomSelectApps;
        private Label labelGreeting;
        private ListView listViewApps;
        private ImageList imageListApps;
        private Button buttonBlockApps;
        private Label apssblockedornot;
    }
}
