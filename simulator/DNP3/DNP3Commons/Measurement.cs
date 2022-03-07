﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Automatak.DNP3.Interface;

namespace Automatak.Simulator.DNP3.Commons
{
    public enum MeasType
    {
        Binary,
        DoubleBitBinary,
        Counter,
        FrozenCounter,
        Analog,
        BinaryOutputStatus,
        AnalogOutputStatus,
        OctetString,
        TimeAndInterval
    };

    public class Measurement
    {
        public Measurement(string displayValue, MeasurementBase meas, TimestampQuality tsmode, MeasType type, UInt16 index, IQualityBitInfo info)
        {
            this.valueAsString = displayValue;
            this.timeStamp = (tsmode == TimestampQuality.INVALID) ? DateTime.Now : meas.Timestamp.Value;
            this.tsmode = tsmode;
            this.type = type;
            this.index = index;
            this.info = info;
            this.quality = meas.Quality.Value;
        }

        public Measurement(string displayValue, TimestampQuality tsmode, MeasType type, UInt16 index, IQualityBitInfo info)
        {
            this.valueAsString = displayValue;
            this.timeStamp = DateTime.Now;
            this.tsmode = tsmode;
            this.type = type;
            this.index = index;
            this.info = info;
            this.quality = 0;
        } 

        public ushort Index
        {
            get
            {
                return index;
            }
        }

        public string Value
        {
            get
            {
                return valueAsString;
            }
        }

        public string Flags
        {
            get
            {
                if (QualityInfo.CountOf(quality) > 2)
                {
                    return ShortFlags + " - " + String.Join(", ", QualityInfo.GetShortNames(quality, info));
                }
                else
                {
                    return ShortFlags + " - " + String.Join(", ", QualityInfo.GetLongNames(quality, info));
                }   
            }
        }

        public string ShortFlags
        {
            get
            {
                return "0x" + quality.ToString("X02");
            }
        }

        public string Timestamp
        {
            get
            {
                var time = timeStamp.ToString("d") + timeStamp.ToString(" HH:mm:ss.fff");
                return String.Format("{0} ({1})", time, GetTimeModeString(tsmode));
            }
        }

        private static string GetTimeModeString(TimestampQuality mode)
        {             
            switch(mode)
            {
                case(TimestampQuality.INVALID):
                    return "local timestamp";
                case(TimestampQuality.SYNCHRONIZED):
                    return "synchronized";
                default:
                    return "unsynchronized";
            }            
        }

        public MeasType Type
        {
            get
            {
                return type;
            }
        }
        
        readonly UInt16 index;
        readonly string valueAsString;        
        readonly DateTime timeStamp;
        readonly TimestampQuality tsmode;
        readonly MeasType type;
        readonly IQualityBitInfo info;
        readonly byte quality;
    }
}
