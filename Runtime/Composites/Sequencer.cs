using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheKiwiCoder {

    /// <summary>
    /// Executes all children unitl one fails. If all succeed, it returns success. If one fails it returns failure
    /// </summary>
    [System.Serializable]
    public class Sequencer : CompositeNode {
        protected int current;

        protected override void OnStart() {
            current = 0;
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            for (int i = current; i < children.Count; ++i) {
                current = i;
                var child = children[current]; //go through all children

                switch (child.Update()) { //ticvk the update for a child
                    case State.Running:
                        return State.Running; //if that one is runnin, this loop stops and the suquencer update returns running
                    case State.Failure:
                        return State.Failure; //fif success, it goes to the next child
                    case State.Success:
                        continue;
                }
            }

            return State.Success; //if all children have suceeded, the seq returns success
        }
    }
}