using Godot;
using System;

public partial class Gun : Node2D
{
    [Export] PackedScene bullet_scn;
    [Export] float bullet_speed = 600f;
    [Export] float bps = 5;
    [Export] float bullet_damage = 30f;
    [Export] int gun_ammo = 6;
    public AudioStreamPlayer2D glockSound;

    float fire_rate;

    float time_until_fire = 0f;

    public override void _Ready()
    {
        glockSound = (AudioStreamPlayer2D)GetTree().Root.GetNode("World").GetNode("Player").GetNode("Gun").GetNode("glockSound");
        fire_rate = 1 / bps;
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("click") && time_until_fire > fire_rate && gun_ammo > 0)
        {
            glockSound.Play();
            RigidBody2D bullet = bullet_scn.Instantiate<RigidBody2D>();
            bullet.Rotation = GlobalRotation;
            bullet.GlobalPosition = GlobalPosition;
            bullet.LinearVelocity = bullet.Transform.X * bullet_speed;
            
            GetTree().Root.AddChild(bullet);
            gun_ammo -= 1;
            time_until_fire = 0f;
        } else {
            time_until_fire += (float)delta;
        }

        Reload();

    }

    public void Reload()
    {
        if(Input.IsActionJustPressed("reload"))
        {
            gun_ammo = 6;
        }
    }

    public float GetBulletDamage()
    {
        return bullet_damage;
    }
}
