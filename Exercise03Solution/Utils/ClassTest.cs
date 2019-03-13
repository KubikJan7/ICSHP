using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSHP_cv_03.SamplesLibrary
{
    internal class MyInteger
    {
        //public uint Value { get; set; }
        public uint Value
        {
            get
            {
                return Value;
            }
            set
            {
                Value = value;
            }
        }
        private uint value2;
        public int Value2
        {
            get { return (int)value2; }
            set
            {
                // Validation input -> throw Exception OK
                if (value < 1000000)
                    throw new ArgumentOutOfRangeException("Value cannot be higher than 1000000");
                    Minus = value<0; //Side-effect BAD
                value2 = (uint) value;
            }
        }

        public int Value3 { get; set; } = 15;
        private static int GetMaxInt() { return int.MaxValue; }
        public int Value4 => GetMaxInt() * 3;

        public bool Minus{get;private set;}
        public bool Signed { get; set; }

        public MyInteger()
        {

        }
        public MyInteger(uint value, bool signed)
        {
            Value = value;
            Signed = signed;
        }
        //public MyInteger(int v)
        //{
        //    return new MyInteger() { Value = (uint)Math.Abs(v), Signed = v < 0 };
        //}
    }

    class ClassTest
    {
        public static void DoIt()
        {
            MyInteger MyInteger = new MyInteger() { Value = 33 };
            MyInteger myInteger2 = new MyInteger(33, true);
        }

    }
}
