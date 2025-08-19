using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public TMP_Text manaText;
    private Wizard wizard;

    void Start()
    {
        // Find Wizard
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            player = GameObject.Find("Wizard");
        }

        if (player != null)
        {
            wizard = player.GetComponent<Wizard>();
            if (wizard != null)
            {
                // Subscribe to mana change event
                wizard.OnManaChanged += UpdateManaText;
                UpdateManaText(wizard.mana); // set initial text
            }
        }

        // Grab TMP_Text
        manaText = transform.GetChild(0).GetComponent<TMP_Text>();
    }

    private void UpdateManaText(int newMana)
    {
        manaText.text = "Mana: " + newMana;
    }

    void OnDestroy()
    {
        if (wizard != null)
        {
            wizard.OnManaChanged -= UpdateManaText;
        }
    }
}
