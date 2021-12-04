using Godot;
using System;

public class Player : KinematicBody2D
{
	[Export] public int speed = 200;

	[Export] public int goodKeys = 0;
	[Export] public int badKeys = 0;
	[Export] public int jaffaCakes = 0;

	[Export] public Vector2 respawnPoint;
	
	public Vector2 velocity = new Vector2();

	public int hearts = 3;

	public override void _Ready()
	{
		base._Ready();

		respawnPoint = GlobalPosition;
	}


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
	private bool waitingToRespawn = false;
	
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

				if (collisionName.Equals("JaffaCake"))
				{
					jaffaCakes++;
					((Node) collision.Collider).QueueFree();
				}
				
				if (collisionName.Equals("RespawnPoint"))
				{
					respawnPoint = GlobalPosition;
					((Node) collision.Collider).QueueFree();
				}
				
				if (collisionName.Contains("Key"))
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
				
				if (collisionName.Contains("Door"))
				{
					if (collisionName.Contains("Bad") && badKeys > 0)
					{
						badKeys--;
						((Node) collision.Collider).QueueFree();
						respawnPoint = GlobalPosition;
					}
					else if (collisionName.Contains("Bad") && !messageSent)
					{
						UI.dialogue.ShowLockedBadDoorText();
						messageSent = true;
					}
					
					if (collisionName.Contains("Good") && goodKeys > 0)
					{
						goodKeys--;
						((Node) collision.Collider).QueueFree();
						respawnPoint = GlobalPosition;
					}
					else if (collisionName.Contains("Good") && !messageSent)
					{
						UI.dialogue.ShowLockedGoodDoorText();
						messageSent = true;
					}
				}

				if (collisionName.Contains("Death") && !waitingToRespawn)
				{
					hearts--;
					waitingToRespawn = true;
					GlobalPosition = respawnPoint;
					waitingToRespawn = false;
				}
			}
			else
			{
				messageSent = false;
			}
		}
	}
}
