using Godot;
using System;

public class GameStart : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	public static Player player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		OS.WindowSize = new Vector2(1280, 720);
		player = GetNode<Player>("Player");
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
