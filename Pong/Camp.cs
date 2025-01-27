using Heirloom;
using Heirloom.Desktop;

namespace Pong;

public class Camp
{
    private readonly Window _finestra;
    private readonly List<Pala> _pales = new();
    private Pilota _pilota;

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
        
        var posicioPala1 = new Rectangle(26, (_finestra.Height-100)/2, 15, 100);
        _pales.Add(new Pala(posicioPala1, 10));
        var posicioPala2 = new Rectangle(_finestra.Width-39, (_finestra.Height-100)/2, 15, 100);
        _pales.Add(new Pala(posicioPala2, 10));

        var posicioPilota = new Rectangle(
            _finestra.Width / 2 - 5,
            _finestra.Height / 2 - 5,
            10,
            10);
        _pilota = new Pilota(posicioPilota, new Vector(1,0), 10 );
    }

    public void Moure(GraphicsContext gfx)
    {
        Mou();
        Pinta(gfx);
    }

    public void Mou()
    {
        var rectanglePantalla = new Rectangle(0, 0, _finestra.Width, _finestra.Height);
        // Moure pales
        var movimentPala = new int[2];
        if (Input.CheckKey(Key.Up, ButtonState.Down))
        {
            movimentPala[0] = -1;
            movimentPala[1] = -1;
        }
        if (Input.CheckKey(Key.Down, ButtonState.Down))
        {
            movimentPala[0] = +1;
            movimentPala[1] = +1;
        }

        var i = 0;
        foreach (var pala in _pales)
        {
            pala.Mou(movimentPala[i], rectanglePantalla);
            i++;
        }
        
        // Moure Pilota
        _pilota.Mou(rectanglePantalla);
        // Mira si ha passat alguna cosa

    }
    
    public void Pinta(GraphicsContext gfx)
    {
        gfx.Clear(Color.Black);

        foreach (var pala in _pales)
        {
            gfx.DrawRect(pala.Posicio);
        }
        
        gfx.DrawRect(_pilota.Posicio);
    }

}