using Heirloom;
using Heirloom.Desktop;

namespace Pong;

class Program
{
    private const int Amplada = 1024;
    private const int Altura = 768;
    private  static Window _finestra = null!;

    private static Camp _camp = null!;
    
    static void Main()
    {
        Application.Run(() =>
        {
            // Crea la finestra
            _finestra = new Window("ElQueSigui", (Amplada, Altura)) { IsResizable = false };
            // _finestra.BeginFullscreen();
            // _finestra.SetIcon(new Image("imatges/icon.ico"));
            _finestra.MoveToCenter();

            _camp = new Camp(_finestra);
            _camp.Carrega();
            
            var loop = GameLoop.Create(_finestra.Graphics, OnUpdate, 120);
            loop.Start();
        });
    }

    private static void OnUpdate(GraphicsContext gfx, float dt)
    {
        _camp.Juga(gfx);
    }
}
