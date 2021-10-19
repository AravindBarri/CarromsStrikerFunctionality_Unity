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

    [SerializeField]
    Vector3 initialPointOfStriker;

    [SerializeField]
    Text resetText;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        strikerSlider.onValueChanged.AddListener(StrikerPos);
        initialPointOfStriker = this.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
            //print(Input.mousePosition);
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

            resetText.text = "Press Space to reset the striker position";
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ResetStrikerPosition());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "RedPuck" )
        {
            collision.gameObject.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
            StartCoroutine(ResetPuckColor(collision.gameObject));
            ScoreManager.scoreInstance.RedPuckUpdate();
        }else if(collision.gameObject.tag == "BluePuck")
        {
            collision.gameObject.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
            StartCoroutine(ResetPuckColor(collision.gameObject));
            ScoreManager.scoreInstance.BluePuckUpdate();
        }
        
    }
    public void StrikerPos(float value)
    {
        transform.position = new Vector3(value, -0.95f, 0);
        
    }



    IEnumerator ResetStrikerPosition()
    {
        yield return new WaitForSeconds(1f);
        this.transform.position = initialPointOfStriker;
        RB.velocity = Vector3.zero;
        resetText.text = "";
    }

    IEnumerator ResetPuckColor(GameObject puckObject)
    {
        yield return new WaitForSeconds(2f);
        puckObject.GetComponent<Renderer>().material.color = Color.white;
        //puckObject.SetActive(false);
    }
}
