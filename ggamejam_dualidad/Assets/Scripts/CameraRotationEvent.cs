using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationEvent : Event
{
    private bool restoreRotation;
    private float cameraRotationSpeed = 0.2f;
    private float cameraRotationBlend = 0f;

    private IEnumerator cameraRotationCoroutine;
    public override void Execute(Match match, MonoBehaviour monoBehaviour)
    {
        cameraRotationCoroutine = RotateCameraCoroutine(match);
        if (canHappen)
        {
            canHappen = false;
            monoBehaviour.StartCoroutine(cameraRotationCoroutine);
        }
    }

    IEnumerator RotateCameraCoroutine(Match match)
    {
        var cameraPivot = match.cameraPivot;

        while(!restoreRotation)
        {
            cameraPivot.transform.rotation = Quaternion.Lerp(Quaternion.Euler(0f, 0f, 0f), Quaternion.Euler(0f, 0f, -60f), cameraRotationBlend);

            cameraRotationBlend += cameraRotationSpeed * Time.deltaTime;

            if (cameraRotationBlend > 1f)
            {
                cameraRotationBlend = 0f;
                restoreRotation = true;
            }

            yield return null;
        }

        match.player.canMove = true;
        match.player.actions = 5;

        yield return new WaitForSeconds(10f);

        while (restoreRotation)
        {
            cameraPivot.transform.rotation = Quaternion.Lerp(Quaternion.Euler(0f, 0f, -60f), Quaternion.Euler(0f, 0f, 0f), cameraRotationBlend);

            cameraRotationBlend += cameraRotationSpeed * Time.deltaTime;

            if (cameraRotationBlend > 1f)
            {
                cameraRotationBlend = 0f;
                restoreRotation = false;
            }

            yield return null;
        }

        canHappen = true;
    }
}
