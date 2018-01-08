using System;
using System.Collections.Generic;

namespace SimpleState {
public class StateMachine
{
    public List<State> states = new List<State>();

    State current;

    public void Update(float dt) {
        if(current != null) {
            current.Update(dt);
        }
    }

    public bool startState(State state) {
        if(current == null) {
            current = state;
            current.enter("");
            return true;
        }
        return false;
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