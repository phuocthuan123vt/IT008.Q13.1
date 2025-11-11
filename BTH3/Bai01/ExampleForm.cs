using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai01
{
    public partial class ExampleForm : Form
    {
        private ListBox _logTarget;
        public ExampleForm(ListBox logListBox)
        {
            InitializeComponent();
            this._logTarget = logListBox;
            this.Load += ExampleWindow_Load;
            this.Shown += ExampleWindow_Shown;
            this.Activated += ExampleWindow_Activated;
            this.Deactivate += ExampleWindow_Deactivate;
            this.FormClosing += ExampleWindow_FormClosing;
            this.FormClosed += ExampleWindow_FormClosed;
        }
        private void LogEvent(string eventName)
        {
            if (_logTarget != null)
            {
                string logMessage = $"[ExampleWindow] - Sự kiện: {eventName}";
                _logTarget.Items.Add(logMessage);

                _logTarget.TopIndex = _logTarget.Items.Count - 1;
            }
        }
        private void ExampleWindow_Load(object sender, EventArgs e)
        {
            LogEvent("Load");
        }

        private void ExampleWindow_Activated(object sender, EventArgs e)
        {
            LogEvent("Activated");
        }

        private void ExampleWindow_Shown(object sender, EventArgs e)
        {
            LogEvent("Shown");
        }

        private void ExampleWindow_Deactivate(object sender, EventArgs e)
        {
            LogEvent("Deactivate");
        }

        private void ExampleWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogEvent("FormClosing");
        }

        private void ExampleWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogEvent("FormClosed");
        }
    }
}
