using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something entered the checkpoint trigger.");

        if (!activated && other.CompareTag("Player"))
        {
            Debug.Log("Player hit checkpoint.");
            activated = true;
            GameManager.Instance.SetCheckpoint(transform.position);
            AudioManager.Instance.PlayCheckpoint();
        }
        Debug.Log("Triggered by: " + other.name);
    }
}
