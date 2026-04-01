using EshopOOP.models.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopOOP.utils
{
    public static class Constants
    {
    // const pro pole => z důvodu kompilace referenčních datových typů
    public static readonly string[] PRODUCT_FILE_HEADERS = new string[] { "id","typ_produktu","nazev", "cena_kc", "skladem_kusu", "dph_procent", "zaruka_mesice", 
    "vykon_w", "napeti_v","bio", "objem_ml","expirace_dni","velikost","material","autor", "pocet_stran" };

        // Druhá možnost vytvoření pole
    public static readonly string[] EMPLOYEE_FILE_HEADER = ["id","typ_osoby", "jmeno", "oddeleni","datum_nastupu", "zaklad_mzda_kc","uvazek", 
    "hodinova_mzda_kc","odpracovane_hodiny_mesic","bonus_kc","pocet_podrizenych", "ma_sluzebni_auto" ];
    }
}
