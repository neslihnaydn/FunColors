using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class RandomTile : MonoBehaviour
{
    [SerializeField] private float speed = 400;
    Rigidbody2D rb;
    // Start is called before the first frame update
    Vector2 initialPosition;
    Quaternion initialRotation;
    List<Color> colorList;
    void Awake() 
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        colorList = new List<Color>{Color.white, Color.red, Color.blue, Color.black};
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            rb.AddRelativeForce(Vector2.left * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            rb.AddRelativeForce(Vector2.right * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            rb.AddRelativeForce(Vector2.down * speed * Time.deltaTime);
    }

    void FixedUpdate() {

    }

    void OnCollisionEnter2D(Collision2D col)    
    {
        if (col.gameObject.GetComponent<SpriteRenderer>() != null && col.gameObject.GetComponent<SpriteRenderer>().color == GetComponent<SpriteRenderer>().color) 
        {
            if (GetComponent<SpriteRenderer>().color == Color.white) {
                WhiteScore.scoreValue += 1;
                // Debug.Log("White Score : " + Score.whiteScoreValue);
            } else if (GetComponent<SpriteRenderer>().color == Color.red) {
                RedScore.scoreValue += 1;
                // Debug.Log("Red Score : " + Score.redScoreValue);
            } else if (GetComponent<SpriteRenderer>().color == Color.blue) { 
                BlueScore.scoreValue += 1;
                // Debug.Log("Blue Score : " + Score.blueScoreValue);
            } else if (GetComponent<SpriteRenderer>().color == Color.black) { 
                BlackScore.scoreValue += 1;
                // Debug.Log("Black Score : " + Score.blackScoreValue);
            }
            TotalScore.scoreValue += 1;
        }

        cloneThisGameObject();
        Destroy(gameObject);
    }

    private GameObject cloneThisGameObject() {
        float randomVal = Random.Range(-0.5f, 0.5f);
        Vector2 positionWithRandomX = new Vector2(initialPosition.x + randomVal, initialPosition.y);
        GameObject newGameObject = (GameObject) Instantiate(gameObject, positionWithRandomX, initialRotation);
        newGameObject.GetComponent<SpriteRenderer>().color = randomColor();

        return newGameObject;
    }

    private Color randomColor() {
        return colorList[Random.Range(0, colorList.Count)];
    }
}
