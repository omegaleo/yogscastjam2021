using Godot;
using System;

public class Player : KinematicBody2D
{
	[Export] public int speed = 200;

	public int goodKeys = 0;
	public int badKeys = 0;
	
	public Vector2 velocity = new Vector2();

	public int hearts = 3;
	
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
				if (collisionName.Equals("StartingSign2") && !messageSent)
				{
					UI.dialogue.ShowSecondTutorialText();
					messageSent = true;
				}
				else if (collisionName.Contains("Key"))
				{
					if (collisionName.Contains("Bad"))
					{
						badKeys++;
						((Node) collision.Collider).QueueFree();
					}
					else
					{
						goodKeys++;
						((Node) collision.Collider).QueueFree();
					}
				}
				else if (collisionName.Contains("Door"))
				{
					if (collisionName.Contains("Bad") && badKeys > 0)
					{
						badKeys--;
						((Node) collision.Collider).QueueFree();
					}
					else if (collisionName.Contains("Good") && goodKeys > 0)
					{
						goodKeys--;
						((Node) collision.Collider).QueueFree();
					}
				}
			}
			else
			{
				messageSent = false;
			}
		}
	}
}
