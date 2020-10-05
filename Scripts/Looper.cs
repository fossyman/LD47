using Godot;
using System;

public class Looper : Node
{
    Spatial LoopPosition;
    private GameManager gameManager;
    public override void _Ready()
    {
        gameManager = (GameManager)Owner;
        LoopPosition = (Spatial)FindNode("Spatial");
      Connect("area_entered",this,"LoopBack");  
    }

    private void LoopBack(Area area)
    {
        if(area.Owner.Name=="Player")
        {
        var owner = (Spatial)area.Owner;
        owner.Translation = LoopPosition.Transform.origin;
        gameManager.LoopCount++;
        gameManager.LoopCheck();
        }
    }
}
