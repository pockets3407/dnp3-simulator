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

namespace Automatak.Simulator.DNP3
{
    public partial class CROBControl : UserControl
    {
        public CROBControl()
        {
            InitializeComponent();

            this.comboBoxCode.DataSource = Enum.GetValues(typeof(OperationType));
        }

        private IndexedValue<ControlRelayOutputBlock> ControlValue
        {
            get
            {
                var code = (OperationType)this.comboBoxCode.SelectedItem;
                var count = Convert.ToByte(this.numericUpDownCount.Value);
                var onTime = Convert.ToUInt32(this.numericUpDownOnTime.Value);
                var offTime = Convert.ToUInt32(this.numericUpDownOffTime.Value);
                var crob = new ControlRelayOutputBlock(code, TripCloseCode.NUL, false, count, onTime, offTime);
                var index = Convert.ToUInt16(this.numericUpDownIndex.Value);
                return IndexedValue.From(crob, index);
            }
        }

        public Func<ICommandProcessor, Task<CommandTaskResult>> DirectOperateAction
        { 
            get {
                var crob = ControlValue;
                return (ICommandProcessor cp) => cp.DirectOperate(crob.Value, crob.Index, TaskConfig.Default);
            }
        }

        public Func<ICommandProcessor, Task<CommandTaskResult>>  SelectAndOperateAction
        {
            get
            {
                var crob = ControlValue;
                return (ICommandProcessor cp) => cp.SelectAndOperate(crob.Value, crob.Index, TaskConfig.Default);
            }
        }
    }
}
