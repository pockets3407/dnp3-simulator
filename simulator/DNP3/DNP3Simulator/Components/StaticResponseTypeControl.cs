﻿using System;
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
    public partial class StaticResponseTypeControl : ResponseTypeControl
    {
        public StaticResponseTypeControl()
        {
            InitializeComponent();

            this.ComboBoxBinary.DataSource = Enum.GetValues(typeof(StaticBinaryVariation));
            this.ComboBoxDoubleBinary.DataSource = Enum.GetValues(typeof(StaticDoubleBinaryVariation));
            this.ComboBoxCounter.DataSource = Enum.GetValues(typeof(StaticCounterVariation));
            this.ComboBoxFrozenCounter.DataSource = Enum.GetValues(typeof(StaticFrozenCounterVariation));
            this.ComboBoxAnalog.DataSource = Enum.GetValues(typeof(StaticAnalogVariation));
            this.ComboBoxBinaryOutputStatus.DataSource = Enum.GetValues(typeof(StaticBinaryOutputStatusVariation));
            this.ComboBoxAnalogOutputStatus.DataSource = Enum.GetValues(typeof(StaticAnalogOutputStatusVariation));
        }

        // TODO remove this
        public void Configure(DatabaseTemplate template)
        {
            foreach (var record in template.binary) record.Value.staticVariation = (StaticBinaryVariation)this.ComboBoxBinary.SelectedItem;
            foreach (var record in template.binaryOutputStatus) record.Value.staticVariation = (StaticBinaryOutputStatusVariation)this.ComboBoxBinaryOutputStatus.SelectedItem;
            foreach (var record in template.doubleBinary) record.Value.staticVariation = (StaticDoubleBinaryVariation)this.ComboBoxDoubleBinary.SelectedItem;
            foreach (var record in template.counter) record.Value.staticVariation = (StaticCounterVariation)ComboBoxCounter.SelectedItem;
            foreach (var record in template.frozenCounter) record.Value.staticVariation = (StaticFrozenCounterVariation)ComboBoxCounter.SelectedItem;
            foreach (var record in template.analog) record.Value.staticVariation = (StaticAnalogVariation)ComboBoxAnalog.SelectedItem;
            foreach (var record in template.analogOutputStatus) record.Value.staticVariation = (StaticAnalogOutputStatusVariation)ComboBoxAnalogOutputStatus.SelectedItem;            
        }
    }
}
