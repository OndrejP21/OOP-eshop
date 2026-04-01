using EshopOOP.models.enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EshopOOP.utils
{
    public static class FileService
    {
        private static string[] ReadLines(string filePath)
        {
            List<string> lines = new();
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
