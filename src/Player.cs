using Godot;
using System;

public class Player : KinematicBody2D
{
	[Export] public int speed = 200;

	public Vector2 velocity = new Vector2();

	public void GetInput()
	{
		velocity = new Vector2();

		if (Input.IsActionPressed("Right"))
			velocity.x += 1;

		if (Input.IsActionPressed("Left"))
			velocity.x -= 1;

		if (Input.IsActionPressed("Down"))
			velocity.y += 1;

		if (Input.IsActionPressed("Up"))
			velocity.y -= 1;

		velocity = velocity.Normalized() * speed;
	}

	private bool messageSent = false;
	
	public override void _PhysicsProcess(float delta)
	{
		if (!UI.dialogue.IsPopupOpen)
		{
			GetInput();
			velocity = MoveAndSlide(velocity);
		
			var collision = GetLastSlideCollision();

			if (collision != null)
			{
				string collisionName = ((Node) collision.Collider).Name;

				if (collisionName.Equals("StartingSign") && !messageSent)
				{
					UI.dialogue.ShowTutorialText();
					messageSent = true;
				}
			}
			else
			{
				messageSent = false;
			}
		}
	}
}
