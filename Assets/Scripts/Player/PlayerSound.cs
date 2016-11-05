using UnityEngine;
using System.Collections;
/*
 * Controls sounds from the player
 */
public class PlayerSound : MonoBehaviour {
    public AudioClip goodSound;
    public AudioClip badSound;
    public AudioClip GoodItemSound;
    public AudioClip BadItemSound;

    public AudioSource audioSource;


    /*
* Plays a sound when player picks up a powerup
*/
    public void PlayGoodItemSound()
    {
        playSound(GoodItemSound);
    }

    /*
 * Plays a sound when player picks up a trap
 */
    public void PlayBadItemSound()
    {
        playSound(BadItemSound);
    }

    /*
     * Plays a sound when player takes damage
     */
    public void PlayBadSound()
    {
        playSound(badSound);
    }

    /*
     * Plays a sound when player kills an enemy
     */
    public void PlayGoodSound()
    {
        playSound(goodSound);
    }

    /*
     * Actually plays the sound
     */
    private void playSound(AudioClip sound)
    {
        if (audioSource.isPlaying != true) //only play a sound if we aren't already playing one
        {
            audioSource.clip = sound;
            audioSource.Play();
        }
    }
}
