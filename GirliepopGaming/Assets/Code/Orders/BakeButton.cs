using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeButton : MonoBehaviour
{
    public GameObject bakedDish;

    public Animator ovenAnim;

    public SpriteRenderer bowlBack;
    public SpriteRenderer bowlFront;
    public SpriteRenderer toppingImage;
    public SpriteRenderer baseImage;

    public BoxCollider2D bowlCollider;

    private void OnMouseUpAsButton()
    {
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

        KitchenDish.instance.BakeDish();
        bowlBack.enabled = true;
        bowlFront.enabled = true;
        bowlCollider.enabled = true;
    }
}
