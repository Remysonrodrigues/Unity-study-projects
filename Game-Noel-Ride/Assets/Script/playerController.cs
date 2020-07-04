using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float velocidadeMovimento;
    
    private int presentes;
    public int tempoFase;

    public Text presenteTxt;
    public Text tempoTxt;

    public GameObject particula;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        StartCoroutine("contagemRegressiva");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        playerRb.velocity = new Vector2(horizontal * velocidadeMovimento, vertical * velocidadeMovimento);
    }

    IEnumerator contagemRegressiva()
    {
        tempoTxt.text = tempoFase.ToString();
        yield return new WaitForSeconds(1);

        tempoFase -= 1;

        if (tempoFase > 0)
        {
            StartCoroutine("contagemRegressiva");
        }
        else
        {
            SceneManager.LoadScene("Titulo");
        }
    }

    void OnTriggerEnter2D( Collider2D col )
    {
        if (col.tag == "presente")
        {
            presentes += 1;
            presenteTxt.text = presentes.ToString();

            Instantiate(particula, col.transform.position, col.transform.rotation);

            Destroy(col.gameObject);
        }
    }
}
