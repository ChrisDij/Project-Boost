using UnityEngine;
using UnityEngine.SceneManagement;


public class Rocket : MonoBehaviour{

    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;

    Rigidbody rigidBody;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start(){

        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision){

        switch (collision.gameObject.tag){
            case "Friendly":
                print("Time To Start Flying");
                break;
            case "Dead":
                SceneManager.LoadScene(0);
                break;
            case "Finish":
                SceneManager.LoadScene(1);
                break;
        }
    }

    // Update is called once per frame
    void Update(){
        
            ProccessInput();
    }


    //Inputs
    void ProccessInput(){

        if (Input.GetKey(KeyCode.W))
        {
            rigidBody.AddRelativeForce(Vector3.up * mainThrust);
            if (!audioSource.isPlaying) 
            {
            audioSource.Play();
            }
        }
        
        else if(audioSource.isPlaying)
            {
                audioSource.Stop();
            }

        if(Input.GetKey(KeyCode.S))
        {
            rigidBody.AddRelativeForce(Vector3.right * mainThrust);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        else if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        float rotationThisFrame = rcsThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            {
            transform.Rotate(Vector3.right * rotationThisFrame);
            }
        else if (Input.GetKey(KeyCode.A))
            {
            transform.Rotate(Vector3.left * rotationThisFrame);
            }
    }
}