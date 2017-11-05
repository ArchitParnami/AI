/*
 * Author: Archit Parnami
 */

using System;
using System.Collections.Generic;

namespace nQueens
{
    class MinConflictSolver : ISolver
    {
        private State state;
        private int maxSteps;
        private List<int> queensInConflict;
        private int currentQueen;
        private int[] costArray;
        private List<Point> minCostPoints;
        private Point targetPoint;
        private Random r;
        private int steps;

        public MinConflictSolver(State state, int maxSteps)
        {
            this.state = state;
            this.maxSteps = maxSteps;
            r = new Random();
            steps = 0;
            RunOnce();
        }

        public State CurrentState
        {
            get { return state; }
        }

        public int Moves
        {
            get { return steps; }
        }

        public int CurrentQueen
        {
            get { return currentQueen; }
        }

        public int[] CostArray
        {
            get { return costArray; }
        }

        public int NumOfConflicts
        {
            get
            {
                int x = 0;
                for (int i = 0; i < queensInConflict.Count; i++)
                {
                    for (int j = i + 1; j < queensInConflict.Count; j++)
                    {
                        int q1 = queensInConflict[i];
                        int q2 = queensInConflict[j];
                        if (isInConflict(q1, state[q1], q2, state[q2]))
                            x++;
                    }
                }
                return x;
            }
        }

        public List<Point> MinCostPoints
        {
            get { return minCostPoints; }
        }

        public Point TargetPoint
        {
            get { return targetPoint; }
        }

        private int ConflictsPerQueen(int x, int y)
        {
            int conflicts = 0;

            for(int i = 0; i < state.NumOfQueens; i++)
            {
                if(i != x)
                {
                    if (isInConflict(x, y, i, state[i]))
                        conflicts++;
                }
            }

            return conflicts;
        }
   
        private bool isInConflict(int x1, int y1, int x2, int y2)
        {
            return x1 == x2 || y1 == y2 || Math.Abs(x1 - x2) == Math.Abs(y1 - y2);
        }

        private void FindQueensInConflict()
        {
            queensInConflict = new List<int>();

            for (int i = 0; i < state.NumOfQueens; i++)
            {
                int conflicts = ConflictsPerQueen(i, state[i]);
                if (conflicts > 0)
                {
                    queensInConflict.Add(i);
                }
            }
        }

        private void GetRandomConflictQueen()
        {
            int index = r.Next(0, queensInConflict.Count);
            currentQueen = queensInConflict[index];
        }

        private void ComputeCostCurrentQueen()
        {
            costArray = new int[state.NumOfQueens];
            for(int y=0; y < state.NumOfQueens; y++)
            {
                costArray[y] = ConflictsPerQueen(currentQueen, y);
            }
        }

        private void FindMinCostPoints()
        {
            int min = int.MaxValue;
            for(int y = 0; y < state.NumOfQueens; y++)
            {
                if (costArray[y] < min)
                    min = costArray[y];
            }

            minCostPoints = new List<Point>();

            for(int y = 0; y < state.NumOfQueens; y++)
            {
                if (costArray[y] == min && y!= state[currentQueen])
                    minCostPoints.Add(new Point(currentQueen, y));
            }
        }

        private void FindTargetPoint()
        {
            if(minCostPoints.Count > 0)
            {
                int index = r.Next(0, minCostPoints.Count);
                targetPoint = minCostPoints[index];
            }
            else
            {
                targetPoint = null;
            }
        }

        public bool Next()
        {
            
            if (queensInConflict.Count == 0 || steps==maxSteps)
                return false;
            
            if (targetPoint != null)
            {
                state[targetPoint.X] = targetPoint.Y;
            }

            steps++;
            RunOnce();

            return true;
        }

        private void RunOnce()
        {
            FindQueensInConflict();

            if (queensInConflict.Count == 0)
            {
                minCostPoints.RemoveAll(x => true);
                return;
            }
                

            GetRandomConflictQueen();
            ComputeCostCurrentQueen();
            FindMinCostPoints();
            FindTargetPoint();
        }
    }
}
