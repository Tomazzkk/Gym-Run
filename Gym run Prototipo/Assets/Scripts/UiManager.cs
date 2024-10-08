using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject GamerOverPanel;
    [SerializeField] GameObject GameOverTransp;
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject DespausarPanel;
    float timer;
    [SerializeField] TextMeshProUGUI contagemText;

    private void Update()
    {


        if (!PausePanel.activeInHierarchy && timer > 0)
        {
            timer -= Time.deltaTime;
            contagemText.text = timer.ToString("0");
            if (timer <= 0)
            {
                DespausarPanel.SetActive(false);
                GameManager.instance.ScaleTime = 1;
            }
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            GamerOverPanel.SetActive(true);
            GameOverTransp.SetActive(true);
        }
    }

    public void Reload()
    {
        GameManager.instance.ScaleTime = 1.0f;
        SceneManager.LoadScene("SampleScene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PauseButton()
    {
        GameManager.instance.ScaleTime = 0;
        PausePanel.SetActive(true);


    }

    public void Despausar()
    {
        timer = 3;
        PausePanel.SetActive(false);
        DespausarPanel.SetActive(true);
    }
}
