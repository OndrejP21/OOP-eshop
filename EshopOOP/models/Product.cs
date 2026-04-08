using EshopOOP.models.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopOOP.models
{
    public class Product
    {

        public int Id { get; private set; }
        public ProductType Type { get; private set; }
        public string Name { get; private set; }
        public uint Price { get; private set; } // víme z dat, že půjde pouze o celá čísla
        public ushort Instocks { get; private set; }
        public byte Dph { get; private set; }
        public Product(int id, ProductType type, string name, uint price, ushort instocks, byte dph)
        {
            Id = id;
            Type = type;
            Name = name;
            Price = price;
            Instocks = instocks;
            Dph = dph;
        }

        public override string ToString()
        {
            return $"{Type} {Name} {Price} Kč (Skladem: {Instocks}, DPH: {Dph})";
        }
    }
}
