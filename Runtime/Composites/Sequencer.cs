using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheKiwiCoder {

    /// <summary>
    /// Executes all children unitl one fails. If all succeed, it returns success. If one fails it returns failure
    /// </summary>
    [System.Serializable]
    public class Sequencer : CompositeNode {

        protected override void OnStart() {
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            for (int i = 0; i < children.Count; ++i) { //go through all children
                var childStatus = children[i].Update(); //tick the update for a child

                if (childStatus == State.Running) { 
                    return State.Running; //if that one is runnin, this loop stops and the suquencer update returns running
                } else if (childStatus == State.Failure) {
                    return State.Failure;
                }
            }

            return State.Success; //if all children have suceeded, the seq returns success
        }
    }
}