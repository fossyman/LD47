using Godot;
using System;

public class Enemy : KinematicBody
{
private AnimationPlayer AnimPlayer;
private GameManager GameManager;
private Area DetectionArea;
private CollisionShape DetectionRadius;
private Timer AIUpdateTimer;
private Spatial Target;
[Export]private float WalkSpeed;
Vector3[] path;
int path_ind;
Navigation nav;

public float HP = 100;

public override void _Ready()
{
GameManager = (GameManager)Owner;
DetectionArea = (Area)GetChild(1);
DetectionRadius = (CollisionShape)DetectionArea.GetChild(0);
AIUpdateTimer = (Timer)GetChild(3);
nav = (Navigation)GetParent();

move_to(this.Transform.origin);
}

    void move_to(Vector3 Target)
    {
    path_ind = 0;
    path = nav.GetSimplePath(GlobalTransform.origin,Target);
    }   

    public override void _Process(float delta)
    {
        if(Target != null)
        {
        LookAt(new Vector3(Target.GlobalTransform.origin.x,0,Target.GlobalTransform.origin.z),Vector3.Up);
        }
    if(path_ind < path.Length)
    {
    var move_vec = (path[path_ind] - GlobalTransform.origin);  

        if(move_vec.Length() < 0.1)
        {
        path_ind += 1;
        
        }
        else
        {
            MoveAndSlide(move_vec.Normalized() * WalkSpeed,Vector3.Up);
        }
    }

    }

    public void _timeout()
    {
  DetectionRadius.Disabled = !DetectionRadius.Disabled;
    }

    public void _OnSoundAreaEntered(Area hek)
    {
        if(hek.CollisionMask == 512)
        {
            Target = GameManager.PlayerSpatial;
        move_to(GameManager.PlayerSpatial.GlobalTransform.origin);
        }
    }

        public void _OnSoundAreaLeft(Area hek)
    {
        if(hek.CollisionMask == 512)
        {
            Target = null;
        }
    }

        public void _OnAttackAreaEntered(Area hek)
    {
if(hek.CollisionLayer == 1024)
    {
        GD.Print("ECH!!!!!!!");
    }
    }
}
