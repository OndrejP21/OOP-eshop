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

        public ClothesProduct(int id, ProductType type, string name, uint price, ushort instocks, byte dph, 
            string size, Material[] materials) : base(id, type, name, price, instocks, dph)
        {
            Size = size;
            Materials = materials;
        }

        public ClothesProduct(int id, ProductType type, string name, uint price, ushort instocks, byte dph,
    string size, List<Material> materials) : this(id, type, name, price, instocks, dph, size, materials.ToArray())
        {
        }

        public ClothesProduct(int id, ProductType type, string name, uint price, ushort instocks, byte dph,
string size, Material material) : this(id, type, name, price, instocks, dph, size, new Material[] { material })
        {
        }
    }
}
