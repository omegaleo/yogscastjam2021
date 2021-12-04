using Godot;
using System;

public class UI : CanvasLayer
{

	public static DialogueManager dialogue;
	
	public override void _Ready()
	{
		dialogue = GetNode("DialogueManager") as DialogueManager;
		
	}

}
