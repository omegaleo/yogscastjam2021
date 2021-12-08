using Godot;
using System;
using System.Collections.Generic;
using GoodAndEvil;

public class DialogueManager : Control
{
	private Popup _popup;
	private RichTextLabel _label;
	public List<string> messages;
	
	
	public override void _Input(InputEvent @event)
	{
		base._Input(@event);

		if (Input.IsActionPressed("Action"))
		{
			if (messages.Count == 0)
				_popup.Hide();
			else
			{
				messages.RemoveAt(0);
				if (messages.Count == 0)
					_popup.Hide();
				else
				{
					ShowDialogue(messages[0]);
				}
			}
		}
	}

	public bool IsPopupOpen
	{
		get { return _popup.Visible; }
	}
	
	public override void _Ready()
	{
		base._Ready();
		_popup = GetNode<Popup>("Popup");
		_label = GetNode<RichTextLabel>("Popup/Text");
		messages = new List<string>();
	}

	public void AddToList(List<string> text)
	{
		messages.AddRange(text);
		
		ShowDialogue(messages[0]);
	}
	
	public void AddToList(string text)
	{
		messages.Add(text);
		
		ShowDialogue(messages[0]);
	}
	
	public void ShowTutorialText()
	{
		AddToList(Constants.tutorialText);
	}

	public void ShowSecondTutorialText()
	{
		AddToList(Constants.tutorialSecondText);
	}
	
	public void ShowLockedGoodDoorText()
	{
		AddToList(Constants.goodDoorLockedText);
	}
	
	public void ShowLockedBadDoorText()
	{
		AddToList(Constants.badDoorLockedText);
	}
	
	public void ShowDialogue(string text)
	{
		_popup.Popup_();
		_label.BbcodeText = text;
	}
}
