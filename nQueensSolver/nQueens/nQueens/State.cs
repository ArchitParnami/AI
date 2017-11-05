/*
 * Author: Archit Parnami
 */

using System;

namespace nQueens
{
    class State
    {
        private int numOfQueens;
        private int[] locations;

        
        public int NumOfQueens
        {
            get { return numOfQueens; }
        }

        public State(int numOfQueens)
        {
            this.numOfQueens = numOfQueens;
            locations = new int[numOfQueens];
        }

        public State(State other)
        {
            this.numOfQueens = other.numOfQueens;
            this.locations = new int[numOfQueens];
            for(int i = 0; i < numOfQueens; i++)
            {
                this[i] = other[i];
            }
        }


        public int this[int i]
        {
            get { return locations[i]; }
            set { locations[i] = value; }
        }

        public static State GetRandomState(int numOfQueens)
        {
          
            State state = new State(numOfQueens);
            Random r = new Random();
            for (int i = 0; i < numOfQueens; i++)
            {
                state[i] = r.Next(0, numOfQueens);
            }

            return state;
        }
    }
}
