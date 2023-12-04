using Godot;
using System;

public partial class Pistol : Node2D
{
    [Export] public float damage = 20f;
    

    public float getDamage()
    {
        return damage;
    }
}
