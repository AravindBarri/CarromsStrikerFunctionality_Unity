using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrikerController : MonoBehaviour
{
    [SerializeField] Slider strikerSlider;

    [SerializeField] Transform StrikerBG;

    [SerializeField]
    bool StrikerForce;

    Rigidbody2D RB;

    [SerializeField]
    Transform ForcePoint;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        strikerSlider.onValueChanged.AddListener(StrikerPos);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
            if (hit.collider)
            {
                if(hit.transform.name == "CarromStriker")
                {
                    StrikerForce = true;
                }
                if (StrikerForce)
                {
                    StrikerBG.LookAt(hit.point);
                }

                float ScaleValue = Vector2.Distance(transform.position, hit.point) * 100;

                StrikerBG.localScale = new Vector3(ScaleValue, ScaleValue, ScaleValue);

                Debug.Log(hit.transform.gameObject.name);
                
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            RB.AddForce(new Vector3(ForcePoint.position.x - transform.position.x, ForcePoint.position.y - transform.position.y, 0) * 100);

            StrikerForce = false;

            StrikerBG.localScale = Vector3.zero;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Puck")
        {
            collision.gameObject.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
        }
    }
    public void StrikerPos(float value)
    {
        transform.position = new Vector3(value, -0.95f, 0);
    }
}
