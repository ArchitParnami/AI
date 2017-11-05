
/*
 * Author: Archit Parnami
 */
namespace nQueens
{
    class RandomRestart
    {
        private ISolver solver;
        private int maxIterations;
        private int numOfQueens;
        private int iterations;
        private Algorithm algorithm;
        private int maxSteps;
        private int totalMoves;

        public RandomRestart(Algorithm algorithm, int numOfQueens, int maxIter, int maxSteps = 0)
        {
            maxIterations = maxIter;
            this.numOfQueens = numOfQueens;
            this.algorithm = algorithm;
            this.maxSteps = maxSteps;
            totalMoves = 0;
        }

        public ISolver Solver
        {
            get { return solver; }
        }

        public int Iterations
        {
            get { return iterations; }
        }

        public int TotalMoves
        {
            get { return totalMoves; }
        }

        public bool Run()
        {
           for(int i =0; i < maxIterations; i++)
            {
                iterations = i+1;
                State randomState = State.GetRandomState(numOfQueens);
                if (this.algorithm == Algorithm.Hill_Climbing)
                    solver = new HillClimbingSolver(randomState);
                else
                    solver = new MinConflictSolver(randomState, maxSteps);

                while (solver.Next()) { }
                totalMoves += solver.Moves;
                if(solver.NumOfConflicts == 0)
                {
                    return true;
                }
          
            }

            return false;
            
        }
    }
}
