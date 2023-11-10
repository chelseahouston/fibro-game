using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// author: chelsea houston
// date last midified: 04/11/23

public class Arrows : MonoBehaviour
{
    public GameObject leftArrow, rightArrow;
    public RoomViews roomView;

    public void LeftArrowClick() {
        roomView.RotateLeft();
    }
    public void RightArrowClick() {
        roomView.RotateRight();
    }


}
