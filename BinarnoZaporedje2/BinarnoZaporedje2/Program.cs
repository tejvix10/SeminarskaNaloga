using System;

class OptimizatorPrenosa
{
    public int IzracunajMinimalnoKapaciteto(int[] mase, int steviloDni) 
    {                                                                  
                                                                        
        int spodnjaMeja = 0, zgornjaMeja = 0; 

        for (int i = 0; i < mase.Length; i++) 
        {
            spodnjaMeja = Math.Max(spodnjaMeja, mase[i]); 
            zgornjaMeja += mase[i]; 
        }

       
        while (spodnjaMeja < zgornjaMeja) 
        {
            int srednjaVrednost = (spodnjaMeja + zgornjaMeja) / 2; 
            if (JeMoznoPrenesti(mase, steviloDni, srednjaVrednost)) zgornjaMeja = srednjaVrednost;
            else spodnjaMeja = srednjaVrednost + 1; 
                                                    
        }
        return spodnjaMeja; 
    }

    private bool JeMoznoPrenesti(int[] mase, int steviloDni, int kapaciteta) 
    {
        int dneviUporabljeni = 1, trenutnaMasa = 0; 
                                                    

        for (int i = 0; i < mase.Length; i++)  
        {

            if (trenutnaMasa + mase[i] > kapaciteta)
            {
                dneviUporabljeni++;     
                trenutnaMasa = 0;     
            }
            trenutnaMasa += mase[i];  
        }
        return dneviUporabljeni <= steviloDni; 
    }

    static void Main()
    {
        Console.WriteLine("Vnesite število paketov:");
        int stPaketov = int.Parse(Console.ReadLine()); 
        int[] masePaketov = new int[stPaketov]; 

        Console.WriteLine("Vnesite mase paketov (ločene z vejicami):"); 
        string[] vhod = Console.ReadLine().Split(','); 
        for (int i = 0; i < stPaketov; i++)
        {
            masePaketov[i] = int.Parse(vhod[i]);
        }

        Console.WriteLine("Vnesite število dni:"); 
        int steviloDni = int.Parse(Console.ReadLine()); 

        
        Console.WriteLine("Optimalna minimalna kapaciteta: " + new OptimizatorPrenosa().IzracunajMinimalnoKapaciteto(masePaketov, steviloDni)); 
    }
}