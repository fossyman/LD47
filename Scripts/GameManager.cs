using Godot;
using System;

public class GameManager : Spatial
{
    public PlayerManager Player;
    public int LoopCount;
    public int BerryCount;
    WorldEnvironment World;
    public override void _Ready()
    {
        Player = (PlayerManager)GetNode("Player");
        World = (WorldEnvironment)GetNode("World");
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
