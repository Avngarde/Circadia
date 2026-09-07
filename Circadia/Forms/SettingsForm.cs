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
        
        private Label blueLightLabel;
        private TrackBar blueLightBar;
        private Label blueLightValue;


        private Label timeFromLabel;
        private Label timeToLabel;

        private DateTimePicker timeFromPicker;
        private DateTimePicker timeToPicker;

        private Button saveButton;
        private Button closeButton;

        private Button getLocationButton;
        private Label locationFoundLabel;
        #endregion
        
        #region properties
        private int _brightnessLight;
        private int _brightnessDark;

        private TimeOnly _darkModeFrom;
        private TimeOnly _darkModeTo;

        private int _blueLightValue;

        private uint _originalBrightness;
        private IBrightness _brightness;
        private IBlueLight _blueLight;
        #endregion 

        public SettingsForm()
        {
            InitializeComponent();

            _brightness = new Brightness();
            _blueLight = new BlueLight();

            if (!Settings.SettingsFileExists())
                Settings.CreateDefault();
            
            LoadSettings();
            LoadCurrentBrightness();
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
                BlueLightValue = _blueLightValue
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
            _blueLightValue = settingsValues.BlueLightValue;
            
            brightnessDarkBar.Value = _brightnessDark;
            brightnessLightBar.Value = _brightnessLight;
            blueLightBar.Value = (int)_blueLightValue;
            
            brightnessLightValue.Text = _brightnessLight + "%";
            brightnessDarkValue.Text = _brightnessDark + "%";

            timeFromPicker.Value = DateTime.Parse(settingsValues.DarkModeFrom.ToString());
            timeToPicker.Value = DateTime.Parse(settingsValues.DarkModeTo.ToString());
            
        }

        private void LoadCurrentBrightness() =>
            _originalBrightness = _brightness.GetBrightness();

        private void BrightnessBarShowcaseBrightness(object? sender, EventArgs e)
        {
            var bar = sender as TrackBar;
            
            _brightness.SetBrightness((uint)bar.Value);
        }

        private void BrightnessBarSetOriginalBrightness(object? sender, MouseEventArgs e)
            => _brightness.SetBrightness(_originalBrightness);

        private async void GetLocationButtonOnClick(object? sender, EventArgs e)
        {
            try 
            {
                getLocationButton.Text = "Getting location....";
                
                ILocation location = new IpApiLocation();
                LocationInfo? loc = await location.GetLocation();
                
                getLocationButton.Text = "Set timing from location";

                ISunTime sunTime = new SunTime();
                var timing = await sunTime.GetSunTiming(loc.Lat, loc.Lon);

                timeToPicker.Value = timing.Sunrise;
                timeFromPicker.Value = timing.Sunset;

                locationFoundLabel.Text = $"Location: {loc.Lat} {loc.Lon}";
                locationFoundLabel.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to get location and sun timing", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                getLocationButton.Text = "Set timing from location";
            }
        }

        private void TimeToPickerOnValueChanged(object? sender, EventArgs e)
        {
            var timePicker = sender as DateTimePicker;
            var time = TimeOnly.Parse(timePicker.Value.ToShortTimeString());

            if (time == _darkModeFrom)
            {
                MessageBox.Show(this, "Hours can't be the same", "Settings", MessageBoxButtons.OK);

                timePicker.Value = DateTime.Parse(_darkModeTo.ToShortTimeString()); // Return to previous value

                return;
            }
            
            _darkModeTo = time;
        }

        private void TimeFromPickerOnValueChanged(object? sender, EventArgs e)
        {
            var timePicker = sender as DateTimePicker;
            
            _darkModeFrom = TimeOnly.Parse(timePicker.Value.ToShortTimeString());
        }

        private void BlueLightBarOnValueChanged(object? sender, EventArgs e)
        {
            var trackBar = sender as TrackBar;

            blueLightValue.Text = $"{trackBar.Value}%";
            _blueLightValue = trackBar.Value;
        }

        private void BlueLightBarOnScroll(object? sender, EventArgs e)
        {
            var trackBar = sender as TrackBar;
            
            _blueLight.TurnOn((uint)trackBar.Value);
        }

        private void BlueLightBarOnMouseUp(object? sender, MouseEventArgs e)
            => _blueLight.TurnOff();
    }
}
