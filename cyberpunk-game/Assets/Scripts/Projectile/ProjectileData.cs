using UnityEngine;

[System.Serializable]
public class ProjectileData
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float speed = 16;
    [SerializeField, Min(1)] private int pierce = 1;

    public int Damage
    {
        get => damage;
        set
        {
            if (value >= 0f)
            {
                damage = value;
            }
        }
    }

    public float Speed
    {
        get => speed;
        set
        {
            if (value >= 0f)
            {
                speed = value;
            }
        }
    }

    public int Pierce
    {
        get => pierce;
        set
        {
            if (value >= 1)
            {
                pierce = value;
            }
        }
    }
}