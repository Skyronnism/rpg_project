using UnityEngine;
using RPG.Movement;
using RPG.Combat;
using System;
using System.Collections.Generic;

namespace RPG.Control 
{
    public class PlayerController : MonoBehaviour
    {

        void Update()
        {
            InteractWithMovement();
            InteractWithCombat();
        }

        private void InteractWithCombat()
        {
            if(Input.GetMouseButtonDown(0))
            {
                //int position = 0;
                //var positionList = new List<int>();
                RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
                foreach(RaycastHit hit in hits)
                {
                    if (hit.transform.GetComponent<CombatTarget>() != null)
                    {
                        //positionList.Add(position);
                        CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                        GetComponent<Fighter>().Attack(target);
                    }
                    //position = position + 1;
                }
                //RaycastHit Closer = MeasureDistance(positionList, hits);
            }
        }

        // private RaycastHit MeasureDistance(List<int> positionList, RaycastHit[] hits)
        // {
        //     Vector3 playerPosition = GetComponent<Transform>().position;
        //     var distanceList = new List<float>();
        //     int listPos = 0;
        //     foreach(int position in positionList)
        //     {
        //         distanceList.Add(Vector3.Distance(hits[positionList[position]].transform.position, playerPosition));
        //     }
        //     distanceList.Sort();
        //     distanceList.ForEach(Console.WriteLine);
        //     listPos = 0;
        //     int closerPos = 0;
        //     foreach(int position in positionList)
        //     {
        //         if(Vector3.Distance(hits[positionList[listPos]].transform.position, playerPosition) == distanceList[0]){
        //         closerPos = listPos;
        //         }
        //         listPos = listPos + 1;
        //     }
        //     return (hits[positionList[closerPos]]);
        // }

        private void InteractWithMovement()
        {
            if (Input.GetMouseButton(0))
                MoveToCursor();
        }

        public void MoveToCursor()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit)
                GetComponent<Mover>().MoveTo(hit.point);
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}

