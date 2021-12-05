using Godot;
using System;

public class UI : CanvasLayer
{

	public static DialogueManager dialogue;
	public static GameOver gameOver;
	
	public override void _Ready()
	{
		dialogue = GetNode("DialogueManager") as DialogueManager;
		gameOver = GetNode("GameOver") as GameOver;
	}

}
