using Circadia.Forms.Fonts;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using Circadia.Custom;
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
            // ============================================================
            // COLORS
            // ============================================================

            Color background = Color.FromArgb(12, 13, 18);
            Color surface = Color.FromArgb(20, 22, 30);
            Color surfaceLight = Color.FromArgb(26, 29, 39);
            Color border = Color.FromArgb(42, 45, 58);

            Color white = Color.FromArgb(245, 247, 250);
            Color secondary = Color.FromArgb(155, 160, 175);
            Color accent = Color.FromArgb(90, 130, 255);
            Color accentHover = Color.FromArgb(110, 145, 255);

            // ============================================================
            // FORM
            // ============================================================

            this.SuspendLayout();

            this.Size = new Size(480, 790);
            this.MinimumSize = new Size(480, 790);
            this.MaximumSize = new Size(480, 790);

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.BackColor = background;
            this.Name = "Circadia Settings";
            this.Text = "Circadia Settings";
            this.DoubleBuffered = true;

            // ============================================================
            // MAIN CONTAINER
            // ============================================================

            mainPanel = new Panel()
            {
                Location = new Point(15, 15),
                Size = new Size(430, 710),
                BackColor = background
            };

            mainPanel.Paint += (sender, e) =>
            {
                using Pen pen = new Pen(border, 1);

                Rectangle rect = new Rectangle(
                    0,
                    0,
                    mainPanel.Width - 1,
                    mainPanel.Height - 1
                );

                using GraphicsPath path = CustomComponents.RoundedRect(
                    rect,
                    22
                );

                e.Graphics.SmoothingMode =
                    System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                e.Graphics.DrawPath(pen, path);
            };

            this.Controls.Add(mainPanel);

            // ============================================================
            // HEADER
            // ============================================================

            titleLabel = new Label()
            {
                Text = "Circadia",
                Font = CustomFontCollection.GetMontserrat(
                    20,
                    FontStyle.Bold
                ),
                ForeColor = white,
                AutoSize = true,
                Location = new Point(32, 28),
                BackColor = Color.Transparent
            };

            mainPanel.Controls.Add(titleLabel);

            Label settingsLabel = new Label()
            {
                Text = "SETTINGS",
                Font = CustomFontCollection.GetMontserrat(
                    8,
                    FontStyle.Bold
                ),
                ForeColor = accent,
                AutoSize = true,
                Location = new Point(34, 58),
                BackColor = Color.Transparent
            };

            mainPanel.Controls.Add(settingsLabel);

            Label descriptionLabel = new Label()
            {
                Text = "Customize your experience",
                Font = CustomFontCollection.GetMontserrat(
                    9,
                    FontStyle.Regular
                ),
                ForeColor = secondary,
                AutoSize = true,
                Location = new Point(32, 82),
                BackColor = Color.Transparent
            };

            mainPanel.Controls.Add(descriptionLabel);

            // ============================================================
            // DISPLAY CARD
            // ============================================================

            Panel displayCard = CustomComponents.CreateCard(
                new Point(25, 115),
                new Size(380, 265),
                surface,
                border
            );

            mainPanel.Controls.Add(displayCard);

            Label displayTitle = new Label()
            {
                Text = "DISPLAY",
                Font = CustomFontCollection.GetMontserrat(
                    9,
                    FontStyle.Bold
                ),
                ForeColor = accent,
                AutoSize = true,
                Location = new Point(20, 18),
                BackColor = Color.Transparent
            };

            displayCard.Controls.Add(displayTitle);

            // ------------------------------------------------------------
            // LIGHT MODE
            // ------------------------------------------------------------

            brightnessLightLabel = new Label()
            {
                Text = "Light mode brightness",
                Font = CustomFontCollection.GetMontserrat(
                    9,
                    FontStyle.Regular
                ),
                ForeColor = white,
                AutoSize = true,
                Location = new Point(20, 48),
                BackColor = Color.Transparent
            };

            displayCard.Controls.Add(brightnessLightLabel);

            brightnessLightBar = CustomComponents.CreateTrackBar();
            brightnessLightBar.Location = new Point(17, 73);
            brightnessLightBar.Width = 270;
            brightnessLightBar.Minimum = 0;
            brightnessLightBar.Maximum = 100;
            brightnessLightBar.Value = 80;
            brightnessLightBar.TickFrequency = 10;

            brightnessLightBar.ValueChanged +=
                BrightnessLightBarOnValueChanged;

            brightnessLightBar.Scroll +=
                BrightnessBarShowcaseBrightness;

            brightnessLightBar.MouseUp +=
                BrightnessBarSetOriginalBrightness;

            displayCard.Controls.Add(brightnessLightBar);

            brightnessLightValue = CustomComponents.CreateValueLabel(
                "80%",
                accent
            );

            brightnessLightValue.Location =
                new Point(315, 74);

            displayCard.Controls.Add(brightnessLightValue);

            // ------------------------------------------------------------
            // DARK MODE
            // ------------------------------------------------------------

            brightnessDarkLabel = new Label()
            {
                Text = "Dark mode brightness",
                Font = CustomFontCollection.GetMontserrat(
                    9,
                    FontStyle.Regular
                ),
                ForeColor = white,
                AutoSize = true,
                Location = new Point(20, 118),
                BackColor = Color.Transparent
            };

            displayCard.Controls.Add(brightnessDarkLabel);

            brightnessDarkBar = CustomComponents.CreateTrackBar();
            brightnessDarkBar.Location = new Point(17, 143);
            brightnessDarkBar.Width = 270;
            brightnessDarkBar.Minimum = 0;
            brightnessDarkBar.Maximum = 100;
            brightnessDarkBar.Value = 50;
            brightnessDarkBar.TickFrequency = 10;

            brightnessDarkBar.ValueChanged +=
                BrightnessDarkBarOnValueChanged;

            brightnessDarkBar.Scroll +=
                BrightnessBarShowcaseBrightness;

            brightnessDarkBar.MouseUp +=
                BrightnessBarSetOriginalBrightness;

            displayCard.Controls.Add(brightnessDarkBar);

            brightnessDarkValue = CustomComponents.CreateValueLabel(
                "50%",
                accent
            );

            brightnessDarkValue.Location =
                new Point(315, 144);

            displayCard.Controls.Add(brightnessDarkValue);

            // ------------------------------------------------------------
            // BLUE LIGHT
            // ------------------------------------------------------------

            blueLightLabel = new Label()
            {
                Text = "Blue light filter",
                Font = CustomFontCollection.GetMontserrat(
                    9,
                    FontStyle.Regular
                ),
                ForeColor = white,
                AutoSize = true,
                Location = new Point(20, 188),
                BackColor = Color.Transparent
            };

            displayCard.Controls.Add(blueLightLabel);

            blueLightBar = CustomComponents.CreateTrackBar();
            blueLightBar.Location = new Point(17, 213);
            blueLightBar.Width = 270;
            blueLightBar.Minimum = 0;
            blueLightBar.Maximum = 100;
            blueLightBar.Value = 0;
            blueLightBar.TickFrequency = 10;

            blueLightBar.ValueChanged +=
                BlueLightBarOnValueChanged;

            blueLightBar.Scroll +=
                BlueLightBarOnScroll;

            blueLightBar.MouseUp +=
                BlueLightBarOnMouseUp;

            displayCard.Controls.Add(blueLightBar);

            blueLightValue = CustomComponents.CreateValueLabel(
                "0%",
                Color.FromArgb(100, 170, 255)
            );

            blueLightValue.Location =
                new Point(315, 214);

            displayCard.Controls.Add(blueLightValue);

            // ============================================================
            // SCHEDULE CARD
            // ============================================================

            Panel scheduleCard = CustomComponents.CreateCard(
                new Point(25, 395),
                new Size(380, 120),
                surface,
                border
            );

            mainPanel.Controls.Add(scheduleCard);

            Label scheduleTitle = new Label()
            {
                Text = "DARK MODE SCHEDULE",
                Font = CustomFontCollection.GetMontserrat(
                    9,
                    FontStyle.Bold
                ),
                ForeColor = accent,
                AutoSize = true,
                Location = new Point(20, 18),
                BackColor = Color.Transparent
            };

            scheduleCard.Controls.Add(scheduleTitle);

            // ------------------------------------------------------------
            // FROM
            // ------------------------------------------------------------

            timeFromLabel = new Label()
            {
                Text = "From",
                Font = CustomFontCollection.GetMontserrat(
                    9,
                    FontStyle.Regular
                ),
                ForeColor = secondary,
                AutoSize = true,
                Location = new Point(20, 50),
                BackColor = Color.Transparent
            };

            scheduleCard.Controls.Add(timeFromLabel);

            timeFromPicker = CustomComponents.CreateTimePicker();
            timeFromPicker.Location =
                new Point(20, 75);

            timeFromPicker.ValueChanged +=
                TimeFromPickerOnValueChanged;

            scheduleCard.Controls.Add(timeFromPicker);

            // ------------------------------------------------------------
            // TO
            // ------------------------------------------------------------

            timeToLabel = new Label()
            {
                Text = "To",
                Font = CustomFontCollection.GetMontserrat(
                    9,
                    FontStyle.Regular
                ),
                ForeColor = secondary,
                AutoSize = true,
                Location = new Point(200, 50),
                BackColor = Color.Transparent
            };

            scheduleCard.Controls.Add(timeToLabel);

            timeToPicker = CustomComponents.CreateTimePicker();
            timeToPicker.Location =
                new Point(200, 75);

            timeToPicker.ValueChanged +=
                TimeToPickerOnValueChanged;

            scheduleCard.Controls.Add(timeToPicker);

            // ============================================================
            // LOCATION BUTTON
            // ============================================================

            getLocationButton = CustomComponents.CreateModernButton(
                "⌖   Use my location",
                accent,
                white
            );

            getLocationButton.Location =
                new Point(25, 527);

            getLocationButton.Size =
                new Size(380, 43);

            getLocationButton.Click +=
                GetLocationButtonOnClick;

            mainPanel.Controls.Add(getLocationButton);

            // ============================================================
            // LOCATION STATUS
            // ============================================================

            Panel locationCard = CustomComponents.CreateCard(
                new Point(25, 585),
                new Size(380, 52),
                surfaceLight,
                border
            );

            mainPanel.Controls.Add(locationCard);

            locationFoundLabel = new Label()
            {
                Text = "●  Location not set",
                Font = CustomFontCollection.GetMontserrat(
                    8.5f,
                    FontStyle.Regular
                ),
                ForeColor = secondary,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill,
                Padding = new Padding(17, 0, 0, 0),
                BackColor = Color.Transparent
            };

            locationCard.Controls.Add(locationFoundLabel);

            // ============================================================
            // BOTTOM BUTTONS
            // ============================================================

            saveButton = CustomComponents.CreateModernButton(
                "Save changes",
                accent,
                white
            );

            saveButton.Location =
                new Point(25, 650);

            saveButton.Size =
                new Size(183, 42);

            saveButton.Click +=
                SaveButtonOnClick;

            mainPanel.Controls.Add(saveButton);

            closeButton = CustomComponents.CreateModernButton(
                "Close",
                surfaceLight,
                secondary
            );

            closeButton.Location =
                new Point(222, 650);

            closeButton.Size =
                new Size(183, 42);

            closeButton.Click +=
                CloseButtonOnClick;

            mainPanel.Controls.Add(closeButton);

            // ============================================================
            // FORM ANIMATION
            // ============================================================

            this.Shown += SettingsFormOnShown;

            this.ResumeLayout(false);
        }
}
}
#endregion