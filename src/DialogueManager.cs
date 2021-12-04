using Godot;
using System;
using GoodAndEvil;

public class DialogueManager : Control
{
	private Popup _popup;
	private RichTextLabel _label;
	
	
	public override void _Input(InputEvent @event)
	{
		base._Input(@event);

		if (Input.IsActionPressed("Action"))
		{
			GetNode<Popup>("Popup").Hide();
		}
			
	}

	public override void _Ready()
	{
		base._Ready();
		_popup = GetNode<Popup>("Popup");
		_label = GetNode<RichTextLabel>("Popup/Text");
	}

	public void ShowTutorialText()
	{
		ShowDialogue(Constants.tutorialText);
	}

	public void ShowDialogue(string text)
	{
		_popup.Popup_();
		_label.BbcodeText = text;
	}
}
