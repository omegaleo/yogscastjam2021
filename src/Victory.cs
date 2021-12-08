using Godot;
using System;
using GoodAndEvil;

public class Victory : Control
{
	private Popup _popup;
	private RichTextLabel _text;
	
	public override void _Input(InputEvent @event)
	{
		base._Input(@event);

		if (_popup.Visible)
		{
			if (Input.IsActionPressed("Action"))
			{
				_popup.Hide();
			}
		}
	}
	
	public bool Showing
	{
		get { return _popup.Visible; }
	}
	
	public override void _Ready()
	{
		base._Ready();
		_popup = GetNode<Popup>("Popup");
		_text = _popup.GetNode<RichTextLabel>("RichTextLabel");
	}
	
	public void ShowVictory()
	{
		_popup.Popup_();
		_text.BbcodeText = string.Format(Constants.VictoryText, GameStart.player.jaffaCakes, GameStart.jaffaCakeCount);
	}
}
