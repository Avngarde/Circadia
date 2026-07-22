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

        private Label brightnessLabel;
        private TrackBar brightnessBar;
        private Label brightnessValue;

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
