using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using GoodAndEvil;

public class Player : KinematicBody2D
{
	[Export] public int speed = 200;

	[Export] public int goodKeys = 0;
	[Export] public int badKeys = 0;
	[Export] public int jaffaCakes = 0;

	[Export] public Vector2 respawnPoint;

	public Vector2 velocity = new Vector2();

	public int hearts = 3;

	public Sprite sprite;

	[Export] public List<AnimationFrame> animationFrames = new List<AnimationFrame>()
	{
		new AnimationFrame()
		{
			animationName = "IdleDown",
			frames = new List<FrameCoordinates>()
			{
				new FrameCoordinates(0, 0)
			}
		},
		new AnimationFrame()
		{
			animationName = "Down",
			frames = new List<FrameCoordinates>()
			{
				new FrameCoordinates(32, 0),
				new FrameCoordinates(32, 0),
				new FrameCoordinates(32, 0),
				new FrameCoordinates(32, 0),
				new FrameCoordinates(32, 0),
				new FrameCoordinates(64, 0),
				new FrameCoordinates(64, 0),
				new FrameCoordinates(64, 0),
				new FrameCoordinates(64, 0),
				new FrameCoordinates(64, 0)
			}
		},
		new AnimationFrame()
		{
			animationName = "IdleUp",
			frames = new List<FrameCoordinates>()
			{
				new FrameCoordinates(96, 0)
			}
		},
		new AnimationFrame()
		{
			animationName = "Up",
			frames = new List<FrameCoordinates>()
			{
				new FrameCoordinates(0, 32),
				new FrameCoordinates(0, 32),
				new FrameCoordinates(0, 32),
				new FrameCoordinates(0, 32),
				new FrameCoordinates(0, 32),
				new FrameCoordinates(32, 32),
				new FrameCoordinates(32, 32),
				new FrameCoordinates(32, 32),
				new FrameCoordinates(32, 32),
				new FrameCoordinates(32, 32)
			}
		},
		new AnimationFrame()
		{
			animationName = "IdleRight",
			frames = new List<FrameCoordinates>()
			{
				new FrameCoordinates(64, 32)
			}
		},
		new AnimationFrame()
		{
			animationName = "Right",
			frames = new List<FrameCoordinates>()
			{
				new FrameCoordinates(96, 32),
				new FrameCoordinates(96, 32),
				new FrameCoordinates(96, 32),
				new FrameCoordinates(96, 32),
				new FrameCoordinates(96, 32),
				new FrameCoordinates(0, 64),
				new FrameCoordinates(0, 64),
				new FrameCoordinates(0, 64),
				new FrameCoordinates(0, 64),
				new FrameCoordinates(0, 64)
			}
		},
		new AnimationFrame()
		{
			animationName = "IdleLeft",
			frames = new List<FrameCoordinates>()
			{
				new FrameCoordinates(32, 64)
			}
		},
		new AnimationFrame()
		{
			animationName = "Left",
			frames = new List<FrameCoordinates>()
			{
				new FrameCoordinates(64, 64),
				new FrameCoordinates(64, 64),
				new FrameCoordinates(64, 64),
				new FrameCoordinates(64, 64),
				new FrameCoordinates(64, 64),
				new FrameCoordinates(96, 64),
				new FrameCoordinates(96, 64),
				new FrameCoordinates(96, 64),
				new FrameCoordinates(96, 64),
				new FrameCoordinates(96, 64)
			}
		}
	};

	public enum Direction {UP,DOWN,LEFT,RIGHT}

	public Direction direction = Direction.UP;
	
	
	public int frame = 0;
	public int maxFrameCount = 10;

	public override void _Ready()
	{
		base._Ready();
		sprite = GetNode<Sprite>("Sprite");
		respawnPoint = GlobalPosition;
	}


