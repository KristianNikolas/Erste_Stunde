using UnityEngine;
using System;

public class Wizard : MonoBehaviour
{
    [Header("Player Stats")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Mana System")]
    public int maxMana = 100;
    public int mana = 100;
    public float manaRegenRate = 5f;
    public int fireballManaCost = 10;

    [Header("Movement Settings")]
    public float moveSpeed = 3f;

    [Header("Spells")]
    public GameObject fireballPrefab;  // Dein Feuerball-Prefab
    public float fireballSpeed = 6f;

    public event Action<int> OnManaChanged;

    private SpriteRenderer spriteRenderer;
    private Vector2 lastMoveDirection = Vector2.right; // Letzte Bewegungsrichtung

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        HandleMovement();
        HandleCasting();
        RegenerateMana();
    }

    // ---------------------------
    // Bewegung & Drehen
    // ---------------------------
    private void HandleMovement()
    {
        Vector2 movement = Vector2.zero;

        if (Input.GetKey(KeyCode.W)) movement += Vector2.up;
        if (Input.GetKey(KeyCode.S)) movement += Vector2.down;
        if (Input.GetKey(KeyCode.A)) movement += Vector2.left;
        if (Input.GetKey(KeyCode.D)) movement += Vector2.right;

        if (movement.magnitude > 1) movement.Normalize();

        // Position anwenden
        transform.position += (Vector3)movement * moveSpeed * Time.deltaTime;

        // Letzte Bewegungsrichtung speichern
        if (movement != Vector2.zero)
            lastMoveDirection = movement;

        // Sprite drehen nach links/rechts
        if (movement.x < 0)
            spriteRenderer.flipX = true;
        else if (movement.x > 0)
            spriteRenderer.flipX = false;
    }

    // ---------------------------
    // Zaubern
    // ---------------------------
    private void HandleCasting()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (mana >= fireballManaCost)
            {
                ShootFireball();
                ChangeMana(-fireballManaCost);
            }
            else
            {
                Debug.Log("Nicht genug Mana!");
            }
        }
    }

    private void ShootFireball()
    {
        // Spawn-Position = Wizard + Offset in Bewegungsrichtung
        Vector3 spawnPos = transform.position + (Vector3)(lastMoveDirection.normalized * 0.5f);

        GameObject fireball = Instantiate(fireballPrefab, spawnPos, Quaternion.identity);

        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = lastMoveDirection.normalized * fireballSpeed;
        }

        // Optional: Fireball drehen, damit Sprite Richtung anzeigt
        float angle = Mathf.Atan2(lastMoveDirection.y, lastMoveDirection.x) * Mathf.Rad2Deg;
        fireball.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    // ---------------------------
    // Mana
    // ---------------------------
    private void RegenerateMana()
    {
        if (mana < maxMana)
            ChangeMana(Mathf.CeilToInt(manaRegenRate * Time.deltaTime));
    }

    private void ChangeMana(int amount)
    {
        int oldMana = mana;
        mana = Mathf.Clamp(mana + amount, 0, maxMana);

        if (mana != oldMana)
            OnManaChanged?.Invoke(mana);
    }
}
