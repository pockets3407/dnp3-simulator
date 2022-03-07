using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Automatak.DNP3.Interface;

namespace Automatak.Simulator.DNP3.Components
{
    partial class TemplateDialog : Form
    {                
        public TemplateDialog(string alias, DatabaseTemplate template)
        {
            InitializeComponent();

            this.textBoxAlias.Text = alias;

            Configure(template);
        }

        private void buttonADD_Click(object sender, EventArgs e)
        {            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public String SelectedAlias
        {
            get
            {
                return textBoxAlias.Text;
            }
        }

        public DatabaseTemplate ConfiguredTemplate
        {
            get
            {
                var template = new DatabaseTemplate(0);
                                
                template.binary = templateControlBinary.GetRecords().ToDictionary(kvp => (ushort)kvp.clazz, kvp => new BinaryConfig());
                template.doubleBinary = templateControlDoubleBinary.GetRecords().ToDictionary(kvp => (ushort)kvp.clazz, kvp => new DoubleBinaryConfig());
                template.counter = templateControlCounter.GetRecords().ToDictionary(kvp => (ushort)kvp.clazz, kvp => new CounterConfig());
                template.frozenCounter = templateControlFrozenCounter.GetRecords().ToDictionary(kvp => (ushort)kvp.clazz, kvp => new FrozenCounterConfig());
                template.analog = templateControlAnalog.GetRecords().ToDictionary(kvp => (ushort)kvp.clazz, kvp => new AnalogConfig());
                template.binaryOutputStatus = templateControlBOStatus.GetRecords().ToDictionary(kvp => (ushort)kvp.clazz, kvp => new BinaryOutputStatusConfig());
                template.analogOutputStatus = templateControlAOStatus.GetRecords().ToDictionary(kvp => (ushort)kvp.clazz, kvp => new AnalogOutputStatusConfig());


                return template;
            }
        }

        private void Configure(DatabaseTemplate template)
        {
            this.templateControlAnalog.SetRecords(template.analog.Values);
            this.templateControlAOStatus.SetRecords(template.analogOutputStatus.Values);            
            this.templateControlBinary.SetRecords(template.binary.Values);
            this.templateControlBOStatus.SetRecords(template.binaryOutputStatus.Values);
            this.templateControlCounter.SetRecords(template.counter.Values);
            this.templateControlDoubleBinary.SetRecords(template.doubleBinary.Values);
            this.templateControlFrozenCounter.SetRecords(template.frozenCounter.Values);            
        }
      
    }
}
