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
				if (child is RigidBody2D || child is StaticBody2D)
				{
					var collisionNode = ((Node) child).GetNode("Collision");
					if (collisionNode is CollisionPolygon2D)
					{
						((CollisionPolygon2D)collisionNode).Disabled = true;
					}
					
					if (collisionNode is CollisionShape2D)
					{
						((CollisionShape2D)collisionNode).Disabled = true;
					}
				}
			}
		}
		else
		{
			foreach (var child in GetChildren())
			{
				if (child is RigidBody2D || child is StaticBody2D)
				{
					var collisionNode = ((Node) child).GetNode("Collision");
					if (collisionNode is CollisionPolygon2D)
					{
						((CollisionPolygon2D)collisionNode).Disabled = false;
					}
					
					if (collisionNode is CollisionShape2D)
					{
						((CollisionShape2D)collisionNode).Disabled = false;
					}
				}
			}
		}
	}
}
