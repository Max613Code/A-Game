using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class UIHandler
{
    private static Text healthText = GameObject.Find("HealthText").GetComponent<Text>();
    
    // Start is called before the first frame update
    

    // Update is called once per frame
    static void Update()
    {
        
    }

    public static void UpdateHealthText(float health)
    {
        healthText.text = "Health: " + health;
    }
}
