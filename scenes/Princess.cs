using Godot;
using System;

public partial class Princess : Area2D
{
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}
	
	private void OnBodyEntered(Node body)
	{
		if (body is CharacterBody2D character)
		{
			character.QueueFree();
		}
	}
}
