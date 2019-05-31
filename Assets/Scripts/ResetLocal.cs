using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLocal : MonoBehaviour
{

    public void ResetLocalPosition() {
        transform.localPosition = Vector3.zero;
    }
}
