using Godot;
using System;

public partial class FallArea : Area2D
{
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}
	
	private void OnBodyEntered(Node body)
	{
		if(body.Name == "CharacterBody2D")
		{
			GetTree().ReloadCurrentScene();
		}
	}
}
