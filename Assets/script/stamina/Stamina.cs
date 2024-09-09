using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public float stamina;
    public float maxStamina; 
    public Slider staminaBar;
    public float dValue;
    public float refillAmount; 
    public float delayBeforeRefill = 3f; 
    private float refillTimer = 0f; 
    private bool canSprint = true;

    private CanvasGroup staminaBarCanvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        maxStamina = stamina;
        staminaBar.maxValue = maxStamina;

        staminaBarCanvasGroup = staminaBar.GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            DecreaseEnergy();
        else if (stamina < maxStamina)
            IncreaseEnergy();

        canSprint = stamina > (maxStamina * 0.2f);

        staminaBar.value = stamina;

        // Memainkan nilai alpha berdasarkan value Slider
        float targetAlpha = 1f;
        if (stamina >= maxStamina)
        {
            targetAlpha = 0f;
        }
        else if (stamina >= maxStamina * 0.90f)
        {
            targetAlpha = 1f;
        }

        staminaBarCanvasGroup.alpha = Mathf.Lerp(staminaBarCanvasGroup.alpha, targetAlpha, Time.deltaTime);
    }

    private void DecreaseEnergy()
    {
        if (stamina > 0)
            stamina -= dValue * Time.deltaTime;
        
        refillTimer = 0f;
    }

    private void IncreaseEnergy()
    {
        if (refillTimer >= delayBeforeRefill)
        {
            stamina += refillAmount * Time.deltaTime;
            stamina = Mathf.Clamp(stamina, 0f, maxStamina);
        }
        else
        {
            refillTimer += Time.deltaTime;
        }
    }
}
