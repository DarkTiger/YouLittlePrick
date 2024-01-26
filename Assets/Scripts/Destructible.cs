using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Destructible : MonoBehaviour
{
    [SerializeField] int hitToDestroy = 3;
    SpriteRenderer spriteRenderer;
    VisualEffect visualEffect;

    int health = -1;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        visualEffect = GetComponentInChildren<VisualEffect>();
        
        health = hitToDestroy;
    }

    private void Start()
    {
        visualEffect.Stop();
    }

    public void GetHitDamage()
    {
        health--;

        if (health <= 0)
        {
            DestroyThis();
        }
        else
        {
            StartCoroutine(DamageEffect());
        }
    }

    IEnumerator DamageEffect() 
    {
        spriteRenderer.color = Color.red;
        transform.localScale = Vector3.one * 1.2f;

        yield return new WaitForSeconds(0.075f);

        spriteRenderer.color = Color.white;
        transform.localScale = Vector3.one;
    }

    void DestroyThis()
    {
        if (Random.Range(0f, 100f) <= Gamemanager.instance.MissionPickableDropsChance)
        {
            Instantiate(Gamemanager.instance.GetRandomPickable().gameObject, transform.position + (Vector3.up * 0.5f), Quaternion.identity);
        }

        StopAllCoroutines();
        visualEffect.transform.parent = null;
        visualEffect.Play();
        Destroy(visualEffect, 3);
        Destroy(gameObject);
    }
}
