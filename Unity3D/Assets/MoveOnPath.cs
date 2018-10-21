using UnityEngine;
using System.Collections;
using System.Linq;

public class MoveOnPath : MonoBehaviour
{
    public PathMarkerHolder PathToFollow;

    public GameObject CenterFocus;

    public int CurrentWaypointId = 0;
    public float speed;
    public float reachDistance = 1.0f;
    public float rotationSpeed = 5.0f;
    public string pathName;

    Vector3 lastPosition;
    Vector3 currentPosition;

    // Use this for initialization
    void Start()
    {
        PathToFollow = GameObject.Find(pathName).GetComponent<PathMarkerHolder>();
        lastPosition = transform.position;
    }

    public IEnumerator BeginMoving(IImageCapture cap, ICubeSatSequenceCallback callback)
    {
        int lastWaypointFlash = 0;

        while (CurrentWaypointId < PathToFollow.pathList.Count)
        {
            Debug.Log("At waypoint: " + CurrentWaypointId);

            float distance = Vector3.Distance(PathToFollow.pathList[CurrentWaypointId].position, transform.position);

            transform.position = Vector3.MoveTowards(transform.position, PathToFollow.pathList[CurrentWaypointId].position,
                Time.deltaTime * speed);

            if (CurrentWaypointId % 2 == 0 && lastWaypointFlash != CurrentWaypointId)
            {
                Debug.Log("Flashing light at waypoint: " + CurrentWaypointId);
                lastWaypointFlash = CurrentWaypointId;
                yield return cap.PerformImageCapture();
            }

            transform.LookAt(CenterFocus.transform);

            if (distance <= reachDistance)
            {
                CurrentWaypointId += 1;
            }

            yield return Enumerable.Empty<int>();
        }

        CurrentWaypointId = 0;

        Debug.Log("Sequence Completed");
        callback.SequenceComplete();

        GetComponent<HideHologramComponent>().ShowHologram();


        yield return Enumerable.Empty<int>();
    }

}
