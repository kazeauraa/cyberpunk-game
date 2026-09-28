using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Bar bar;
    [SerializeField] private Life life;

    public Life Life
    {
        get
        {
            return life;
        }

        set
        {
            if (value != null)
            {
                if (life != null)
                {
                    life.OnHealthChanged -= HandleHealth;
                }

                life = value;

                bar.SetMaxValue(life.MaxHealth);
                bar.SetValue(life.Health);

                life.OnHealthChanged += HandleHealth;
            }
        }
    }

    private void Start()
    {
        bar.SetMaxValue(life.MaxHealth);
        bar.SetValue(life.Health);
    }

    private void OnEnable()
    {
        if (life != null && bar != null)
        {
            bar.SetMaxValue(life.MaxHealth);
            bar.SetValue(life.Health);

            life.OnHealthChanged += HandleHealth;
        }
    }

    private void OnDisable()
    {
        if (life != null)
        {
            life.OnHealthChanged -= HandleHealth;
        }
    }

    private void HandleHealth()
    {
        if (life != null && bar != null)
        {
            bar.SetValue(life.Health);
        }
    }
}