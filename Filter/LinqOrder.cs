using project04.Models;

namespace project04.Filter;

internal class LinqOrder
{
    public static void ExibirArtistasOrdenados(List<Music> musicas)
    {
        var artistas = musicas.OrderBy(a => a.Artista).Select(a => a.Artista).Distinct().ToList();
        Console.WriteLine("Artistas ordenados: ");
        foreach(var a in artistas)
        {
            Console.WriteLine($"- {a}");
        }
    }
}