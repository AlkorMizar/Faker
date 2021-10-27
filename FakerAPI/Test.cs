using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerAPI
{
    class ListElem {
        short _short;
        private int _int;
        private float _float;
        private ushort _ushort;
        public ushort _Ushort { 
            get { return _ushort; }
            set { _ushort = value; }
        }

        private ListElem(short __short, float __float, decimal _decimal) {
            Console.WriteLine("Can\'t call ListElem(short, float, decimal)");
        }

        public ListElem(short __short,float __float) {
            Console.WriteLine("Used ListElem(short,float)");
            _short = __short;
            _float = __float;
        }
        public ListElem(short __short)
        {
            Console.WriteLine("Used ListElem(short)");
        }

        public ListElem()
        {
            Console.WriteLine("Used ListElem(short)");
        }

        public override string ToString()
        {
            return $"ListElem\n  short:{_short};never init int:{_int};float:{_float};ushort:{_ushort};prop ushort:{_Ushort}";
        }
    }
    class Class {
        public DateTime _dateTime;
        public Struct _struct;
        private List<ListElem> _list;
        public List<ListElem> _List { 
            get { return _list; }
            set { _list = value; }
        }
        private Enum[,] _array;
        public double _Double { get; set; }
        public Class(Enum[,] __array) {
            _array = __array;
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("enum array[,]\n");
            for (int i = 0; i < _array.GetLength(0); i++)
            {
                for (int j = 0; j < _array.GetLength(1); j++)
                {
                    builder.Append($"[{i},{j}]={_array[i, j]} ");
                }
                builder.Append("\n");
            }
            builder.Append("field list of ListElem\n");
            foreach (var item in _list)
            {
                builder.Append($" {item.ToString()}\n");
            }
            builder.Append("Property list of ListElem\n");
            foreach (var item in _list)
            {
                builder.Append($" {item.ToString()}\n");
            }
            builder.Append("struct " + _struct + "\n");
            builder.Append("Double " + _Double + "\n");
            builder.Append("DateTime" + _dateTime + "\n");
            return builder.ToString();
        }
    }

    struct Struct {
        Enum _enum;
        ulong _ulong;
        private bool _bool;
        public sbyte _sbyte { get; private set; }
        public readonly char _char;
        public Struct(ulong __ulong,Enum __enum,bool __bool,sbyte __sbyte,char __char) {
            _ulong = __ulong;
            _enum = __enum;
            _bool = __bool;
            _sbyte = __sbyte;
            _char =(char) (__char%256);
        }

        override public string ToString()
        {
            return $"struct Struct\n  enum: {_enum} ;ulong: {_ulong} ;bool: {_bool} ;sbyte: {_sbyte} ; char: {_char}";
        }
    }

    public enum Enum { 
        ROSE=-1,
        WHITE=100,
        DOG,
        TREE,
        Gogy=0,
        CHECK,
        PETTY,
        SPAGETTY,
        WHILE,
        TABLE
    }

    public interface IItMe {
        string getName();
        IItMe GetNext();
    }
    public class A : IItMe{
        public B b;
        public A() { }

        public string getName()
        {
            return "A\n";
        }

        public IItMe GetNext()
        {
            return b;
        }

        public override string ToString()
        {
            return getName()+ (b != null ? b.ToString() : "");
        }
    }

    public class B : IItMe
    {
        public C c;
        public B() { }

        public string getName()
        {
            return "\tB\n";
        }

        public IItMe GetNext()
        {
            return c;
        }

        public override string ToString()
        {
            return getName() + (c != null ? c.ToString() : "");
        }
    }

    public class C : IItMe
    {
        public A a;
        public C() { }
        public string getName()
        {
            return "\t\tC\n";
        }

        public IItMe GetNext()
        {
            return a;
        }

        public override string ToString()
        {
            return getName() +(a!=null ? a.ToString():"");
        }
    }

    class User
    {
        public string name;
        public int age;
        public float money = 10.5f;
        public Dog[] dogs;
        public Profile profile;
    }

    class Dog
    {
        private Dog() { }
        string name;
        public User owner;
    }

    class Profile
    {
        public string address;
        public Profile() { }
        public Profile(int c) { }
    }
}
