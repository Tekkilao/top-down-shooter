using Godot;
using System;

public partial class bullet : RigidBody2D
{
    // [Export] public float damage = 10;
    public Gun gun;
    public float damage;
    	[Export] PackedScene blood_scn;


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
            SpawnBlood(body.GlobalPosition);
        }

        QueueFree();
    }

    private void SpawnBlood(Vector2 position)
{
    if (blood_scn != null)
    {
        CpuParticles2D blood = (CpuParticles2D)blood_scn.Instantiate();
        GetTree().Root.AddChild(blood);
        blood.GlobalPosition = position; // Configura a posição das partículas
    }
}
}
