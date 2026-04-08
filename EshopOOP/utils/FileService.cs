using EshopOOP.models;
using EshopOOP.models.enums;
using EshopOOP.models.products;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EshopOOP.utils
{
    public static class FileService
    {

        private static Product CreateProductObject(string line)
        {
            string[] productData = line.Split(';');

            // Neřešíme tryparse, protože soubor bude vždy platný
            int id = int.Parse(productData[0]);
            ProductType type = Enum.Parse<ProductType>(productData[1]);
            string name = productData[2];
            uint price = uint.Parse(productData[3]);
            ushort inStock = ushort.Parse(productData[4]);
            byte dph = byte.Parse(productData[5]);
            string warranty = productData[6];
            string bio = productData[9];
            string v = productData[10];
            string expiration = productData[11];
            string size = productData[12];

            // TODO: Připravit u produktů nové konstruktory, které přijímají obecný produkt
            // Kontrola, zda se jedná o elektro product
            if (!string.IsNullOrWhiteSpace(warranty))
            {
                return new ElectroProduct(id, type, name, price, inStock, dph, 
                    byte.Parse(warranty), uint.Parse(productData[7]), uint.Parse(productData[8]));
                // Kosmetika (musí obsahovat objem)
            }
            
            if (!string.IsNullOrWhiteSpace(v))
            {
                return new CosmeticsProduct(id, type, name, price, inStock, dph,
                    ParseTrueFactor(bio), 
                    ushort.Parse(v), ushort.Parse(expiration));
                // Potravina (nesmí obsahovat objem, ale musí obsahovat bio)
            }
            
            if (!string.IsNullOrWhiteSpace(bio) /* kontrolujeme předchozím ifem: && string.IsNullOrWhiteSpace(v)*/)
            {
                return new FoodProduct(id, type, name, price, inStock, dph, 
                    ParseTrueFactor(bio), ushort.Parse(expiration));
            }
            
            if (!string.IsNullOrWhiteSpace(size))
            {
                string[] materialsString = productData[13].Split('/');

                List<Material> materials = new List<Material>();
                foreach (string material in materialsString) {
                    materials.Add(Enum.Parse<Material>(material));
                }

                return new ClothesProduct(id, type, name, price, inStock, dph, size, materials);
            }

            return new BookProduct(id, type, name, price, inStock, dph,
                    productData[14], ushort.Parse(productData[15]));
        }

        private static TrueFactor ParseTrueFactor(string enumAsString)
        {
            // Druhá možnost přetypování bez generického typu v <>
            return (TrueFactor) Enum.Parse(typeof(TrueFactor), enumAsString);
        }

        private static string[] ReadLines(string filePath)
        {
            List<object> objects = new();
            bool isFirst = true;
            FileType? fileType = null;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string? line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    if (isFirst)
                    {
                        fileType = GetFileType(line);

                        // Pokud by se jednalo o neplatný soubor = KONEC
                        if (fileType == null)
                            break;

                        isFirst = false;

                        continue;
                    }

                    switch (fileType)
                    {
                        case FileType.ProductFile:

                            break;
                        case FileType.EmployeeFile:
                            break;
                    }
                }
            }

            return [];
        }

        private static FileType? GetFileType(string firstLine)
        {
            // Máme pouze dva soubory, ve kterých se liší hned druhý sloupec => stačí kontrolovat zatím podle toho
            string[] headers = firstLine.Split(';');

            if (headers.Length > 2)
            {
                string secondHeader = headers[1].Trim();
                if (secondHeader == Constants.PRODUCT_FILE_HEADERS[1] && headers.Length == Constants.PRODUCT_FILE_HEADERS.Length)
                    return FileType.ProductFile;

                if (secondHeader == Constants.EMPLOYEE_FILE_HEADER[1] && headers.Length == Constants.EMPLOYEE_FILE_HEADER.Length)
                    return FileType.EmployeeFile;
            }

            return null;
        }
    }
}
