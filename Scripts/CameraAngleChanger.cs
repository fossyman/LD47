using Godot;
using System;

public class CameraAngleChanger : Area
{
private Spatial CameraAngleSpatial;

[Export]private Vector3 Angle;

private bool isChanged=false;
    public override void _Ready()
    {
        CameraAngleSpatial = (Spatial)Owner.FindNode("CamFollow");
    }

    public override void _Process(float delta)
    {
        if(isChanged)
        {
        CameraAngleSpatial.Rotation = CameraAngleSpatial.Rotation.LinearInterpolate(new Vector3(Mathf.Deg2Rad(Angle.x),0,0),0.05f);
        }
        else
        {
        CameraAngleSpatial.Rotation = CameraAngleSpatial.Rotation.LinearInterpolate(Vector3.Zero,0.05f);
        }
    }

    public void AreaEntered(Area area)
    {
        if(area.CollisionLayer == 2048)
        {
            isChanged = true;
        }
    }

        public void AreaExited(Area area)
    {
        if(area.CollisionLayer == 2048)
        {
            isChanged = false;
        }
    }
}
