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
            ProductType type = (ProductType) Enum.Parse(typeof(ProductType), productData[1]);
            string name = productData[2];
            uint price = uint.Parse(productData[3]);
            ushort inStock = ushort.Parse(productData[4]);
            byte dph = byte.Parse(productData[5]);
            string warranty = productData[6];
            string v = productData[10];

            // Kontrola, zda se jedná o elektro product
            if (!string.IsNullOrWhiteSpace(warranty))
            {
                return new ElectroProduct(id, type, name, price, inStock, dph, 
                    byte.Parse(warranty), uint.Parse(productData[7]), uint.Parse(productData[8]));
            } else if (!string.IsNullOrWhiteSpace(v))
            {
                return new CosmeticsProduct(id, type, name, price, inStock, dph,
                    ParseTrueFactor(productData[9]), 
                    ushort.Parse(v), ushort.Parse(productData[11]));
            }
        }

        private static TrueFactor ParseTrueFactor(string enumAsString)
        {
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
