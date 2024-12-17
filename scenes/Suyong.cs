using Godot;
using System;

public partial class Suyong : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -500.0f;
	
	private AnimatedSprite2D _animatedSprite2D;

	public override void _Ready()
	{
		_animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}
		
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
			_animatedSprite2D.Animation = "jumping";
		}
		else
		{
			// Handle animations only if the character is on the floor
			if (velocity.X > 1 || velocity.X < -1)
			{
				_animatedSprite2D.Animation = "running";
			}
			else
			{
				_animatedSprite2D.Animation = "default";
			}
		}

		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity; // Gunakan JumpVelocity yang sudah didefinisikan
			_animatedSprite2D.Animation = "jumping";
		}

		Vector2 direction = Input.GetVector("left", "right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, 35);
		}

		Velocity = velocity; // Set kembali ke Velocity
		MoveAndSlide();
		
		bool isLeft = velocity.X < 0;
		_animatedSprite2D.FlipH = isLeft;
	}
}
