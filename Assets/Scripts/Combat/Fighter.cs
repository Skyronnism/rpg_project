using System.Collections;
using System.Collections.Generic;
using RPG.Movement;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float weaponRange = 2f;
        Transform target;

        private void Update()
        {    
            if(target == null) return;
            if(!IsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Stop();
            }
        }

        private bool IsInRange()
        {
            return Vector3.Distance(GetComponent<NavMeshAgent>().transform.position, target.position) <= weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            if(combatTarget != null)
            target = combatTarget.transform;
            else
            target = null;
        }
    }
}
