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

public bool CanPickBerries = false;

    public override void _Ready()
    {
        _Camera = (Camera)Owner.FindNode("Camera");
        PlayerCollision = (CollisionShape)FindNode("Collision");
        PlayerTriggerArea = (Area)FindNode("Area");
        PlayerTriggerArea.Connect("area_entered",this,"CheckTriggerAreaEnterCollision");
        PlayerTriggerArea.Connect("area_exited",this,"CheckTriggerAreaExitCollision");
        PlayerAnimationsTree = (AnimationTree)FindNode("AnimationTree");
    }

    public override void _Process(float delta)
   {
      GetMovementInputValues();
      MoveAndSlide(_Velocity * _Movespeed);
   }

    private void GetMovementInputValues()
    {
        _Velocity = Vector3.Zero;
        if(Input.IsActionPressed("move_forward")){ _Velocity.z += -_Movespeed; }
        if(Input.IsActionPressed("move_back")){ _Velocity.z += _Movespeed; }
        if(Input.IsActionPressed("move_left")){ _Velocity.x += -_Movespeed; }
        if(Input.IsActionPressed("move_right")){ _Velocity.x += _Movespeed; }
        if(Input.IsActionJustPressed("interact")){ if(CanPickBerries){PlayerAnimationsTree.Set("parameters/OneShot/active",true);} }
    }

    public void CheckTriggerAreaEnterCollision(Area area)
    {
switch(area.CollisionMask)
{
    case 32:
    CanPickBerries = true;
                        GD.Print(CanPickBerries);
    break;
}
    }

        public void CheckTriggerAreaExitCollision(Area area)
    {
switch(area.CollisionMask)
{
    case 32:
    CanPickBerries = false;
                    GD.Print(CanPickBerries);
    break;
}
    }


    public override void _PhysicsProcess(float delta)
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
