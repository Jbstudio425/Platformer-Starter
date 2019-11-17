using System.Collections;
using UnityEngine;

public class OnTriggerAnimationWin : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            animator.SetBool("OpenChest", true);
            StartCoroutine(ShowWinScreen());
        }
    }

    IEnumerator ShowWinScreen()
    {
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Game Won!");
    }
}
