using Godot;
using System.Collections.Generic;

public class DungeonGenerator : Spatial
{
private List<Vector3> DungeonRoomPositions = new List<Vector3>();
private RandomNumberGenerator rnd = new RandomNumberGenerator();
PackedScene Room = (PackedScene)ResourceLoader.Load("res://Scenes/Rooms/Room1.tscn");
private Spatial Walker;
private Area WalkerArea;

private int minroomcount = 20;
private int maxroomcount = 100;
RandomNumberGenerator random = new RandomNumberGenerator();

    public override void _Ready()
    {
      Walker = (Spatial)GetChild(0);
      WalkerArea = (Area)Walker.GetChild(1);
    for(int x = 0; x < maxroomcount; x++)
    {
        GenerateDungeon();
    }

    }


    public override void _Process(float delta)
    {
if(Input.IsActionJustPressed("regen"))
{
        GenerateDungeon();
}
    }






    public void GenerateDungeon()
    {
      rnd.Randomize();
      var dir = random.RandiRange(0,3);
      if(dir == 0)// right
      {
      Walker.Translation += new Vector3(2,0,0);
      if(!DungeonRoomPositions.Contains(Walker.Transform.origin) )
      {
              AddRoom();
      }
      else{dir = random.RandiRange(0,3);}
      }
      else if(dir == 1)
      {
      Walker.Translation += new Vector3(-2,0,0);
            if(!DungeonRoomPositions.Contains(Walker.Transform.origin) )
      {
              AddRoom();
      }
      else{dir = random.RandiRange(0,3);}
      }
      else if(dir == 2)
      {
      Walker.Translation += new Vector3(0,0,2);
            if(!DungeonRoomPositions.Contains(Walker.Transform.origin) )
      {
              AddRoom();
      }
      else{dir = random.RandiRange(0,3);}
      }
      else if(dir == 3)
      {
      Walker.Translation += new Vector3(0,0,-2);
            if(!DungeonRoomPositions.Contains(Walker.Transform.origin) )
      {
              AddRoom();
      }
      else{dir = random.RandiRange(0,3);}
      }
    }

    public void AddRoom()
    {
    Spatial roominstance = (Spatial)Room.Instance();
    DungeonRoomPositions.Add(Walker.Transform.origin);
    roominstance.Translation = Walker.Transform.origin;
    AddChild(roominstance);
    }
}
