using Godot;
using System;

public partial class Blood : CpuParticles2D
{
    public player player;

    public override void _Ready()
    {
        Timer timer = GetNode<Timer>("Timer");
        timer.Timeout += () => QueueFree();
    }
    public void _on_Timer_timeout()
    {
       QueueFree();
    }
}
