using System;
using System.Collections.Generic;

namespace SimpleState {
public class StateMachine
{
    public List<State> states;

    State current;

    public void Update(float dt) {
        if(current != null) {
            current.Update(dt);
        }
    }

    public bool changeState(string name) {
        if(validNextState(name)) {
            string previous = current.name;
            current.Exit(name);
            State next = this.getState(name);
            if(next != null) {
                current = next;
                current.Enter(previous);
                return true;
            } else {
                throw new Exception("No state transition found:  " + previous + " -> " + name);
            }
        }
        return false;
    }

    private State getState(string name) 
    {
        foreach(State state in states) {
            if ( state.name == name ) {
                return state;
            }
        }
        return null;
    }

    private bool validNextState(string next)
    {
        return current.next_states.Contains(next);
    }
}
}