using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{

    public Image dreamAbility;
    public Image nightmareAbility;
    public CharacterController myPlayer;

    public Image dreamCooldown;
    public Image nightmareCooldown;

    public float refreshRate;

    private bool launchDream = true;
    private bool launchNightmare = true;

    public GPSAbility gpsAbility;
    public BAITAbility baitAbility;
    
	// Start
	void Start ()
    {
		


	}
	
	// Update
	void Update ()
    {

        UIAbilityIndicator();
        AbilityCooldown();

    }

    public void UIAbilityIndicator()
    {
        if (myPlayer.reve == true)
        {
            nightmareAbility.enabled = false;
            dreamAbility.enabled = true;
        }
        else if (myPlayer.reve == false)
        {
            dreamAbility.enabled = false;
            nightmareAbility.enabled = true;
        }
    }

    public void AbilityCooldown()
    {
        if(gpsAbility.isLaunching == true && launchDream == true)
        {
            dreamCooldown.enabled = true;
            dreamCooldown.fillAmount = 1;
            InvokeRepeating("DreamCooldown", 0, gpsAbility.gpsCooldownTime * (1 / (gpsAbility.gpsCooldownTime / refreshRate)));
            launchDream = false;
        }

        else if (baitAbility.baitIsLaunched == true && launchNightmare == true)
        {
            nightmareCooldown.enabled = true;
            nightmareCooldown.fillAmount = 1;
            InvokeRepeating("NightmareCooldown", 0, baitAbility.baitCooldownTime * (1 / (baitAbility.baitCooldownTime / refreshRate)));
            launchNightmare = false;
        }

        if (dreamCooldown.fillAmount == 0)
        {
            CancelInvoke("DreamCooldown");
            launchDream = true;
        }

        if (nightmareCooldown.fillAmount == 0)
        {
            CancelInvoke("NightmareCooldown");
            launchNightmare = true;
        }

    }

    public void DreamCooldown()
    {
        dreamCooldown.fillAmount = dreamCooldown.fillAmount - 1 / (gpsAbility.gpsCooldownTime / refreshRate);
    }

    public void NightmareCooldown()
    {
        nightmareCooldown.fillAmount = nightmareCooldown.fillAmount - 1 / (baitAbility.baitCooldownTime / refreshRate); 
    }

}
