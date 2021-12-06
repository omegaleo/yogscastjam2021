using Godot;
using System;
using GoodAndEvil;
using Environment = Godot.Environment;

public class HUDLabel : RichTextLabel
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		string hud = "";

		for (int i = 0; i < GameStart.player.hearts; i++)
		{
			hud += Constants.heartBBCode;
		}

		hud += System.Environment.NewLine;
		
		hud += $"{Constants.jaffaBBCode}x{GameStart.player.jaffaCakes}";
		
		if (GameStart.player.goodKeys > 0)
			hud += $"{Constants.goodKeyBBCode}";
		
		if (GameStart.player.badKeys > 0)
			hud += $"{Constants.badKeyBBCode}";

		
		
		
		BbcodeText = hud;
	}
}
