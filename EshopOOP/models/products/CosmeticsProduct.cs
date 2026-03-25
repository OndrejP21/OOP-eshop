using EshopOOP.models.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopOOP.models.products
{
    public class CosmeticsProduct : Product
    {
        public TrueFactor Bio { get; private set; }
        public ushort V { get; private set; } // objem v ml
        public ushort ExpirationDays { get; private set; }

        public CosmeticsProduct(int id, ProductType type, string name, uint price, ushort instock, byte dph,
           TrueFactor bio, ushort v, ushort expirationDays) : base(id, type, name, price, instock, dph)
        {
            Bio = bio;
            V = v;
            ExpirationDays = expirationDays;
        }
    }
}
