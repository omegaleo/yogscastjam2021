using Godot;
using System;

public class Portal : StaticBody2D
{
	[Export] public Vector2 positionToTeleport;
	[Export] public bool teleportToStart;
}
