using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject GamerOverPanel;
    [SerializeField] GameObject GameOverTransp;
    // Start is called before the first frame update
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
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("SampleScene");
    }


}
   