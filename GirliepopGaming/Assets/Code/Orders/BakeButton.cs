using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeButton : MonoBehaviour
{
    public GameObject bakedDish;

    public Animator ovenAnim;

    public AudioClip ovenDoneSound;
    [Range(0, 100)]
    public float volume = 100f;

    public SpriteRenderer bowlBack;
    public SpriteRenderer bowlFront;
    public SpriteRenderer toppingImage;
    public SpriteRenderer baseImage;

    public BoxCollider2D bowlCollider;

    private AudioSource secondAudio;


    private void Start()
    {
        secondAudio = Camera.main.gameObject.transform.GetChild(1).GetComponent<AudioSource>();
    }

    private void OnMouseUpAsButton()
    {
        if(KitchenDish.instance.toppingIngredient == Ingredient.None || KitchenDish.instance.baseIngredient == Ingredient.None)
        {
            return;
        }

        StartCoroutine(WaitForBakeFinish());
    }

    private IEnumerator WaitForBakeFinish()
    {
        ovenAnim.SetTrigger("ToPrepare");

        bowlBack.enabled = false;
        bowlFront.enabled = false;
        bowlCollider.enabled = false;
        baseImage.sprite = null;
        toppingImage.sprite = null;

        yield return new WaitForSeconds(4);

        secondAudio.Stop();
        secondAudio.clip = ovenDoneSound;
        secondAudio.volume = volume;
        secondAudio.Play();

        KitchenDish.instance.BakeDish();
        
        bowlBack.enabled = true;
        bowlFront.enabled = true;
        bowlCollider.enabled = true;
    }
}
