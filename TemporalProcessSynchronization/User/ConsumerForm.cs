using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Base;
using MeasureValue = Base.MeasureValue;

namespace User
{
    public partial class ConsumerForm : Form, Base.IObserver<MeasureValue>
    {
        private bool isConsuming = false;
        private bool hasSubscriptions = false;

        private UserWorker worker;

        private readonly HashSet<string> _subscriptions = new HashSet<string>();

        public ConsumerForm()
        {
            worker = new UserWorker();
            worker.Attach(this);

            InitializeComponent();

            btnStop.Enabled = false;
            btnStart.Enabled = false;
        }

        private void setButtonsState()
        {
            hasSubscriptions = _subscriptions.Count > 0;
            btnStart.Enabled = !isConsuming && hasSubscriptions;
            btnStop.Enabled = isConsuming;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            isConsuming = true;
            setButtonsState();
            subscriptionStatus.ForeColor = Color.Green;
            subscriptionStatus.Text = "Subscribed";
            worker.Subscriptions = _subscriptions.ToArray();
            worker.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            isConsuming = false;
            setButtonsState();
            subscriptionStatus.ForeColor = Color.DarkRed;
            subscriptionStatus.Text = "Not subscribed";
            worker.Stop();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listMeasures.Items.Clear();
        }

        public void Update(MeasureValue value)
        {
            Invoke(new Action(() =>
            {
                var item = new ListViewItem(value.GetTimeStamp());
                item.BackColor = CommonManager.GetColorForStatus(value.Status);
                item.SubItems.Add(value.GetStringValue());
                item.SubItems.Add(value.Status);
                listMeasures.Items.Add(item);
                listMeasures.EnsureVisible(listMeasures.Items.Count - 1);
            }));
        }

        private void cbxCritical_CheckStateChanged(object sender, EventArgs e)
        {
            checkAndUpdateUi((CheckBox)sender, "critical");
        }

        private void cbxWarning_CheckStateChanged(object sender, EventArgs e)
        {
            checkAndUpdateUi((CheckBox)sender, "warning");
        }

        private void cbxNormal_CheckStateChanged(object sender, EventArgs e)
        {
            checkAndUpdateUi((CheckBox)sender, "normal");
        }

        private void checkAndUpdateUi(CheckBox cbx, string subscription)
        {
            var isChecked = cbx.Checked;
            if (isChecked)
            {
                _subscriptions.Add(subscription);
            }
            else
            {
                _subscriptions.Remove(subscription);
            }
            setButtonsState();
        }

        private void ConsumerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            worker.Detach(this);
            worker.Dispose();
        }
    }
}
