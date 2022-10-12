using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _dragOffset;
    private Camera _cam;
    [SerializeField] private float _speed=10f;

    [SerializeField] float _rightBoundary=0f;
    [SerializeField] float _leftBoundary=0f;
    [SerializeField] float _ceilingBoundary=0f;
    [SerializeField] float _floorBoundary=0f;

    void Awake(){
        _cam=Camera.main;
    }

    void Update(){
        PlayerMovement();
    }

    void OnMouseDown(){
        var mousePos=_cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z=0;
        _dragOffset=transform.position-mousePos;
    }

    void OnMouseDrag(){
        var mousePos=_cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z=0;
        transform.position=Vector3.MoveTowards(transform.position,mousePos+_dragOffset,_speed*Time.deltaTime);
        PlayerBoundaries();
    }

    void PlayerMovement(){

    }

    void PlayerBoundaries(){
        if(transform.position.x>=_rightBoundary){
             transform.position=new Vector3(_rightBoundary,transform.position.y,0);
        }
        else if(transform.position.x<=_leftBoundary){
             transform.position=new Vector3(_leftBoundary,transform.position.y,0);
        }

        if(transform.position.y>=_ceilingBoundary){
             transform.position=new Vector3(transform.position.x,_ceilingBoundary,0);
        }
        else if(transform.position.y<=_floorBoundary){
             transform.position=new Vector3(transform.position.x,_floorBoundary,0);
        }
        // float _xMovementClamp=Mathf.Clamp(transform.postion.x,_leftBoundary,_rightBoundary);
        // float _yMovementClamp=Mathf.Clamp(transform.postion.y,_floorBoundary,_ceilingBoundary);

        // Vector3 _limitPlayerMovement=new Vector3(_xMovementClamp,_yMovementClamp,0);
        // transform.position=_limitPlayerMovement;

        
    }

}
