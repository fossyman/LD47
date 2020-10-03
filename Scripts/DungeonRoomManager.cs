using Godot;
using System.Collections.Generic;

public class DungeonRoomManager : Spatial
{

    [Export]private List<NodePath> RoomConnectPoints;
        PackedScene Room = (PackedScene)ResourceLoader.Load("res://Scenes/Rooms/Room1.tscn");
    public void makeroom()
    {

    }

public override void _Process(float delta)
{
if(Input.IsActionJustPressed("regen"))
{

}
}

}
