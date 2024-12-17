using Godot;
using System;

public partial class Temon : RigidBody2D
{
	private int hearts = 3;
	
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
				hearts -= 1;
				
				if(hearts == 0)
				{
					QueueFree();
					GD.Print("Temon Dikalahkan");
				}
				else
				{
					GD.Print("Sisa nyawa temon: " + hearts);
				}
			}
			else
			{
				GetTree().ReloadCurrentScene();
			}
		}
	}
}
