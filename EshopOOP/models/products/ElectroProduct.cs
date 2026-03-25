using EshopOOP.models.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopOOP.models.products
{
    public class ElectroProduct : Product
    {

        public byte Warranty { get; private set; }
        public uint P { get; private set; } // výkon
        public uint U { get; private set; } // napětí

        public ElectroProduct(int id, ProductType type, string name, uint price, ushort instock, byte dph, 
            byte warranty, uint p, uint u) : base(id, type, name, price, instock, dph)
        {
            Warranty = warranty;
            P = p;
            U = u;
        }

        public ElectroProduct(int id, ProductType type, string name, uint price, ushort instock, byte dph,
    byte warranty, double i, uint u) : base(id, type, name, price, instock, dph)
        {
            Warranty = warranty;
            P = (uint)(u * i); // Dojde k odseknutí desetinné části
            U = u;
        }
    }
}
