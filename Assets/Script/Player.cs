using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject FakeWord;
    [SerializeField]
    private GameObject RealWord;
    [SerializeField]
    private GameObject WorldText;

    private List<SpriteRenderer> FakeElements = new List<SpriteRenderer>();
    private List<SpriteRenderer> RealElements = new List<SpriteRenderer>();

    private void Awake()
    {
        foreach (var element in FakeWord.GetComponentsInChildren<SpriteRenderer>())
        {
            FakeElements.Add(element);
        }
        foreach (var element in RealWord.GetComponentsInChildren<SpriteRenderer>())
        {
            RealElements.Add(element);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - (1 * Time.deltaTime), transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + (1 * Time.deltaTime), transform.position.y, transform.position.z);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            SwitchWorld();
        }
    }

    public void SwitchWorld()
    {
        bool ChangeVisible =FakeElements[0].enabled;
        WorldText.GetComponent<Text>().text = ChangeVisible ? "Real World" : "Fake World";
        FakeElements.ForEach(element => element.enabled= !ChangeVisible);
        RealElements.ForEach(element => element.enabled= ChangeVisible);
    }
}
