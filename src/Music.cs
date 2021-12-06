using Godot;
using System;

public class Music : AudioStreamPlayer
{
	[Export] public float maxVolume = 0;
	[Export] public float minVolume = -45;

	public override void _Ready()
	{
		base._Ready();
		VolumeDb = (minVolume * 50) / 100;
	}

	public void SetVolume(float percent)
	{
		if (percent == 0)
		{
			StreamPaused = true;
		}
		
		if (percent == 100)
		{
			StreamPaused = false;
			VolumeDb = maxVolume;
		}
		
		if (percent > 0 && percent < 100)
		{
			StreamPaused = false;
			VolumeDb = (minVolume * percent) / 100;
		}
	}
}
