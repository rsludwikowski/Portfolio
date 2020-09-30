using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualCamera : MonoBehaviour
{

    public Camera cam1;
    public Camera cam2;

    public GameObject player1;
    public GameObject player2;

	public float maxDist;
	public float speed;
	public float camDist;
    public float upOffset;
    public float screenSpeed;



    // Update is called once per frame
    void Update()
    {
		Vector3 p1Poz = new Vector3(player1.transform.position.x, player1.transform.position.y, player1.transform.position.z);
		Vector3 p2Poz = new Vector3(player2.transform.position.x, player2.transform.position.y, player2.transform.position.z);

		Vector3 distVec = p1Poz - p2Poz;

		float dist = distVec.magnitude;

		if (dist <= maxDist)
		{
            if (cam1.rect.width < 1.0f)
            {
                cam1.rect = new Rect(0.0f, 0.0f, cam1.rect.width + screenSpeed * Time.deltaTime, 1.0f);
                cam2.rect = new Rect(cam2.rect.x + screenSpeed * Time.deltaTime, 0.0f, cam2.rect.width - screenSpeed * Time.deltaTime, 1.0f);
            }
            

            cam1.transform.Translate((transform.position - cam1.transform.position) * Time.deltaTime * speed);
			cam2.transform.Translate((transform.position - cam2.transform.position) * Time.deltaTime * speed);
			Vector3 pAvrPoz = (p1Poz + p2Poz) / 2;
			pAvrPoz -= transform.position;
			pAvrPoz.z -= camDist;
            pAvrPoz.y += upOffset;
			transform.Translate(pAvrPoz * Time.deltaTime * speed);

            /*
			float FOV1 = cam1.fieldOfView;
            float cam1Ratio = cam1.scaledPixelWidth / cam1.scaledPixelHeight;
            float f1 = Mathf.Tan(Mathf.Deg2Rad * (FOV1 / 2.0f));
            FOV1 = Mathf.Rad2Deg * (Mathf.Atan(f1 * cam1Ratio)) * 2.0f;
			float FOV2 = cam2.fieldOfView;
            float cam2Ratio = cam2.scaledPixelWidth / cam2.scaledPixelHeight;
            float f2 = Mathf.Tan(Mathf.Deg2Rad * (FOV2 / 2.0f));
            FOV2 = Mathf.Rad2Deg * (Mathf.Atan(f2 * cam2Ratio)) * 2.0f;

            Quaternion rotation1 = Quaternion.Euler(0.0f, -FOV1, 0.0f);
			Quaternion rotation2 = Quaternion.Euler(0.0f, FOV2, 0.0f);
            Debug.Log("rot1: " + rotation1);
            Debug.Log("rot2: " + rotation2);
			Vector3 lookPoz = (p1Poz + p2Poz) / 2;
			lookPoz -= transform.position;
			cam1.transform.LookAt(rotation1 * lookPoz);
			cam2.transform.LookAt(rotation2 * lookPoz);
            */

            Vector3 lookPoz = (p1Poz + p2Poz) / 2;
            lookPoz -= transform.position;
            cam1.transform.LookAt(lookPoz);
            cam2.transform.LookAt(lookPoz);

        }

		else
		{
            if (cam1.rect.width > 0.5f)
            {
                cam1.rect = new Rect(0.0f, 0.0f, cam1.rect.width - screenSpeed * Time.deltaTime, 1.0f);
                cam2.rect = new Rect(cam2.rect.x - screenSpeed * Time.deltaTime, 0.0f, cam2.rect.width + screenSpeed * Time.deltaTime, 1.0f);
            }

            Vector3 pAvrPoz = (p1Poz + p2Poz) / 2;
			pAvrPoz -= transform.position;
			pAvrPoz.z -= camDist;
            pAvrPoz.y += upOffset;
            transform.Translate(pAvrPoz * Time.deltaTime * speed);
			if (p1Poz.x < p2Poz.x)
			{
				p1Poz -= cam1.transform.position;
				p1Poz.z -= camDist;
                p1Poz.y += upOffset;
				p2Poz -= cam2.transform.position;
				p2Poz.z -= camDist;
                p2Poz.y += upOffset;
                cam1.transform.Translate(p1Poz * Time.deltaTime * speed);
                //cam1.transform.LookAt(new Vector3(0.0f, 0.0f, 1.0f));
				cam2.transform.Translate(p2Poz * Time.deltaTime * speed);
                //cam2.transform.LookAt(new Vector3(0.0f, 0.0f, 1.0f));
			}
			else
			{
				p1Poz -= cam2.transform.position;
				p1Poz.z -= camDist;
                p1Poz.y += upOffset;
                p2Poz -= cam1.transform.position;
				p2Poz.z -= camDist;
                p2Poz.y += upOffset;
                cam2.transform.Translate(p1Poz * Time.deltaTime * speed);
                //cam2.transform.LookAt(new Vector3(0.0f, 0.0f, 1.0f));
				cam1.transform.Translate(p2Poz * Time.deltaTime * speed);
                //cam1.transform.LookAt(new Vector3(0.0f, 0.0f, 1.0f));
			}
		}
	}
}
