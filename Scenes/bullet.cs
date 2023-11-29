using Godot;
using System;

public partial class bullet : RigidBody2D
{
    // [Export] public float damage = 10;
    public Gun gun;
    public float damage;

    public override void _Ready()
    {
        gun = (Gun)GetTree().Root.GetNode("World").GetNode("Player").GetNode("Gun");
        Timer timer = GetNode<Timer>("Timer");
        timer.Timeout += () => QueueFree();
        damage = gun.GetBulletDamage();
    }

    public void OnBodyEntered(Node2D body)
    {
        if (body.IsInGroup("enemy"))
        {
            body.GetNode<Health>("Health").Damage(damage);
        }

        QueueFree();
    }
}
