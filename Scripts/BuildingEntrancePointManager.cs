using Godot;
using System;
using System.Collections.Generic;

public class BuildingEntrancePointManager : Spatial
{
private Area EntranceArea;
[Export]private List<NodePath> ThingsToHide;
[Export]private List<NodePath> ThingsGoTransparent;

[Export]private Color MatColor;
public bool isInside;
    public override void _Process(float delta)
    {
        if(isInside)
        {
            for(int x = 0; x < ThingsGoTransparent.Count;x++)
            {
                Material ThingToChange = (Material)GetNode(ThingsGoTransparent[x]).Get("material/0");   
                MatColor = MatColor.LinearInterpolate(new Color(1,1,1,0.3f),0.4f);
                ThingToChange.Set("albedo_color",MatColor);
            }
        }
        else
        {
            for(int x = 0; x < ThingsGoTransparent.Count;x++)
            {
                Material ThingToChange = (Material)GetNode(ThingsGoTransparent[x]).Get("material/0");   
                MatColor = MatColor.LinearInterpolate(new Color(1,1,1,1f),0.4f);
                ThingToChange.Set("albedo_color",MatColor);
            }
        }
        
    }

    public void AreaEntered(Area area)
    {
                GD.Print("hello");
        if(area.CollisionMask == 1)
        {
        for(int x = 0; x < ThingsToHide.Count;x++)
        {
            Spatial ListItemToChange = (Spatial)GetNode(ThingsToHide[x]);
            ListItemToChange.Visible = false;
        }
            isInside = true;
        }
    }

        public void AreaExited(Area area)
    {
        if(area.CollisionMask == 1)
        {
        for(int x = 0; x < ThingsToHide.Count;x++)
        {
            Spatial ListItemToChange = (Spatial)GetNode(ThingsToHide[x]);
            ListItemToChange.Visible = true;
        }

            isInside = false;
        }
    }


}
