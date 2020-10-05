using Godot;
using System;

public class GameManager : Spatial
{
    public PlayerManager Player;
    public Sprite Fadescreen;
    [Export]public int PlayerHP = 2;
    public int LoopCount;
    public int BerryCount;
    WorldEnvironment World;
    public override void _Ready()
    {
        Player = (PlayerManager)GetChild(0);
        World = (WorldEnvironment)GetNode("World");
        Fadescreen = (Sprite)GetNode("CamFollow").GetChild(0).GetChild(0).GetChild(0);
                Fadescreen.Modulate = new Color(0,0,0,0);
    }

    public override void _PhysicsProcess(float delta)
    {
        if(PlayerHP <= 0)
        {
            Fadescreen.Modulate = Fadescreen.Modulate.LinearInterpolate(new Color(0,0,0,1),0.05f);
        }
    }

public void LoopCheck()
{
    var worldvalues = World.Environment;
    switch(LoopCount)
    {
        case 1:
        worldvalues.BackgroundColor = Colors.Red;
        break;
    }
GD.Print(LoopCount);
}
}
