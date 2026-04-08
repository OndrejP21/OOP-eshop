using EshopOOP.models;
using EshopOOP.models.employees;
using EshopOOP.models.products;
using EshopOOP.utils;
using System.Windows.Forms;

namespace EshopOOP
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV soubory (*.csv)|*.csv";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                object[] objects = FileService.ReadLines(dialog.FileName);

                foreach (object o in objects) {
                    if (o is Product p)
                    {
                        if (p is ElectroProduct ep)
                        {
                            Console.WriteLine(ep);
                        }
                    }

                    if (o is Employee e)
                    {
                        if (e is PartTimer pe)
                        {
                            Console.WriteLine(pe);
                        }
                    }
                }
            } else
            {
                Console.WriteLine("Nevybral jsi žádný soubor!");
            }
        }
    }
}
