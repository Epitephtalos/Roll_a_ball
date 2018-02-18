using UnityEngine;
using UnityEngine.UI; // Parmet l'affichage et interactions d elements d UI
using System.Collections; 
using UnityEngine.SceneManagement; // Permet l utilisation du management de scenes

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public static int count;

    private Rigidbody rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate() // Permet le mouvement de la balle (x;z) grace aux inputs du controller
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other) // Permet 
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false); // Desactive l objet avec le tag Pick Up qui a eu la collision
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText() // Affiche du texte UI selon la completion
    {
        countText.text = "Score: " + count.ToString();

        if (count == 26)
        {
            winText.text = "Pas trop mal !";
            StartCoroutine(Waiter());
            ChangeScene();
        }

        else if (count == 53)
        {
            winText.text = "Joli !";
            //StartCoroutine(Waiter());
            ChangeScene();
        }

        else if (count == 80)
        {
            winText.text = "Parfait !";
            //StartCoroutine(Waiter());
        }

        else
        {

        }
    }

    void ChangeScene ()
    {
        if (count == 26)
        {
            count = count + 1;
            winText.text = "";
            SceneManager.LoadScene("Stage_2", LoadSceneMode.Single);
        }

        else if (count == 53)
        {
            winText.text = "";
            SceneManager.LoadScene("Stage_3", LoadSceneMode.Single);
            count = count + 1;
        }

        else
        {

        }
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSecondsRealtime(30);
    }
}