using UnityEngine;
using UnityEngine.Events;
using System.Collections;


public class DragDish : MonoBehaviour
{

    public SpriteRenderer image;

    public Order order = null;

    public bool isTutorial = false;
    public UnityEvent executeOnDrop;

    private Vector3 screenPoint;
    private Vector3 offset;

    [HideInInspector]
    public Vector3 startPos;
    private bool inOtherCollider = false;

    private void Start()
    {
        startPos = transform.position;
    }

    private void OnMouseUp()
    {

        if(inOtherCollider)
        {

            SpawnCustomers.Instance.JudgeOrder();
            //Destroy(gameObject);
        }

        if(!inOtherCollider)
        {
            gameObject.transform.position = startPos;
        }
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Customer")
        {
            print("gay person detected");
            if (isTutorial)
            {
                executeOnDrop.Invoke();
                Destroy(gameObject);
            }
            inOtherCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Customer")
        {
            inOtherCollider = false;
        }
    }


}