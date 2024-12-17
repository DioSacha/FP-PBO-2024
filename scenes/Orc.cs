using Godot;
using System;

public partial class Orc : RigidBody2D
{
	public override void _Ready()
	{
	}

	private void OnBodyEntered(Node body)
	{
		if (body is CharacterBody2D character)
		{
			float yDelta = Position.Y - character.Position.Y;
			if (yDelta > 70)
			{
				QueueFree();
			}
			else
			{
				GetTree().ReloadCurrentScene();
			}
		}
	}
}
