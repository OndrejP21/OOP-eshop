using EshopOOP.models.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopOOP.models.products
{
    public class ClothesProduct : Product
    {

        public string Size { get; private set; }
        public Material[] Materials { get; private set; }

        public ClothesProduct(int id, ProductType type, string name, uint price, ushort instock, byte dph,
            string size, Material[] materials) : base(id, type, name, price, instock, dph)
        {
            Size = size;
            Materials = materials;
        }

        public ClothesProduct(int id, ProductType type, string name, uint price, ushort instock, byte dph,
            string size, List<Material> materials) : base(id, type, name, price, instock, dph)
        {
            Size = size;
            Materials = materials.ToArray();
        }

        public ClothesProduct(int id, ProductType type, string name, uint price, ushort instock, byte dph,
            string size, Material material) : base(id, type, name, price, instock, dph)
        {
            Size = size;
            Materials = [material];
        }
    }
}
