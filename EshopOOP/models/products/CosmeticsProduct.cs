using EshopOOP.models.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopOOP.models.products
{
    public class CosmeticsProduct : FoodProduct
    {
        public ushort V { get; private set; } // objem v ml

        public CosmeticsProduct(int id, ProductType type, string name, uint price, ushort instocks, byte dph,
            TrueFactor bio, ushort v, ushort expirationDays) : base(id, type, name, price, instocks, dph, bio, expirationDays)
        {
            V = v;
        }
    }
}
