using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Circadia.Features;

namespace Circadia.Forms
{
    public partial class SettingsForm : Form
    {
        #region elements
        private Panel mainPanel;
        private Label titleLabel;

        private Label brightnessLightLabel;
        private TrackBar brightnessLightBar;
        private Label brightnessLightValue;
        
        private Label brightnessDarkLabel;
        private TrackBar brightnessDarkBar;
        private Label brightnessDarkValue;

        private Label timeFromLabel;
        private Label timeToLabel;

        private ComboBox timeFromCombo;
        private ComboBox timeToCombo;

        private Button saveButton;
        private Button closeButton;
        #endregion
        
        #region properties
        private int _brightnessLight;
        private int _brightnessDark;

        private TimeOnly _darkModeFrom;
        private TimeOnly _darkModeTo;
        #endregion 

        public SettingsForm()
        {
            InitializeComponent();

            if (!Settings.SettingsFileExists())
                Settings.CreateDefault();
            
            LoadSettings();
        }
        
        private void BrightnessLightBarOnValueChanged(object? sender, EventArgs e)
        {
            var lightBar = sender as TrackBar;
            _brightnessLight = lightBar.Value;
            brightnessLightValue.Text = _brightnessLight + "%";
        }

        private void BrightnessDarkBarOnValueChanged(object? sender, EventArgs e)
        {
            var darkBar = sender as TrackBar;
            _brightnessDark = darkBar.Value;
            brightnessDarkValue.Text = _brightnessDark + "%";
        }

        private void TimeFromComboOnSelectedValueChanged(object? sender, EventArgs e) 
            => _darkModeFrom = ParseTimeFromCombo(sender);

        private void TimeToComboOnSelectedValueChanged(object? sender, EventArgs e)
            => _darkModeTo = ParseTimeFromCombo(sender);
        
        
        private TimeOnly ParseTimeFromCombo(object? sender)
        {
            var combo = sender as ComboBox;
            var value = combo?.SelectedItem as string;
            return TimeOnly.Parse(value);
        }

        private void CloseButtonOnClick(object? sender, EventArgs e)
            => this.Close();

        private void SaveButtonOnClick(object? sender, EventArgs e)
            => SaveSettings();

        private void SaveSettings()
        {
            var values = new SettingsValues()
            {
                DarkModeFrom =  _darkModeFrom,
                DarkModeTo = _darkModeTo,
                BrightnessLight = _brightnessLight,
                BrightnessDark = _brightnessDark,
            };
            
            Settings.Save(values);
            MessageBox.Show(this, "Settings saved successfully", "Settings", MessageBoxButtons.OK);
        }

        private void LoadSettings()
        {
            SettingsValues? settingsValues = Settings.Load();

            if (settingsValues is null)
                return;
            
            _brightnessLight = settingsValues.BrightnessLight;
            _brightnessDark = settingsValues.BrightnessDark;
            _darkModeFrom = settingsValues.DarkModeFrom;
            _darkModeTo = settingsValues.DarkModeTo;
            
            brightnessDarkBar.Value = _brightnessDark;
            brightnessLightBar.Value = _brightnessLight;
            
            brightnessLightValue.Text = _brightnessLight + "%";
            brightnessDarkValue.Text = _brightnessDark + "%";

            timeFromCombo.SelectedItem = settingsValues.DarkModeFrom.ToString();
            timeToCombo.SelectedItem = settingsValues.DarkModeTo.ToString();
        }
    }
}
