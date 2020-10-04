using Godot;
using System;

public class GameManager : Spatial
{
    public PlayerManager Player;
    public Spatial PlayerSpatial;
    public Transform PlayerPrevPos;
    public int LoopCount;
    public int BerryCount;
    WorldEnvironment World;
    private CPUParticles Grass;
    public override void _Ready()
    {
        Player = (PlayerManager)GetChild(0);
        PlayerSpatial = (Spatial)Player;
        World = (WorldEnvironment)GetNode("World");
        Grass = (CPUParticles)GetChild(3);
        Grass.SpeedScale = 1;
        CallDeferred("StopGrass");
    }

    public void StopGrass()
    {
              Grass.SpeedScale = 0;  
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
