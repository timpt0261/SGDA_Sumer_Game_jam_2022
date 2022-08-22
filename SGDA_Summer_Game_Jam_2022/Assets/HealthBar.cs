using UnityEngine;
using UnityEngine.UIElements;


public class HealthBar : MonoBehaviour
{
    public player player;
    private Image healthBar;
    private float currentHealth;
    private float max_Health = 10.0f;
    private void Awake()
    {
        player = GetComponent<player>();
        healthBar = GetComponent<Image>();      
        
    }

    private void Update()
    {
        currentHealth = player.health;
        healthBar.
    }
}
