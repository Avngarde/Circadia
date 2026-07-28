using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Circadia.Forms
{
    public partial class SettingsForm : Form
    {
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

        public SettingsForm()
        {
            InitializeComponent();
        }
    }
}
