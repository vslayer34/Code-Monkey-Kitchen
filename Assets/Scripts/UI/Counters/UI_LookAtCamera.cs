using UnityEngine;

public class UI_LookAtCamera : MonoBehaviour
{
    private enum Mode
    {
        LookAt,
        LookAtInverted,
        LookForward,
        LookForwardInverted
    }

    [SerializeField, Tooltip("Adjust the bar orientation on the camera view")]
    private Mode _mode;



    // Game Loop Methods---------------------------------------------------------------------------

    private void LateUpdate()
    {
        switch (_mode)
        {
            case Mode.LookAt:
                transform.LookAt(Camera.main.transform);
                break;
            
            case Mode.LookAtInverted:
                var directionToCamera = transform.position - Camera.main.transform.position;
                transform.LookAt(transform.position + directionToCamera);
                break;
            
            case Mode.LookForward:
                transform.forward = Camera.main.transform.forward;
                break;
            
            case Mode.LookForwardInverted:
                transform.forward = -Camera.main.transform.forward;
                break;

            default:
                Debug.LogError("No such UI orientation mode");
                break;
        }
    }
}
