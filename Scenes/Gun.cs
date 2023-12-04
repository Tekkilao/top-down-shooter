using Godot;
using System;
using System.Collections.Generic;
public partial class Gun : Node2D
{
    [Export] PackedScene bullet_scn;
    [Export] float bullet_speed = 400f;
    [Export] float bps = 5;
    [Export] public float bullet_damage = 30f;
    [Export] int gun_ammo = 6;

    public AudioStreamPlayer2D gunSound;
    public AnimationPlayer animation;
    public Marker2D endOfGun;
    float fire_rate;

    float time_until_fire = 0f;

    public override void _Ready()
    {
        endOfGun = (Marker2D)GetNode("EndOfGun");
        gunSound = (AudioStreamPlayer2D)GetNode("gunSound");
        animation = (AnimationPlayer)GetNode("AnimationPlayer");

        fire_rate = 1 / bps;
    }

    public override void _Process(double delta)
    {
        Shoot((float)delta);
        Reload();

    }

    public void Reload()
    {
        if(Input.IsActionJustPressed("reload"))
        {
            gun_ammo = 6;
        }
    }

    public void Shoot(float delta)
    {
        if (Input.IsActionJustPressed("click") && time_until_fire > fire_rate && gun_ammo > 0)
        {

            RigidBody2D bullet = bullet_scn.Instantiate<RigidBody2D>();
            bullet.Rotation = endOfGun.GlobalRotation;
            bullet.GlobalPosition = endOfGun.GlobalPosition;
            bullet.LinearVelocity = bullet.Transform.X * bullet_speed;
            animation.Play("muzzle_flash");
            gunSound.Play();

            
            GetTree().Root.AddChild(bullet);
            gun_ammo -= 1;
            time_until_fire = 0f;
        } else {
            time_until_fire += delta;
        }

    }
    public float GetBulletDamage()
    {
        return bullet_damage;
    }
}
