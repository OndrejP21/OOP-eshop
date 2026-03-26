using EshopOOP.models.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopOOP.models.products
{
    public class BookProduct : Product
    {
        public string Author { get; private set; }
        public ushort Pages { get; private set; }

        public BookProduct(int id, ProductType type, string name, uint price, ushort instocks, byte dph, 
            string author, ushort pages) : base(id, type, name, price, instocks, dph)
        {
            Author = author;
            Pages = pages;
        }
    }
}
