using Godot;
using System;
using GoodAndEvil;

public class StartGame : Button
{
	public override void _Pressed()
	{
		base._Pressed();

		UI.StartGame();
		GameStart.sfx.PlaySFX(Constants.buttonPress);
	}
}
