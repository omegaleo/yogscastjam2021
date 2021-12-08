using Godot;
using System;

public class StartGame : Button
{
	public override void _Pressed()
	{
		base._Pressed();

		UI.StartGame();
	}
}
