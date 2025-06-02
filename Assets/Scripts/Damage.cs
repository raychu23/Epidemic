using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This target can receive damage.
/// </summary>
public class Damage : MonoBehaviour
{
    // Damage visual effect duration
    public float damageDisplayTime = 0.2f;
    // SendMessage will trigger on damage taken
    public bool isTrigger;
    // Die sound effect
    public AudioClip dieSfx;
    // Represents weakness color
    public Weakness weakness;
    // Time for death
    public float deathTime;
    // Image on death
    // public Sprite deathImage;

    // Image of this object
    private SpriteRenderer sprite;
    // Visualisation of hit or heal is in progress
    private bool coroutineInProgress;
    // Effectivness variable
    private int effectiveness;
    // Tower modifier
    // In animation of shrink
    private bool capturing = false;
    // Level Manager
    private LevelManager lvlManager;
    // When object is in death animation
    private bool isDying = false;

    /// <summary>
    /// Awake this instance.
    /// </summary>
    void Awake()
    {
        lvlManager = FindObjectOfType<LevelManager>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        Debug.Assert(sprite, "Wrong initial parameters");
    }

    /// <summary>
    /// Take damage.
    /// </summary>
    /// <param name="incomingMedicine">Damage.</param>
    public bool TakeDamage(Medicine incomingMedicine, Tower tower)
    {
        switch (weakness)
        {
            case Weakness.Blue:
                effectiveness = incomingMedicine.blueEffectiveness;
                break;
            case Weakness.Red:
                effectiveness = incomingMedicine.redEffectiveness;
                break;
            case Weakness.Purple:
                effectiveness = incomingMedicine.purpleEffectiveness;
                break;
            case Weakness.Null:
                effectiveness = 0;
                break;
        }

        switch (incomingMedicine.gameObject.name)
        {
            case "Med R":
                effectiveness += tower.redToPurpleEM;
                break;
            case "Med B":
                effectiveness += tower.blueToPurpleEM;
                break;
            case "Med P":
                {
                    if(weakness.Equals(Weakness.Blue)) {
                        effectiveness += tower.purpleToBlueEM;
                    } else
                    {
                        effectiveness += tower.purpleToRedEM;
                    }
                    break;
                }
            case "Med G":
                if (weakness.Equals(Weakness.Blue))
                {
                    effectiveness += tower.greenToBlueEM;
                }
                else
                {
                    effectiveness += tower.greenToRedEM;
                }
                break;
            case "Med O":
                if (weakness.Equals(Weakness.Blue))
                {
                    effectiveness += tower.orangeToBlueEM;
                }
                else
                {
                    effectiveness += tower.orangeToRedEM;
                }
                break;
            case "Med Y":
                if (weakness.Equals(Weakness.Blue))
                {
                    effectiveness += tower.yellowToBlueEM;
                }
                else
                {
                    effectiveness += tower.yellowToRedEM;
                }
                break;
            default:
                break;
        }

        if (this.enabled == true)
        {
            int rand = Random.Range(1, 101);
            if (rand <= effectiveness)
            {
                Die();
                return true;
            }
        }
        return false;
    }

    public bool GetCapturing()
    {
        return capturing;
    }

    public bool GetIsDying()
    {
        return isDying;
    }

    public void Capture(float duration)
    {
        capturing = true;
        StartCoroutine(CaptureCoroutine(duration));
    }

    /// <summary>
    /// Capture coroutine for animation
    /// </summary>
    /// <returns></returns>
    private IEnumerator CaptureCoroutine(float duration)
    {
        DeactivateAI();
        float counter = 0;
        Vector3 startScaleSize = gameObject.transform.localScale;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            gameObject.transform.localScale = Vector3.Lerp(startScaleSize, new Vector3(0, 0), counter / duration);
            yield return null;
        }

        Destroy(gameObject);
    }


    /// <summary>
    /// Die this instance.
    /// </summary>
    public void Die()
    {
        EventManager.TriggerEvent("UnitKilled", gameObject, null);
        isDying = true;
        StartCoroutine(DieCoroutine());
    }

    private IEnumerator DieCoroutine()
    {
        if (dieSfx != null && AudioManager.instance != null)
        {
            AudioManager.instance.PlayDie(dieSfx);
        }

        DeactivateAI();


        Animator anim = GetComponent<Animator>();

        /* Particle and death image system
        ParticleSystem partSys = GetComponent<ParticleSystem>();
        if (deathImage != null)
        {

            SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
            sr.sprite = deathImage;
            transform.localScale = new Vector3(8f, 8f);
        }

        if (partSys != null)
        {
            partSys.Play();
            yield return new WaitForSeconds(partSys.main.duration);
        }
        */

        // If unit has animator
        if (anim != null && anim.runtimeAnimatorController != null)
        {
            // Search for clip
            foreach (AnimationClip clip in anim.runtimeAnimatorController.animationClips)
            {
                if (clip.name == "Die")
                {
                    // Play animation
                    anim.SetTrigger("die");
                    yield return new WaitForSeconds(deathTime);
                    break;
                }
            }
        }
        Destroy(gameObject);
    }

    /// <summary>
    /// Damage visualisation.
    /// </summary>
    /// <returns>The damage.</returns>
    IEnumerator DisplayDamage()
    {
        coroutineInProgress = true;
        Color originColor = sprite.color;
        float counter;
        // Set color to black and return to origin color over time
        for (counter = 0f; counter < damageDisplayTime; counter += Time.fixedDeltaTime)
        {
            sprite.color = Color.Lerp(originColor, Color.black, Mathf.PingPong(counter, damageDisplayTime / 2f));
            yield return new WaitForFixedUpdate();
        }
        sprite.color = originColor;
        coroutineInProgress = false;
    }

    private void DeactivateAI()
    {
        foreach (Collider2D col in GetComponentsInChildren<Collider2D>())
        {
            col.enabled = false;
        }
        GetComponent<AiBehavior>().enabled = false;
        GetComponent<NavAgent>().enabled = false;
        GetComponent<EffectControl>().enabled = false;
    }

    /// <summary>
    /// Raises the destroy event.
    /// </summary>
    void OnDestroy()
    {
        EventManager.TriggerEvent("UnitDie", gameObject, null);
        StopAllCoroutines();
    }
}