	public void GetInput()
	{
		velocity = new Vector2();

		if (Input.IsActionPressed("Right"))
		{
			if (direction != Direction.RIGHT)
			{
				direction = Direction.RIGHT;
				frame = 0;
			}
			
			var region = animationFrames.Where(x => x.animationName == "Right").FirstOrDefault().frames[frame];
			sprite.RegionRect = new Rect2(new Vector2(region.x, region.y), new Vector2(32, 32));

			frame++;

			if (frame == maxFrameCount)
			{
				frame = 0;
			}
			
			velocity.x += 1;
		}
		else if (Input.IsActionPressed("Left"))
		{
			if (direction != Direction.LEFT)
			{
				direction = Direction.LEFT;
				frame = 0;
			}
			
			var region = animationFrames.Where(x => x.animationName == "Left").FirstOrDefault().frames[frame];
			sprite.RegionRect = new Rect2(new Vector2(region.x, region.y), new Vector2(32, 32));

			frame++;

			if (frame == maxFrameCount)
			{
				frame = 0;
			}
			
			velocity.x -= 1;
		}
		else if (Input.IsActionPressed("Down"))
		{
			
			if (direction != Direction.DOWN)
			{
				direction = Direction.DOWN;
				frame = 0;
			}
			
			var region = animationFrames.Where(x => x.animationName == "Down").FirstOrDefault().frames[frame];
			sprite.RegionRect = new Rect2(new Vector2(region.x, region.y), new Vector2(32, 32));

			frame++;

			if (frame == maxFrameCount)
			{
				frame = 0;
			}
			
			velocity.y += 1;
		}
		else if (Input.IsActionPressed("Up"))
		{
			if (direction != Direction.UP)
			{
				direction = Direction.UP;
				frame = 0;
			}
			
			var region = animationFrames.Where(x => x.animationName == "Up").FirstOrDefault().frames[frame];
			sprite.RegionRect = new Rect2(new Vector2(region.x, region.y), new Vector2(32, 32));

			frame++;

			if (frame == maxFrameCount)
			{
				frame = 0;
			}
			
			velocity.y -= 1;
		}
		else
		{
			FrameCoordinates region = new FrameCoordinates(0,0);
			switch (direction)
			{
				case Direction.UP:
					region = animationFrames.Where(x => x.animationName == "IdleUp").FirstOrDefault().frames[0];
					sprite.RegionRect = new Rect2(new Vector2(region.x, region.y), new Vector2(32, 32));
					break;
				case Direction.DOWN:
					region = animationFrames.Where(x => x.animationName == "IdleDown").FirstOrDefault().frames[0];
					sprite.RegionRect = new Rect2(new Vector2(region.x, region.y), new Vector2(32, 32));
					break;
				case Direction.LEFT:
					region = animationFrames.Where(x => x.animationName == "IdleLeft").FirstOrDefault().frames[0];
					sprite.RegionRect = new Rect2(new Vector2(region.x, region.y), new Vector2(32, 32));
					break;
				case Direction.RIGHT:
					region = animationFrames.Where(x => x.animationName == "IdleRight").FirstOrDefault().frames[0];
					sprite.RegionRect = new Rect2(new Vector2(region.x, region.y), new Vector2(32, 32));
					break;
			}
		}

		velocity = velocity.Normalized() * speed;
	}

	private bool messageSent = false;
	private bool waitingToRespawn = false;

	public override void _PhysicsProcess(float delta)
	{
		if (GameStart.good.Visible)
		{
			sprite.Texture = GD.Load<Texture>("res://textures/characters/Simon.png");
		}
		else
		{
			sprite.Texture = GD.Load<Texture>("res://textures/characters/Lewis.png");
		}
		
		if (!UI.dialogue.IsPopupOpen && !UI.gameOver.GameOverShowing)
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

				if (collisionName.Contains("JaffaCake"))
				{
					jaffaCakes++;
					((Node) collision.Collider).QueueFree();
				}

				if (collisionName.Contains("RespawnPoint"))
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
					if (hearts == 0)
					{
						UI.gameOver.ShowGameOver();
					}
					else
					{
						GlobalPosition = respawnPoint;
						waitingToRespawn = false;
					}
				}

				if (collisionName.Contains("Portal"))
				{
					var portal = ((Portal) collision.Collider);

					if (portal != null)
					{
						if (portal.teleportToStart)
						{
							GlobalPosition = respawnPoint;
						}
						else
						{
							GlobalPosition = portal.positionToTeleport;
						}
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
