using System.Text.Json;
using project04.Models;
using project04.Filter;

using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        Console.WriteLine();
        Console.WriteLine(resposta);
        Console.WriteLine();

        var musicas = JsonSerializer.Deserialize<List<Music>>(resposta)!; //! significa que musicas nao pode ser nulo
                                                                          //JsonSerializer.Deserialize<TIPO QUE EU QUERO CONVERTER>(O QUE VAI SER CONVERTIDO)
        
        Console.WriteLine(musicas.Count);
        musicas[0].ExibirDetalhesMusica();
        LinqFilter.FiltrarGeneros(musicas);

        Console.WriteLine("Insira o genero:");
        string genero = Console.ReadLine();
        LinqFilter.FiltrarArtistasPorGenero(musicas, genero);

        LinqOrder.ExibirArtistasOrdenados(musicas);

        Console.WriteLine("Insira o artista:");
        string artista = Console.ReadLine();
        LinqFilter.FiltrarMusicasDeArtista(musicas, artista);
    }
    catch(Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}


/* Bom, o que temos aqui eh:
 * estamos iniciando e configurando uma requisicao HttpClient. fazemos isso pra diversas coisas inclusive consultar uma api externa. 
 * nesse caso usamos o USING (HttpClient client = new HttpClient()){} e abrimos CHAVES, onde dentro das chaves estarao as ações desse client.
 * 
 * na linha 3, queremos receber todo o conteudo de https://guilhermeonrails.github.io/api-csharp-songs/songs.json em uma unica string. 
 * pre isso, usamos o metodo .GetStringAsync.
 * Usamos Async porque como é um processo demorado que pode acontecer em partes, ele é feito de maneira assincrona. 
 * pra utilizarmos o método async, precisamos colocar o AWAIT, senao a string RESPOSTA vai pegar apenas uma pequena parte que for retornada imediatamente no getstring. 
 * 
 * 
 * uma boa prática é sempre colocar uma requisição dentro de um TRY-CATCH, pra caso dê errado, a gente consegue saber qual erro foi. 
 */