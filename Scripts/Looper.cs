using Godot;
using System;

public class Looper : Node
{
    private GameManager gameManager;
    public override void _Ready()
    {
        gameManager = (GameManager)Owner;
      Connect("area_entered",this,"LoopBack");  
    }

    private void LoopBack(Area area)
    {
        var owner = (Spatial)area.Owner;
        owner.Translate(Vector3.Back * 10);
        gameManager.LoopCount++;
        gameManager.LoopCheck();
    }
}
