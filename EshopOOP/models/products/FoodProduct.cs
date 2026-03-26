using EshopOOP.models.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopOOP.models.products
{
    public class FoodProduct : Product
    {
        public TrueFactor Bio { get; private set; }
        public ushort ExpirationDays { get; private set; }

        public FoodProduct(int id, ProductType type, string name, uint price, ushort instocks, byte dph, 
            TrueFactor bio, ushort expirationDays) : base(id, type, name, price, instocks, dph)
        {
            Bio = bio;
            ExpirationDays = expirationDays;
        }
    }
}
