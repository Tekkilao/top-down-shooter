using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
    player player;
    [Export] float enemySpeed = 250f;
    [Export] float damage = 10f;
    [Export] float aps = 2f;
    
    float attack_speed;
    float time_until_attack;
    bool within_attack_range = false;

    public override void _Ready()
    {
        player = (player)GetTree().Root.GetNode("World").GetNode("Player");
        GD.Print(player.Name);
        attack_speed = 1 / aps;
        time_until_attack = attack_speed;
    }

    public override void _Process(double delta)
    {
        if (within_attack_range && time_until_attack <= 0)
        {
            Attack();
            time_until_attack = attack_speed;
        }
        else
        {
            time_until_attack -= (float)delta;
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        if (player != null)
        {
            LookAt(player.GlobalPosition);
            Vector2 direction = (player.GlobalPosition - GlobalPosition).Normalized();
            Velocity = direction * enemySpeed;
        }
        else
        {
            Velocity = Vector2.Zero;
        }

        MoveAndSlide();
    }

    public void Attack()
    {
        player.GetNode<Health>("Health").Damage(damage);
    }

    public void OnAttackRangeBodyEnter(Node2D body)
    {
        if (body.IsInGroup("player"))
        {
            GD.Print("entered");
            within_attack_range = true;
        }
    }

    public void OnAttackRangeBodyExit(Node2D body)
    {
        if (body.IsInGroup("player"))
        {
            GD.Print("Exit");
            within_attack_range = true;
            time_until_attack = attack_speed;
        }
    }

}
