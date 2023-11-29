using Godot;
using System;

public partial class player : CharacterBody2D
{
	public const float playerSpeed = 500;	

	// private RigidBody2D bullet;


	public override void _Ready()
	{
	}

	// public void _Process()
	// {
	// 	    CpuParticles2D bullet = (CpuParticles2D)blood_scn.Instantiate<CpuParticles2D>();
    //         bullet.Rotation = GlobalRotation;
    //         bullet.GlobalPosition = GlobalPosition;
    //         GetTree().Root.AddChild(bullet);

	// }

	public void GetInput()
	{
		Vector2 inputDirection = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		Velocity = inputDirection * playerSpeed;
	}
	// Called every frame. "delta" is the elapsed time since the previous frame.

	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndSlide();
		LookAt(GetGlobalMousePosition());
	}

}
