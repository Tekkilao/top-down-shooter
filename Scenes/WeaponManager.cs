using Godot;
using System;

public partial class WeaponManager : Node2D
{
    [Export] PackedScene bullet_scn;
    [Export] float bullet_speed = 1000f;
    [Export] float bps = 5;
    [Export] float bullet_damage = 30f;
    [Export] int gun_ammo = 6;
    public AudioStreamPlayer2D glockSound;
    public AnimationPlayer animation;
    // public Gun pistol;

        float fire_rate;

    float time_until_fire = 0f;

    public override void _Ready()
    {
        // pistol = (Gun)GetTree().Root.GetNode("World").GetNode("Player").GetNode("WeaponManager").GetNode("Pistol");


        // glockSound = (AudioStreamPlayer2D)GetTree().Root.GetNode("World").GetNode("Player").GetNode("Gun").GetNode("glockSound");
        // animation = (AnimationPlayer)GetTree().Root.GetNode("World").GetNode("Player").GetNode("Gun").GetNode("AnimationPlayer");

        fire_rate = 1 / bps;
    }
    public override void _Process(double delta)
    {
        Shoot(delta);

    }

    public void Shoot(double delta)
    {
        if (Input.IsActionJustPressed("click") && time_until_fire > fire_rate && gun_ammo > 0)
        {
            // animation.Play("muzzle_flash");
            // glockSound.Play();
            RigidBody2D bullet = bullet_scn.Instantiate<RigidBody2D>();
            bullet.Rotation = GlobalRotation;
            bullet.GlobalPosition = GlobalPosition;
            bullet.LinearVelocity = bullet.Transform.X * bullet_speed;
            GetTree().Root.AddChild(bullet);
            time_until_fire = 0f;
        } else {
            time_until_fire += (float)delta;
        }
    }
        public float GetBulletDamage()
    {
        return bullet_damage;
    }
}
