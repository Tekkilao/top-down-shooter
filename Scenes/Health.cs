using Godot;
using System;

public partial class Health : Node2D
{
    [Export] public float max_health = 100f;
    float health;

    public override void _Ready()
    {
        health = max_health;
    }


    public void Damage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            GetParent().QueueFree();
        }

    }

    public float returnHealth()
    {
        return health;
    }
}
