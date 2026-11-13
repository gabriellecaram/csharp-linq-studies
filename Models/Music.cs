using System.Text.Json.Serialization;

namespace project04.Models;

internal class Music
{
    [JsonPropertyName("song")] //é um atributo que representa um metadado para a propriedade nome
    public string? Nome { get; set; }
    [JsonPropertyName("artist")]  //é o jeito que ta no arquivo "original" //anotação
    public string? Artista { get; set; }
    [JsonPropertyName("duration_ms")]
    public int ?Duracao { get; set; }
    [JsonPropertyName("genre")]
    public string? Genero { get; set; }

    public void ExibirDetalhesMusica()
    {
        Console.WriteLine("Detalhes da música: ");
        Console.WriteLine($"Artista: {Artista}");
        Console.WriteLine($"Música: {Nome}");
        Console.WriteLine($"Duração: {Duracao/1000}");
        Console.WriteLine($"Gênero: {Genero}");
        Console.WriteLine();
    }
}