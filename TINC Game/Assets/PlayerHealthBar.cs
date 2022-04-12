using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthBar : MonoBehaviour
{
    public float Hitpoints;
    public float maxHitpoints = 5;
    public HealthbarBehaviour Healthbar;

    void Start()
    {
        Hitpoints = maxHitpoints;
        Healthbar.SetHealth(Hitpoints, maxHitpoints);
    }

    public void TakeHit(float damage)
    {
        Hitpoints -= maxHitpoints;
        Healthbar.SetHealth(Hitpoints, maxHitpoints);

        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }

}
