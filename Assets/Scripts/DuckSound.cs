using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSound : MonoBehaviour
{
    public AudioSource duckSound;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("RewardEagle") && !other.gameObject.GetComponent<RewardEagle>().getClickedStatus())
            duckSound.Play();
    }
}
