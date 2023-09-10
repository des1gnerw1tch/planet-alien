using UnityEngine;

public class FrameRate : MonoBehaviour
{
    [SerializeField] private int framerate;
    
    void Start()
    {
        Application.targetFrameRate = framerate;
    }
}
