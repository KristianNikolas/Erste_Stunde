using UnityEngine;
using System;

public class Wizard : MonoBehaviour
{
    [Header("Spells")]
    public GameObject fireballPrefab;
    public int fireballManaCost = 10;

    [Header("Mana System")]
    public int maxMana = 100;
    public int mana = 100;
    public float manaRegenRate = 5f; // mana per second

    // Event for UI
    public event Action<int> OnManaChanged;

    void Update()
    {
        Movement();
        Casting();
        RegenerateMana();
    }

    private void Movement()
    {
        Vector3 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) movement += Vector3.up;
        if (Input.GetKey(KeyCode.S)) movement += Vector3.down;
        if (Input.GetKey(KeyCode.A)) movement += Vector3.left;
        if (Input.GetKey(KeyCode.D)) movement += Vector3.right;

        if (movement.magnitude > 1) movement.Normalize();
        transform.position += movement * Time.deltaTime * 3;
    }

    private void Casting()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (mana >= fireballManaCost)
            {
                Vector3 position = transform.position + new Vector3(-0.5f, 0.4f, 0);
                Instantiate(fireballPrefab, position, Quaternion.identity);

                ChangeMana(-fireballManaCost);
            }
            else
            {
                Debug.Log("Not enough mana to cast Fireball!");
            }
        }
    }

    private void RegenerateMana()
    {
        if (mana < maxMana)
        {
            ChangeMana(Mathf.CeilToInt(manaRegenRate * Time.deltaTime));
        }
    }

    private void ChangeMana(int amount)
    {
        int oldMana = mana;
        mana = Mathf.Clamp(mana + amount, 0, maxMana);

        if (mana != oldMana)
        {
            OnManaChanged?.Invoke(mana);
        }
    }
}
