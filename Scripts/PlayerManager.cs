using Godot;
using System;

public class PlayerManager : KinematicBody
{
private Vector3 _Velocity;
[Export]private float _Movespeed;
private Camera _Camera;
private CollisionShape PlayerCollision;
private Area PlayerTriggerArea;
private AnimationTree PlayerAnimationsTree;
private GameManager manager;
public bool CanPickBerries = false;

[Export]public bool CanMove = true;
[Export]public bool CanLook = true;
private Area TouchingArea;

    public override void _Ready()
    {
        _Camera = (Camera)Owner.FindNode("Camera");
        PlayerCollision = (CollisionShape)FindNode("Collision");
        PlayerTriggerArea = (Area)FindNode("Area");
        PlayerTriggerArea.Connect("area_entered",this,"CheckTriggerAreaEnterCollision");
        PlayerTriggerArea.Connect("area_exited",this,"CheckTriggerAreaExitCollision");
        PlayerAnimationsTree = (AnimationTree)FindNode("AnimationTree");
        manager = (GameManager)Owner;
    }

    public override void _Process(float delta)
   {
      GetMovementInputValues();

      if(_Velocity != Vector3.Zero)
      {
            var AnimTreeBlend = Mathf.Lerp((float)PlayerAnimationsTree.Get("parameters/Blend2/blend_amount"),1f,0.07f);
            PlayerAnimationsTree.Set("parameters/Blend2/blend_amount",AnimTreeBlend);  
      }
      else
      {
            var AnimTreeBlend = Mathf.Lerp((float)PlayerAnimationsTree.Get("parameters/Blend2/blend_amount"),0f,0.07f);
            PlayerAnimationsTree.Set("parameters/Blend2/blend_amount",AnimTreeBlend);  
      }
      if(CanMove)
      {
      MoveAndSlide(_Velocity * _Movespeed);
      }
   }

    private void GetMovementInputValues()
    {
        _Velocity = Vector3.Zero;
        if(Input.IsActionPressed("move_forward")){ _Velocity.z += -_Movespeed; }
        if(Input.IsActionPressed("move_back")){ _Velocity.z += _Movespeed; }
        if(Input.IsActionPressed("move_left")){ _Velocity.x += -_Movespeed; }
        if(Input.IsActionPressed("move_right")){ _Velocity.x += _Movespeed; }
        if(Input.IsActionJustPressed("interact"))
        {
            if(TouchingArea != null)
            {
            switch(TouchingArea.CollisionMask)
            {
                case 32:
                if(CanPickBerries){PlayerAnimationsTree.Set("parameters/OneShot/active",true); manager.BerryCount++;}
                break;
            }

            }
        
        }
    }

    public void CheckTriggerAreaEnterCollision(Area area)
    {
        TouchingArea = area;
switch(area.CollisionMask)
{
    case 32:
    CanPickBerries = true;
    break;
}
    }

    public void CheckTriggerAreaExitCollision(Area area)
    {
        TouchingArea = null;
switch(area.CollisionMask)
{
    case 32:
    CanPickBerries = false;
    break;
}
    }


    public override void _PhysicsProcess(float delta)
    {
    if(CanLook)
    {
        var SpaceState = GetWorld().DirectSpaceState;
        var mouse_pos = GetViewport().GetMousePosition();

        var rayOrigin = _Camera.ProjectRayOrigin(mouse_pos);
        var rayEnd = rayOrigin + _Camera.ProjectRayNormal(mouse_pos) * 2000;

        var intersection = SpaceState.IntersectRay(rayOrigin,rayEnd,new Godot.Collections.Array{PlayerCollision},4);
        var pos = Vector3.Zero;

        if(intersection.Contains("position"))
        {
            pos = (Vector3)intersection["position"];
            LookAt(new Vector3(pos.x,0,pos.z),Vector3.Up);
        }

    }
}
}
