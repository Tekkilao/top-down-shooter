using Godot;
using System;

public partial class enemy_spawner : Node2D
{
    [Export] PackedScene enemy_scn;
    [Export] Node2D[] spawn_points;
    [Export] float eps = 1f;
    [Export] int max_enemies = 20;

    int number_of_enemies;
    float spawn_rate;

    float time_until_spawn = 0;

    public override void _Ready()
    {
        spawn_rate = 1 / eps;
    }

    public override void _Process(double delta)
    {     
        var enemies_on_screen = GetTree().GetNodesInGroup("enemy");


        if(time_until_spawn > spawn_rate && number_of_enemies <= max_enemies)
        {
            Spawn();
            time_until_spawn = 0;
        } else {
            time_until_spawn += (float)delta;
        }
        number_of_enemies = enemies_on_screen.Count + 1;
    }
    
    private void Spawn()
    {
        RandomNumberGenerator rgn = new RandomNumberGenerator();
        Vector2 location = spawn_points[rgn.Randi() % spawn_points.Length].GlobalPosition;
        Enemy enemy = (Enemy)enemy_scn.Instantiate();
        enemy.GlobalPosition = location;
        GetTree().Root.AddChild(enemy);

    }

}
