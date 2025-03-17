using System;
using System.Linq;

class ObdelovalecPodatkov
{
    public static void Main(string[] args)
    {
        
        Console.WriteLine("Vnesite številke ločene z vejicami:"); 
        
        int[] zaporedjeStevil = Console.ReadLine() 
            .Split(',', StringSplitOptions.RemoveEmptyEntries) 
            .Select(x => int.Parse(x.Trim())) 
            .ToArray(); 

        Console.Write("Vnesite iskano število: "); 
        int iskanoStevilo = int.Parse(Console.ReadLine()); 

       
        int prviIndex = IsciPrvi(zaporedjeStevil, iskanoStevilo); 
        int zadnjiIndex = IsciZadnji(zaporedjeStevil, iskanoStevilo); 

        
        Console.WriteLine($"Število {iskanoStevilo} se pojavi v intervalu: [{prviIndex}, {zadnjiIndex}]"); 
    }

    public static int IsciPrvi(int[] podatki, int cilj) 
    {
        int spodnjaMeja = 0, zgornjaMeja = podatki.Length - 1; 
        int rezultat = -1; 

        while (spodnjaMeja <= zgornjaMeja) 
        {
            int sredina = (spodnjaMeja + zgornjaMeja) / 2; 

            if (podatki[sredina] == cilj) 
            {
                rezultat = sredina;
                zgornjaMeja = sredina - 1; 
            }
            else if (podatki[sredina] < cilj) 
            {
                spodnjaMeja = sredina + 1; 
            }
            else
            {
                zgornjaMeja = sredina - 1; 
            }
        }

        return rezultat; 
    }

    public static int IsciZadnji(int[] podatki, int cilj) 
    {
        int spodnjaMeja = 0, zgornjaMeja = podatki.Length - 1;
        int rezultat = -1; 

        while (spodnjaMeja <= zgornjaMeja) 
        {
            int sredina = (spodnjaMeja + zgornjaMeja) / 2; 

            if (podatki[sredina] == cilj) 
            {
                rezultat = sredina; 
                spodnjaMeja = sredina + 1;
            }
            else if (podatki[sredina] < cilj) 
            {
                spodnjaMeja = sredina + 1;
            }
            else
            {
                zgornjaMeja = sredina - 1; 
            }
        }

        return rezultat; 
    }
}