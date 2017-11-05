/*
 * Author: Archit Parnami
 */

namespace nQueens
{
    interface ISolver
    {
        bool Next();
        int NumOfConflicts { get; }
        State CurrentState { get; }
        int Moves { get; }
    }
}
