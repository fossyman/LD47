using Godot;
using System;

public class Boss : Spatial
{
    public GameManager manager;
public Area AttackCollision;
private int HP;
    public override void _Ready()
    {
        AttackCollision = (Area)FindNode("Area");
        manager = (GameManager)Owner;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }


    public void AttackAreaCollision(Area area)
    {
        if(area.CollisionMask == 2147484672)
        {
            GD.Print("ECH!!!!!!!");
        }

    }
}
