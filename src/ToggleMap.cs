using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class ToggleMap : Node2D
{
	public override void _Input(InputEvent inputEvent)
	{
		if (!UI.dialogue.IsPopupOpen)
		{
			if (inputEvent.IsActionPressed("SwitchMap"))
			{
				Toggle();
			}
		
			SetRigidbodies();
		}
	}

	void Toggle()
	{
		Visible = !Visible;

		SetRigidbodies();
	}

	void SetRigidbodies()
	{
		if (!Visible)
		{
			foreach (var child in GetChildren())
			{
				if (child is RigidBody2D)
				{
					((RigidBody2D) child).GetNode<CollisionShape2D>("Collision").Disabled = true;
				}

				if (child is StaticBody2D)
				{
					((StaticBody2D) child).GetNode<CollisionPolygon2D>("Collision").Disabled = true;
				}
			}
		}
		else
		{
			foreach (var child in GetChildren())
			{
				if (child is RigidBody2D)
				{
					((RigidBody2D) child).GetNode<CollisionShape2D>("Collision").Disabled = false;
				}
				
				if (child is StaticBody2D)
				{
					((StaticBody2D) child).GetNode<CollisionPolygon2D>("Collision").Disabled = false;
				}
			}
		}
	}
}
