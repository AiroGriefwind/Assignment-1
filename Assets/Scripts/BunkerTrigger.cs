using UnityEngine;
using UnityEngine.Rendering.HighDefinition; // Add this line to import the High Definition Render Pipeline namespace
public class BunkerTrigger : MonoBehaviour
{
    // Door
    public Animator door1Animator;
    public Animator door2Animator;
    
    // Light
    public Light pointLight; // The standard Light component
    private HDAdditionalLightData hdLight; // HDRP specific light data
    public float lightEV100Target = 25.0f; // Target value for EV100
    public float lightChangeSpeed = 25.0f; // Speed at which the light changes

    // Audio source
    public AudioSource doorAudioSource;

    // Particle system
    public ParticleSystem spark1;
    public ParticleSystem spark2;

    // Trigger state
    private bool isTriggered = false;

    void Start()
    {
        // If the particle system should not be playing at start, stop it here.
        if (spark1 != null)
        {
            spark1.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
        if (spark2 != null)
        {
            spark2.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }

        // Get the HDAdditionalLightData component
        hdLight = pointLight.GetComponent<HDAdditionalLightData>();

        // Set initial EV100 value to 0
        if (hdLight != null)
        {
            hdLight.intensity = 0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Only trigger once
        if (!isTriggered)
        {
            isTriggered = true;
            door1Animator.SetTrigger("OpenDoor");
            door2Animator.SetTrigger("OpenDoor");

            // Play the audio when the doors start to open
            if (doorAudioSource && !doorAudioSource.isPlaying)
            {
                doorAudioSource.Play();
            }

            // Start the particle system when the trigger is activated
            if (spark1 != null)
            {
                spark1.Play();
            }
            if (spark2 != null)
            {
                spark2.Play();
            }
        }
    }

    void Update()
    {
        // // If triggered, increase the light intensity gradually
        // if (isTriggered)
        // {
        //     pointLight.intensity = Mathf.MoveTowards(pointLight.intensity, lightIntensityTarget, lightChangeSpeed * Time.deltaTime);
        // }
        
        // If triggered, increase the EV100 value gradually
        if (isTriggered && hdLight != null)
        {
            hdLight.intensity = Mathf.MoveTowards(hdLight.intensity, lightEV100Target, lightChangeSpeed * Time.deltaTime);
        }
    }
}
