using Godot;
using System;

public class GameStart : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	public static Music music;

	public static Player player;

	public static ToggleMap good;
	public static ToggleMap bad;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		OS.WindowSize = new Vector2(1280, 720);
		player = GetNode<Player>("Player");
		music = GetNode<Music>("Music");
		bad = GetNode<ToggleMap>("Bad");
		good = GetNode<ToggleMap>("Good");
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
