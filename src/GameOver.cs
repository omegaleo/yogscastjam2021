using Godot;
using System;

public class GameOver : Control
{
	private Popup _popup;
	
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
	
	public bool GameOverShowing
	{
		get { return _popup.Visible; }
	}
	
	public override void _Ready()
	{
		base._Ready();
		_popup = GetNode<Popup>("Popup");
	}
	
	public void ShowGameOver()
	{
		_popup.Popup_();
	}
}
