using Godot;
using System;

public class TextPopup : Spatial
{
    RichTextLabel TextToShow;
    private Timer TextShowTimer;
    [Export]private string StringToShow;
    public override void _Ready()
    {
        TextToShow = (RichTextLabel)Owner.GetNode("CamFollow").GetChild(0).GetChild(0).GetChild(1);
        TextShowTimer = (Timer)GetChild(1);
        HideText();
    }

    public void ShowText()
    {
    TextToShow.Visible = true;
    TextToShow.BbcodeText = "[center]"+ StringToShow;
    TextShowTimer.Start();
    }

    private void HideText()
    {
        TextToShow.Visible = false;
    }

    public void AreaEntered(Area area)
    {
        if(area.Owner.Name=="Player")
        {
            ShowText();
            GD.Print("This should work");
        }
    }
}
