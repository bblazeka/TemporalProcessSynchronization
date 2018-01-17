using System;
using System.Drawing;
using System.Windows.Forms;
using Base;
using Base.Interfaces;
using MessageCommunication;

namespace GeigerCounterSystem
{
    public partial class GeigerSystemForm : Form, Base.IObserver<MeasureValue>
    {
        private readonly ISender _sender;
        private bool isCollecting = false;
        private CounterSystem _system;

        public GeigerSystemForm()
        {
            _sender = new Sender(Exchanges.AlertsReceiverExchange, "fanout", "localhost");
            var manager = new MeasurementManager("C:\\Source\\TemporalProcessSynchronization\\measures.txt");
            _system = new CounterSystem(manager, _sender, 1000);
            _system.Attach(this);

            InitializeComponent();

            setButtonsState();
        }

        private void GeigerSystemForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _sender.Dispose();
            _system.Detach(this);
        }

        private void btnStart_Click(object sender, System.EventArgs e)
        {
            isCollecting = true;
           setButtonsState();
            
            _system.StartMeasuring();
            collectionStatus.ForeColor = Color.Green;
            collectionStatus.Text = "Collecting";
        }

        private void setButtonsState()
        {
            btnStart.Enabled = !isCollecting;
            btnStop.Enabled = isCollecting;
        }

        public void Update(MeasureValue value)
        {
            Invoke(new Action(() =>
            {
                var item = new ListViewItem(value.GetTimeStamp());
                item.SubItems.Add(value.GetStringValue());
                item.SubItems.Add(value.Status);
                listMeasures.Items.Add(item);
                listMeasures.EnsureVisible(listMeasures.Items.Count - 1);
            }));
        }

        private void btnStop_Click(object sender, System.EventArgs e)
        {
            isCollecting = false;
            setButtonsState();
            _system.StopMeasuring();
            collectionStatus.ForeColor = Color.DarkRed;
            collectionStatus.Text = "Stopped";
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            listMeasures.Items.Clear();
        }
    }
}
