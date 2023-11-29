using Godot;
using System;

public partial class hud : Control
{
    public Health health;
    public player player;
    public float actual_health;
    public ProgressBar progressbar;

    public override void _Ready()
    {
        progressbar = (ProgressBar)GetNode("Panel").GetNode("HealthBar");
    }

    public override void _Process(double delta)
    {
        health = (Health)GetTree().Root.GetNode("World").GetNode("Player").GetNode("Health");
        player = (player)GetTree().Root.GetNode("World").GetNode("Player");
        actual_health = health.returnHealth();
        progressbar.Value = actual_health;
    }


}
