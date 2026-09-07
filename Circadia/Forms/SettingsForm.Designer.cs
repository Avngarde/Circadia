using Circadia.Forms.Fonts;
using System.Drawing.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Circadia.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Size = new Size(420, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.BackColor = Color.FromArgb(18, 18, 24);
            this.Name = "Circadia Settings";

            mainPanel = new Panel()
            {
                Location = new Point(25, 25),
                Size = new Size(350, 650),
                BackColor = Color.FromArgb(30, 30, 40)
            };

            this.Controls.Add(mainPanel);

            titleLabel = new Label()
            {
                Text = "Circadia Settings",
                Font = CustomFontCollection.GetMontserrat(14, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(75, 25)
            };

            mainPanel.Controls.Add(titleLabel);

            brightnessLightLabel = new Label()
            {
                Text = "Brightness Light Mode",
                Font = CustomFontCollection.GetMontserrat(10, FontStyle.Regular),
                ForeColor = Color.LightGray,
                Location = new Point(30, 80),
                AutoSize = true
            };

            mainPanel.Controls.Add(brightnessLightLabel);
            
            brightnessLightBar = new TrackBar()
            {
                Location = new Point(30, 115),
                Width = 280,
                Minimum = 0,
                Maximum = 100,
                Value = 80,
                TickFrequency = 10,
            };
            
            brightnessLightBar.ValueChanged += BrightnessLightBarOnValueChanged;
            brightnessLightBar.Scroll += BrightnessBarShowcaseBrightness;
            brightnessLightBar.MouseUp += BrightnessBarSetOriginalBrightness;

            mainPanel.Controls.Add(brightnessLightBar);
            
            brightnessLightValue = new Label()
            {
                Text = "80%",
                Font = CustomFontCollection.GetMontserrat(12, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(155, 155)
            };

            mainPanel.Controls.Add(brightnessLightValue);
            
            brightnessDarkLabel = new Label()
            {
                Text = "Brightness Dark Mode",
                Font = CustomFontCollection.GetMontserrat(10, FontStyle.Regular),
                ForeColor = Color.LightGray,
                Location = new Point(30, 200),
                AutoSize = true
            };

            mainPanel.Controls.Add(brightnessDarkLabel);
            
            brightnessDarkBar = new TrackBar()
            {
                Location = new Point(30, 230),
                Width = 280,
                Minimum = 0,
                Maximum = 100,
                Value = 50,
                TickFrequency = 10
            };
            
            brightnessDarkBar.ValueChanged += BrightnessDarkBarOnValueChanged;
            brightnessDarkBar.Scroll += BrightnessBarShowcaseBrightness;
            brightnessDarkBar.MouseUp += BrightnessBarSetOriginalBrightness;

            mainPanel.Controls.Add(brightnessDarkBar);
            
            brightnessDarkValue = new Label()
            {
                Text = "50%",
                Font = CustomFontCollection.GetMontserrat(12, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(155, 270)
            };

            mainPanel.Controls.Add(brightnessDarkValue);
            
            blueLightLabel = new Label()
            {
                Text = "Blue Light Intensity",
                Font = CustomFontCollection.GetMontserrat(10, FontStyle.Regular),
                ForeColor = Color.LightGray,
                Location = new Point(30, 305),
                AutoSize = true
            };

            mainPanel.Controls.Add(blueLightLabel);
            
            blueLightBar = new TrackBar()
            {
                Location = new Point(30, 330),
                Width = 280,
                Minimum = 0,
                Maximum = 100,
                Value = 50,
                TickFrequency = 10
            };
            
            mainPanel.Controls.Add(blueLightBar);
            
            blueLightValue = new Label()
            {
                Text = "50%",
                Font = CustomFontCollection.GetMontserrat(12, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(155, 370)
            };

            mainPanel.Controls.Add(blueLightValue);

            timeFromLabel = new Label()
            {
                Text = "Dark Mode from",
                ForeColor = Color.LightGray,
                Font = CustomFontCollection.GetMontserrat(10, FontStyle.Regular),
                Location = new Point(30, 410),
                AutoSize = true
            };

            mainPanel.Controls.Add(timeFromLabel);

            timeFromPicker = new DateTimePicker()
            {
                Location = new Point(30, 440),
                Width = 120,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "HH:mm",
                ShowUpDown = true,
            };
            
            timeFromPicker.ValueChanged += TimeFromPickerOnValueChanged;

            mainPanel.Controls.Add(timeFromPicker);

            timeToLabel = new Label()
            {
                Text = "Dark Mode to",
                ForeColor = Color.LightGray,
                Font = CustomFontCollection.GetMontserrat(10, FontStyle.Regular),
                Location = new Point(200, 410),
                AutoSize = true
            };

            mainPanel.Controls.Add(timeToLabel);

            timeToPicker = new DateTimePicker()
            {
                Location = new Point(200, 440),
                Width = 120,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "HH:mm",
                ShowUpDown = true,
            };
            
            timeToPicker.ValueChanged += TimeToPickerOnValueChanged;

            mainPanel.Controls.Add(timeToPicker);
            
            getLocationButton = new Button()
            {
                Text = "Set timing from location",
                Location = new Point(30, 490),
                Size = new Size(290, 40),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = CustomFontCollection.GetMontserrat(10, FontStyle.Bold),
            };

            getLocationButton.FlatAppearance.BorderSize = 0;
            getLocationButton.Click += GetLocationButtonOnClick;

            mainPanel.Controls.Add(getLocationButton);

            locationFoundLabel = new Label()
            {
                Text = "Location found:",
                Font = CustomFontCollection.GetMontserrat(12, FontStyle.Bold),
                ForeColor = Color.LightGray,
                AutoSize = true,
                Location = new Point(30, 540),
                Visible = false
            };

            mainPanel.Controls.Add(locationFoundLabel);

            saveButton = new Button()
            {
                Text = "Save",
                Location = new Point(30, 580),
                Size = new Size(135, 40),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = CustomFontCollection.GetMontserrat(10, FontStyle.Bold),
            };

            saveButton.FlatAppearance.BorderSize = 0;
            
            saveButton.Click += SaveButtonOnClick;

            mainPanel.Controls.Add(saveButton);

            closeButton = new Button()
            {
                Text = "Close",
                Location = new Point(185, 580),
                Size = new Size(135, 40),
                BackColor = Color.FromArgb(70, 70, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = CustomFontCollection.GetMontserrat(10, FontStyle.Bold),
            };
            
            closeButton.Click += CloseButtonOnClick;

            closeButton.FlatAppearance.BorderSize = 0;

            mainPanel.Controls.Add(closeButton);
        }

        #endregion
    }
}