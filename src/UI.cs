using Godot;
using System;
using System.Collections.Generic;
using GoodAndEvil;

public class UI : CanvasLayer
{

	public static DialogueManager dialogue;
	public static GameOver gameOver;
	public static Victory victory;
	public static HUDLabel hud;
	public static Control titleScreen;
	
	public override void _Ready()
	{
		dialogue = GetNode("DialogueManager") as DialogueManager;
		gameOver = GetNode("GameOver") as GameOver;
		victory = GetNode("Victory") as Victory;
		hud = GetNode("PlayerHUD").GetNode<HUDLabel>("Label");
		titleScreen = GetNode<Control>("TitleScreen");
	}


	public static void StartGame()
	{
		hud.Visible = true;
		titleScreen.Visible = false;
		dialogue.AddToList(new List<string>()
		{
			Constants.startingMessage1
		});
	}
}
