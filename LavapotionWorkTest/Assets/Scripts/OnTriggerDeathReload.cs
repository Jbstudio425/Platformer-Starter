using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OnTriggerDeathReload : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            Destroy(other.gameObject);
            StartCoroutine(ReloadScene());
        }
    }

    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
