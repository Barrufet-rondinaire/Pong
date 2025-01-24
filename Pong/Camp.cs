using Heirloom;
using Heirloom.Desktop;

namespace Pong;

public class Camp
{
    private readonly Window _finestra;
    private readonly List<Pala> _pales = new();
    private readonly Porteria[] _porteries = new Porteria[2];

    private Dictionary<string, Image> _imatges = new();

    public Camp(Window finestra)
    {
        _finestra = finestra;
    }

    public void Carrega()
    {
        // Carregar imatges
        // _imatges["pilota"] = new Image("/imatges/pilota");
        
        // Crear objectes
        var posicioPorteria1 = new Rectangle(0, 0, 10, _finestra.Height);
        _porteries[0] = new Porteria(posicioPorteria1);
        var posicioPorteria2 = new Rectangle(_finestra.Width - 10, 0, 10, _finestra.Height);
        _porteries[1] = new Porteria(posicioPorteria2);
        
        
        var posicioPala1 = new Rectangle(20, 100, 10, 100);
        _pales.Add(new Pala(posicioPala1, 5));
        var posicioPala2 = new Rectangle(_finestra.Width-30, 100, 10, 100);
        _pales.Add(new Pala(posicioPala2, 5));
    }

    public void Pinta(GraphicsContext gfx)
    {
        gfx.Clear(Color.Black);

        foreach (var pala in _pales)
        {
            gfx.DrawRect(pala.Posicio);
        }
    }

}