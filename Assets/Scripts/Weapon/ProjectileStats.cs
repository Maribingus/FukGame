using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile", menuName = "Projectile")]


public class ProjectileStats : ScriptableObject
{
    public Sprite sprite;
    public float damage;
    public float speed;
    public float knockback;
    public float sizeX;
    public float sizeY;

}
