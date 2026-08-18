using Circadia.Forms.Fonts;
using System.Drawing;
using System.Windows.Forms;

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
            this.components = new System.ComponentModel.Container();

            // ============================================================
            // FORM
            // ============================================================

            this.Size = new Size(420, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(18, 18, 24);
            this.Name = "SettingsForm";
            this.Text = "Circadia Settings";

            // ============================================================
            // MAIN PANEL
            // ============================================================

            mainPanel = new Panel()
            {
                Location = new Point(25, 20),
                Size = new Size(350, 640),
                BackColor = Color.FromArgb(30, 30, 40)
            };

            this.Controls.Add(mainPanel);

            // ============================================================
            // TITLE
            // ============================================================

            titleLabel = new Label()
            {
                Text = "Circadia Settings",
                Font = CustomFontCollection.GetMontserrat(14, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(30, 25)
            };

            mainPanel.Controls.Add(titleLabel);

            // ============================================================
            // BRIGHTNESS LIGHT MODE
            // ============================================================

            brightnessLightLabel = new Label()
            {
                Text = "Brightness Light Mode",
                Font = CustomFontCollection.GetMontserrat(10, FontStyle.Regular),
                ForeColor = Color.LightGray,
                AutoSize = true,
                Location = new Point(30, 75)
            };

            mainPanel.Controls.Add(brightnessLightLabel);

            brightnessLightBar = new TrackBar()
            {
                Location = new Point(25, 105),
                Width = 300,
                Minimum = 0,
                Maximum = 100,
                Value = 80,
                TickFrequency = 10,
                SmallChange = 1,
                LargeChange = 10
            };

            brightnessLightBar.ValueChanged += BrightnessLightBarOnValueChanged;
            brightnessLightBar.Scroll += BrightnessBarShowcaseBrightness;
            brightnessLightBar.MouseUp += BrightnessBarSetOriginalBrightness;

            mainPanel.Controls.Add(brightnessLightBar);

            brightnessLightValue = new Label()
            {
                Text = "80%",
                Font = CustomFontCollection.GetMontserrat(10, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(158, 150)
            };

            mainPanel.Controls.Add(brightnessLightValue);

            // ============================================================
            // BRIGHTNESS DARK MODE
            // ============================================================

            brightnessDarkLabel = new Label()
            {
                Text = "Brightness Dark Mode",
                Font = CustomFontCollection.GetMontserrat(10, FontStyle.Regular),
                ForeColor = Color.LightGray,
                AutoSize = true,
                Location = new Point(30, 175)
            };

            mainPanel.Controls.Add(brightnessDarkLabel);

            brightnessDarkBar = new TrackBar()
            {
                Location = new Point(25, 205),
                Width = 300,
                Minimum = 0,
                Maximum = 100,
                Value = 50,
                TickFrequency = 10,
                SmallChange = 1,
                LargeChange = 10
            };

            brightnessDarkBar.ValueChanged += BrightnessDarkBarOnValueChanged;
            brightnessDarkBar.Scroll += BrightnessBarShowcaseBrightness;
            brightnessDarkBar.MouseUp += BrightnessBarSetOriginalBrightness;

            mainPanel.Controls.Add(brightnessDarkBar);

            brightnessDarkValue = new Label()
            {
                Text = "50%",
                Font = CustomFontCollection.GetMontserrat(10, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(158, 250)
            };

            mainPanel.Controls.Add(brightnessDarkValue);

            // ============================================================
            // BLUE LIGHT
            // ============================================================

            blueLightLabel = new Label()
            {
                Text = "Blue Light Intensity",
                Font = CustomFontCollection.GetMontserrat(10, FontStyle.Regular),
                ForeColor = Color.LightGray,
                AutoSize = true,
                Location = new Point(30, 275)
            };

            mainPanel.Controls.Add(blueLightLabel);

            blueLightBar = new TrackBar()
            {
                Location = new Point(25, 305),
                Width = 300,
                Minimum = 0,
                Maximum = 100,
                Value = 50,
                TickFrequency = 10,
                SmallChange = 1,
                LargeChange = 10
            };

            blueLightBar.ValueChanged += BrightnessBarShowcaseBrightness;

            mainPanel.Controls.Add(blueLightBar);

            blueLightValue = new Label()
            {
                Text = "50%",
                Font = CustomFontCollection.GetMontserrat(10, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(158, 350)
            };

            mainPanel.Controls.Add(blueLightValue);

            // ============================================================
            // DARK MODE TIME
            // ============================================================

            timeFromLabel = new Label()
            {
                Text = "Dark Mode from",
                ForeColor = Color.LightGray,
                Font = CustomFontCollection.GetMontserrat(10, FontStyle.Regular),
                AutoSize = true,
                Location = new Point(30, 375)
            };

            mainPanel.Controls.Add(timeFromLabel);

            timeFromCombo = new ComboBox()
            {
                Location = new Point(30, 405),
                Width = 125,
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.White,
                Font = CustomFontCollection.GetMontserrat(9, FontStyle.Regular)
            };

            for (int i = 0; i < 24; i++)
            {
                timeFromCombo.Items.Add($"{i:00}:00");
            }

            timeFromCombo.SelectedIndex = 10;
            timeFromCombo.SelectedValueChanged += TimeFromComboOnSelectedValueChanged;

            mainPanel.Controls.Add(timeFromCombo);

            // ============================================================
            // DARK MODE TO
            // ============================================================

            timeToLabel = new Label()
            {
                Text = "Dark Mode to",
                ForeColor = Color.LightGray,
                Font = CustomFontCollection.GetMontserrat(10, FontStyle.Regular),
                AutoSize = true,
                Location = new Point(195, 375)
            };

            mainPanel.Controls.Add(timeToLabel);

            timeToCombo = new ComboBox()
            {
                Location = new Point(195, 405),
                Width = 125,
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.White,
                Font = CustomFontCollection.GetMontserrat(9, FontStyle.Regular)
            };

            for (int i = 0; i < 24; i++)
            {
                timeToCombo.Items.Add($"{i:00}:00");
            }

            timeToCombo.SelectedIndex = 8;
            timeToCombo.SelectedValueChanged += TimeToComboOnSelectedValueChanged;

            mainPanel.Controls.Add(timeToCombo);

            // ============================================================
            // LOCATION BUTTON
            // ============================================================

            locationButton = new Button()
            {
                Text = "Choose Location",
                Location = new Point(30, 460),
                Size = new Size(290, 42),
                BackColor = Color.FromArgb(45, 45, 58),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = CustomFontCollection.GetMontserrat(10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            locationButton.FlatAppearance.BorderSize = 0;
            locationButton.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(55, 55, 70);

            locationButton.FlatAppearance.MouseDownBackColor =
                Color.FromArgb(35, 35, 48);

            locationButton.Click += LocationButtonOnClick;

            mainPanel.Controls.Add(locationButton);

            // ============================================================
            // LOCATION LABEL
            // ============================================================

            locationLabel = new Label()
            {
                Text = "Location:",
                ForeColor = Color.LightGray,
                Font = CustomFontCollection.GetMontserrat(9, FontStyle.Regular),
                AutoSize = true,
                Location = new Point(30, 510)
            };

            mainPanel.Controls.Add(locationLabel);

            // ============================================================
            // SAVE BUTTON
            // ============================================================

            saveButton = new Button()
            {
                Text = "Save",
                Location = new Point(30, 545),
                Size = new Size(135, 42),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = CustomFontCollection.GetMontserrat(10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            saveButton.FlatAppearance.BorderSize = 0;

            saveButton.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(0, 140, 235);

            saveButton.FlatAppearance.MouseDownBackColor =
                Color.FromArgb(0, 100, 190);

            saveButton.Click += SaveButtonOnClick;

            mainPanel.Controls.Add(saveButton);

            // ============================================================
            // CLOSE BUTTON
            // ============================================================

            closeButton = new Button()
            {
                Text = "Close",
                Location = new Point(185, 545),
                Size = new Size(135, 42),
                BackColor = Color.FromArgb(70, 70, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = CustomFontCollection.GetMontserrat(10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            closeButton.FlatAppearance.BorderSize = 0;

            closeButton.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(85, 85, 95);

            closeButton.FlatAppearance.MouseDownBackColor =
                Color.FromArgb(55, 55, 65);

            closeButton.Click += CloseButtonOnClick;

            mainPanel.Controls.Add(closeButton);
        }

        #endregion
    }
}