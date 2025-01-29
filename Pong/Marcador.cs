using Heirloom;

namespace Pong;

public class Marcador: ObjectePantalla
{
    private readonly int[] _punts = new int[2];

    public Marcador(Rectangle posicio) : base(posicio)
    {
        _punts[0] = 0;
        _punts[1] = 0;
    }

    public void Gol(int jugadorQueHaMarcat)
    {
        _punts[jugadorQueHaMarcat]++;
    }

    public string Resultat()
    {
        return $"{_punts[0]}    {_punts[1]}";
    }
    
}