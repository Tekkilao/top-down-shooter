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

    public void _Ready()
    {

    }
}
