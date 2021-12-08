using Godot;
using System;

public class SFX : AudioStreamPlayer
{
	[Export] public float maxVolume = 0;
	[Export] public float minVolume = -45;

	public override void _Ready()
	{
		base._Ready();
		VolumeDb = (minVolume * 50) / 100;
	}
	
	public void PlaySFX(string path)
	{
		Stream = GD.Load<AudioStream>(path);
		Play();
		
	}
}
