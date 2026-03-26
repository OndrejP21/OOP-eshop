using EshopOOP.models.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopOOP.models.products
{
    public class ElectroProduct : Product
    {
        public byte Warranty { get; private set; }
        public uint P { get; private set; } // výkon ve W
        public uint U { get; private set; } // napětí ve V

        public ElectroProduct(int id, ProductType type, string name, uint price, ushort instocks, byte dph,
            byte warrenty, uint p, uint u) : base(id, type, name, price, instocks, dph)
        {
            Warranty = warrenty;
            P = p;
            U = u;
        }

        public ElectroProduct(int id, ProductType type, string name, uint price, ushort instocks, byte dph,
            byte warrenty, double i, uint u) : base(id, type, name, price, instocks, dph)
        {
            Warranty = warrenty;
            P = (uint) (u * i);
            U = u;
        }
    }
}
