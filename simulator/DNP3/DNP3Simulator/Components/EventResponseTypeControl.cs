using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Automatak.DNP3.Interface;

namespace Automatak.Simulator.DNP3.Components
{
    public partial class EventResponseTypeControl : ResponseTypeControl
    {
        public EventResponseTypeControl()
        {
            InitializeComponent();

            this.ComboBoxBinary.DataSource = Enum.GetValues(typeof(EventBinaryVariation));
            this.ComboBoxDoubleBinary.DataSource = Enum.GetValues(typeof(EventDoubleBinaryVariation));
            this.ComboBoxCounter.DataSource = Enum.GetValues(typeof(EventCounterVariation));
            this.ComboBoxFrozenCounter.DataSource = Enum.GetValues(typeof(EventFrozenCounterVariation));
            this.ComboBoxAnalog.DataSource = Enum.GetValues(typeof(EventAnalogVariation));
            this.ComboBoxBinaryOutputStatus.DataSource = Enum.GetValues(typeof(EventBinaryOutputStatusVariation));
            this.ComboBoxAnalogOutputStatus.DataSource = Enum.GetValues(typeof(EventAnalogOutputStatusVariation));
        }

        // TODO remove this
        public void Configure(DatabaseTemplate template)
        {
            foreach (var record in template.binary) record.Value.eventVariation = (EventBinaryVariation)this.ComboBoxBinary.SelectedItem;
            foreach (var record in template.binaryOutputStatus) record.Value.eventVariation = (EventBinaryOutputStatusVariation)this.ComboBoxBinaryOutputStatus.SelectedItem;
            foreach (var record in template.doubleBinary) record.Value.eventVariation = (EventDoubleBinaryVariation)this.ComboBoxDoubleBinary.SelectedItem;
            foreach (var record in template.counter) record.Value.eventVariation = (EventCounterVariation)ComboBoxCounter.SelectedItem;
            foreach (var record in template.frozenCounter) record.Value.eventVariation = (EventFrozenCounterVariation)ComboBoxCounter.SelectedItem;
            foreach (var record in template.analog) record.Value.eventVariation = (EventAnalogVariation)ComboBoxAnalog.SelectedItem;
            foreach (var record in template.analogOutputStatus) record.Value.eventVariation = (EventAnalogOutputStatusVariation)ComboBoxAnalogOutputStatus.SelectedItem;
        }
    }
}
