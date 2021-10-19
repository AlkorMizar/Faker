using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerAPI
{
    public struct TestStruct
    {
        public int IntProperty { get; set; }
        public short shortField;
        public readonly char charReadOnlY;
        public sbyte _sbyte;
        public byte NumberOfConstructor { get; private set; }
        private byte unInitField;
        public byte UnInitField { get { return unInitField; } }

        private TestStruct(int one, int two, int three, int four, int five, sbyte aaa)
        {
            NumberOfConstructor = 1;
            throw new Exception("You can't call this constructor");
        }

        public TestStruct(int one, int two, int three, int four, sbyte aaa)
        {
            NumberOfConstructor = 2;
            throw new Exception("Error");
        }

        public TestStruct(int one, short t, sbyte aaa)
        {
            IntProperty = one;
            shortField = t;
            unInitField = default(byte);
            NumberOfConstructor = 3;
            charReadOnlY = 'c';
            _sbyte = aaa;
        }
    }

    public class TestClass
    {
        public int IntProperty { get; set; }
        public short shortField;
        public readonly char charReadOnlY;
        public sbyte _sbyte;
        public byte NumberOfConstructor { get; private set; }
        private byte unInitField;
        public byte UnInitField { get { return unInitField; } }

        private TestClass(int one, int two, int three, sbyte aaa)
        {
            NumberOfConstructor = 1;
            throw new Exception("You can't call this constructor");
        }

        public TestClass(int one, int two, sbyte aaa)
        {
            NumberOfConstructor = 2;
            throw new Exception("Error");
        }

        public TestClass(int one, sbyte aaa)
        {
            NumberOfConstructor = 3;
            charReadOnlY = 'c';
            _sbyte = aaa;
        }
    }

    public class ListELemWithStructAndString { 
        public int NumOfConstructor { get; private set; }
        private string str;
        public string Str { get { return str; } }
        public StructWithEnumAndDataTime fieldStruct;
        public StructWithEnumAndDataTime PropertyStruct { get; set; }
        private ListELemWithStructAndString(int one, int two, int three, int four, int five,int six,int seven) {
            NumOfConstructor = 0;
            throw new Exception("You can't call this constructor");
        }
        public ListELemWithStructAndString(int one, int two, int three, int four, int five,int six)
        {
            NumOfConstructor = 1;
            throw new Exception("Error in initialization");
        }

        public ListELemWithStructAndString(int one, int two)
        {
            NumOfConstructor = 2;
        }

        public ListELemWithStructAndString(int one)
        {
            NumOfConstructor = 3;
        }
        public ListELemWithStructAndString(int one, int two, int three, int four, string text)
        {
            NumOfConstructor = 4;
            str = text;
        }
        public ListELemWithStructAndString(int one, int two, int three)
        {
            NumOfConstructor = 5;
        }
    }

    public struct StructWithEnumAndDataTime {
        private EmEnum fieldEnum;
        public EmEnum FieldEnum { get { return fieldEnum; } }

        public DateTime PropertyDateTime { get; set; }
        public readonly byte NumOfConstructor;

        
        private StructWithEnumAndDataTime(int one, int two, int three, int four, int five, int six, int seven)
        {
            NumOfConstructor = 0;
            throw new Exception("You can't call this constructor");
        }
        public StructWithEnumAndDataTime(int one, int two, int three, int four, int five, int six)
        {
            NumOfConstructor = 1;
            throw new Exception("Error in initialization");
        }

        public StructWithEnumAndDataTime(int one, int two)
        {
            fieldEnum = default(EmEnum);
            PropertyDateTime = default(DateTime);
            NumOfConstructor = 2;
        }

        public StructWithEnumAndDataTime(int one)
        {
            fieldEnum = default(EmEnum);
            PropertyDateTime = default(DateTime);
            NumOfConstructor = 3;
        }
        public StructWithEnumAndDataTime(int one, int two, int three, int four, EmEnum text)
        {
            NumOfConstructor = 4;
            fieldEnum = text;
            PropertyDateTime = default(DateTime);
        }
        public StructWithEnumAndDataTime(int one, int two, int three)
        {
            fieldEnum = default(EmEnum);
            PropertyDateTime = default(DateTime);
            NumOfConstructor = 5;
        }


    }
    [Flags]
    public enum EmEnum : sbyte { 
        Apple=-1,
        Banana=10,
        Peach=96,
        Pineapple=-125,
        Orange=127,
        Tomato=-1
    }

    public class A 
    {
        public B b;
        public A() { }

        public string getName()
        {
            return "A";
        }

        public B GetNext()
        {
            return b;
        }

        public override string ToString()
        {
            return getName() + (b != null ? b.ToString() : "");
        }
    }

    public class B 
    {
        public C c;
        public B() { }

        public string getName()
        {
            return "B";
        }

        public C GetNext()
        {
            return c;
        }

        public override string ToString()
        {
            return getName() + (c != null ? c.ToString() : "");
        }
    }

    public class C 
    {
        public A a;
        public C() { }
        public string getName()
        {
            return "C";
        }

        public A GetNext()
        {
            return a;
        }

        public override string ToString()
        {
            return getName() + (a != null ? a.ToString() : "");
        }
    }
}
