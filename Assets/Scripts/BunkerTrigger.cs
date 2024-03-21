using UnityEngine;

public class BunkerTrigger : MonoBehaviour
{
    public Animator door1Animator;
    public Animator door2Animator;
    public Light pointLight;
    public float lightIntensityTarget = 1.0f;
    public float lightChangeSpeed = 1.0f;

    //audio source
    public AudioSource doorAudioSource;

    private bool isTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        // Trigger the doors to open when something enters the trigger
        isTriggered = true;
        door1Animator.SetTrigger("OpenDoor");
        door2Animator.SetTrigger("OpenDoor");

        // Play the audio when the doors start to open
        if (doorAudioSource && !doorAudioSource.isPlaying)
        {
            doorAudioSource.Play();
        }
    }

    void Update()
    {
        // If triggered, increase the light intensity gradually
        if (isTriggered)
        {
            pointLight.intensity = Mathf.MoveTowards(pointLight.intensity, lightIntensityTarget, lightChangeSpeed * Time.deltaTime);
        }
    }
}
