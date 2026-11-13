using project04.Models;

namespace project04.Filter;

internal class LinqFilter
{
    public static void FiltrarGeneros(List<Music>musicas)
    {
        var generos = musicas.Select(g => g.Genero).Distinct().ToList();
        //declara variavel por inferencia
        //vai entrar na lista musicas e .SELECIONAR todos os valores de .Genero que forem .DIFERENTES e adicionar a uma .LISTA
        foreach (var g in generos)
        {
            Console.WriteLine($"- {g}");
        }
    }

    public static void FiltrarArtistasPorGenero(List<Music> musicas, string genero)
    {
        //percorro a lista, e .ONDE o genero .CONTIVER o genero pedido, .SELECIONA o artista que for .DIFERENTES e add na .LISTA
        var artistasPorGenero = musicas.Where(m => m.Genero!.Contains(genero)).Select(m => m.Artista).Distinct().ToList();
        Console.WriteLine($"Exibindo artistas do genero {genero}");
        foreach (var a in artistasPorGenero)
        {
            Console.WriteLine($"- {a}");
        }
    }


    public static void FiltrarMusicasDeArtista(List<Music> musicas, string artista)
    {
        var musicasDoArtista = musicas.Where(m => m.Artista!.Equals(artista)).ToList();
        Console.WriteLine($"Músicas de {artista}");
        foreach(var m in musicasDoArtista)
        {
            Console.WriteLine($"- {m.Nome}");
        }
    }
}
