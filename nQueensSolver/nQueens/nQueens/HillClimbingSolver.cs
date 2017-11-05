/*
 * Author: Archit Parnami
 */

using System;
using System.Collections.Generic;


namespace nQueens
{
    class HillClimbingSolver : ISolver
    {
        private Random r;
        private State currentState;
        private int conflicts;
        private int[,] costMatrix;
        private List<Point> minPoints;
        private Point targetPoint;
        private int moves;
      

        public HillClimbingSolver(State state)
        {
            r = new Random();
            currentState = state;
            moves = 0;
            RunOnce();
        }

        public State CurrentState
        {
            get { return currentState; }
        }

        public int Moves
        {
            get { return moves; }
         }

        public int NumOfConflicts
        {
            get { return conflicts; }
        }

        public int[,] CostMatrix
        {
            get { return costMatrix; }
        }

        public List<Point> MinConflictPoints
        {
            get { return minPoints; }
        }

        public Point TargetPoint
        {
            get { return targetPoint; }
        }

        private int ComputeConflicts(State state)
        {
            int x = 0;
            for (int i = 0; i < state.NumOfQueens; i++)
            {
                for (int j = i+1; j < state.NumOfQueens; j++)
                {
                    if (isInConflict(i, state[i], j, state[j]))
                        x++;      
                }
            }
            return x;
        }

        private bool isInConflict(int x1, int y1, int x2, int y2)
        {
            return x1 == x2 || y1 == y2 || Math.Abs(x1 - x2) == Math.Abs(y1 - y2);
        }

        private int[,] ComputeCostMatrix()
        {
            int n = currentState.NumOfQueens;
            int[,] costMatrix = new int[n, n];

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(j == currentState[i])
                    {
                        costMatrix[i,j] = conflicts;
                    }
                    else
                    {
                        State newState = new State(currentState);
                        newState[i] = j;
                        costMatrix[i, j] = ComputeConflicts(newState);
                    }
                }
            }

            return costMatrix;
        }

        public List<Point> FindMinConflictPoints()
        {
            List<Point> points = new List<Point>();
            int n = currentState.NumOfQueens;

            int minCost = int.MaxValue;

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (costMatrix[i, j] < minCost)
                        minCost = costMatrix[i, j];
                }
            }

            if(minCost < conflicts)
            {
                for(int i = 0; i < n; i++)
                {
                    for(int j = 0; j < n; j++)
                    {
                        if(costMatrix[i,j] == minCost)
                        {
                            points.Add(new Point(i, j));
                        }
                    }
                }
            }

            return points;
        }

        public bool Next()
        {
            if(targetPoint == null)
            {
                return false;
            }
            else
            {
                currentState[targetPoint.X] = targetPoint.Y;
                RunOnce();
                moves++;
                return true;
            }
        }

        private void RunOnce()
        {
            conflicts = ComputeConflicts(currentState);
            costMatrix = ComputeCostMatrix();
            minPoints = FindMinConflictPoints();

            if (minPoints.Count != 0)
            {
                int pos = r.Next(0, minPoints.Count);
                targetPoint = minPoints[pos];
            }

            else
            {
                targetPoint = null;
            }
        }
    }
}
