using Godot;
using System;

public class CameraFollower : Spatial
{
[Export]private NodePath CameraFollowPointPath;
private Spatial CameraFollowPoint;
[Export]private float LerpTime;

  public override void _Ready()
  {
    CameraFollowPoint = (Spatial)GetNode(CameraFollowPointPath);
    GD.Print(CameraFollowPoint.Name);
  }
  public override void _PhysicsProcess(float delta)
  {
    Translation = Translation.LinearInterpolate(CameraFollowPoint.Transform.origin,LerpTime * delta);  
  }
}
