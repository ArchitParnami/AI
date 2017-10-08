/*
Author: Archit Parnami
ITCS 6150 : Project 1
*/

#include "AStar.h"
#include <cmath>

/*Constructor for instantiating an object of type AStar.
Initializes the problem with given initial and goal states.*/
AStar::AStar(int ** initialState, int** goalState)
{
	this->initialState = copyState(initialState);
	this->goalState = copyState(goalState);
	goalPosition = computePosition(this->goalState);
	addState(this->initialState, nullptr);
}

/*This is the evaluation function f(n) which returns the cost 
of selecting the state n given its level (depth) and the current state.*/
int AStar::computeCost(int level, int** state)
{
	return level + computeDistance(state);
}


/*Heuristic function which returns the estimated cost of reaching the goal state
from given state in terms of Hamiltonian distance*/
int AStar::computeDistance(int** state)
{
	int** pos = computePosition(state);
	int distance = 0;
	for (int i = 1; i < D*D; i++) {
		distance += abs(pos[i][0] - goalPosition[i][0]) +
			abs(pos[i][1] - goalPosition[i][1]);
	}

	delete[] pos;

	return distance;
}

/*Given a state, this function returns the position
of each tile in terms of(x, y) coordinates.*/
int** AStar::computePosition(int** state)
{
	int** pos = new int*[D*D];
	for (int i = 0; i < D*D; i++) {
		pos[i] = new int[2];
	}

	for (int i = 0; i < D; i++) {
		for (int j = 0; j < D; j++) {
			int num = state[i][j];
			pos[num][0] = i;
			pos[num][1] = j;
		}
	}
	return pos;
}

/*Verifies whether the given state is a goal state or not.*/
bool AStar::isGoalState(int** state) {
	return computeDistance(state) == 0;
}

/*Creates a node from the given state and attaches it to the parent node.
Also adds the newly created node to the frontier queue.*/
void AStar::addState(int ** state, Node * parent)
{
	Node *node = new Node();
	node->level = parent == nullptr ? 0 : (parent->level + 1);
	node->state = state;
	node->cost = computeCost(node->level, node->state);
	node->parent = parent;

	frontier.push(node);
}

/*Expands the input node and generate the next possible combinations of states. 
Also adds the generated nodes to the frontier.*/
void AStar::expandNode(Node *node)
{
	int* emptyPos = findEmptyCell(node);
	int *emptyPosParent = node->parent == nullptr ?
		nullptr : findEmptyCell(node->parent);

	int *top = nullptr;
	int *left = nullptr;
	int *right = nullptr;
	int *down = nullptr;

	if (emptyPos[0] > 0) {
		top = new int[2];
		top[0] = emptyPos[0] - 1;
		top[1] = emptyPos[1];
	}


	if (emptyPos[1] > 0) {
		left = new int[2];
		left[0] = emptyPos[0];
		left[1] = emptyPos[1] - 1;
	}

	if (emptyPos[0] < D - 1) {
		down = new int[2];
		down[0] = emptyPos[0] + 1;
		down[1] = emptyPos[1];
	}

	if (emptyPos[1] < D - 1) {
		right = new int[2];
		right[0] = emptyPos[0];
		right[1] = emptyPos[1] + 1;
	}


	int *loc[] = { top, left, down, right };
	for (int i = 0; i < 4; i++) {
		if (loc[i] != nullptr) {
			if ((emptyPosParent == nullptr) ||
				(loc[i][0] != emptyPosParent[0] || loc[i][1] != emptyPosParent[1])) {
				int **locState = generateState(node->state, emptyPos, loc[i]);
				addState(locState, node);
			}

			delete loc[i];
		}
	}

	delete emptyPos;
	delete emptyPosParent;
}

/*Return the location of blank tile in the 3x3 matrix in terms of (x, y) coordinate.*/
int * AStar::findEmptyCell(Node * node)
{
	int* xy = new int[2];

	for (int i = 0; i < D; i++) {
		for (int j = 0; j < D; j++) {
			if (node->state[i][j] == 0) {
				xy[0] = i;
				xy[1] = j;
				break;
			}
		}
	}

	return xy;
}

/*Returns a copy of an input state. Helper function used for generating new states.*/
int** AStar::copyState(int** state) {
	
	int** newState = new int*[D];
	for (int i = 0; i < D; i++) {
		newState[i] = new int[D];
		for (int j = 0; j < D; j++) {
			newState[i][j] = state[i][j];
		}
	}
	return newState;
}

/*Creates a new 3x3 matrix using the copyState function and 
swaps the contents of emptyCell with newEmptyCell to generate new state.*/
int ** AStar::generateState(int **state, int *emptyCell, int *newEmptyCell)
{
	int **newState = copyState(state);
	int temp = newState[emptyCell[0]][emptyCell[1]];
	newState[emptyCell[0]][emptyCell[1]] = newState[newEmptyCell[0]][newEmptyCell[1]];
	newState[newEmptyCell[0]][newEmptyCell[1]] = temp;

	return newState;
}

/*Starts the search for solution. Entry point of the search.*/
void AStar::start()
{
	Node *node = nullptr;
	node = frontier.top();
	frontier.pop();

	while (node!= nullptr && !isGoalState(node->state)) {
		
		explored.push(node);
		expandNode(node);
		node = frontier.top();
		frontier.pop();
	}

	if (node != nullptr) {
		goalNode = node;
	}

	while (node != nullptr) {
		solutionStack.push(node);
		node = node->parent;
	}
}

/*Return a stack which contains order of nodes to be traversed 
to reach the solution for the 8-puzzle. The last node in the stack 
is the goal state and the first node is the start state.*/
std::stack<Node*> AStar::getSolution() {
	return solutionStack;
}

/*The number of nodes actually expanded to reach the goal state
i.e. the size of explored queue*/
int AStar::getNumberOfStatesExpanded()
{
	return int(explored.size());
}

/*The number of nodes generated all along. It is the sum of the number 
nodes in frontier queue, the number of nodes in explored queue and 1 (the goal state).*/
int AStar::getNumberofStatesGenerated()
{
	return int(frontier.size() + explored.size() + 1);
}

/*Destructor for deallocating all the memory allocated during the execution of the program. 
Deletes all the nodes in the frontier queue and the explored queue.*/
AStar::~AStar()
{
	delete[] goalPosition;

	while (!frontier.empty())
	{
		Node* node = frontier.top();
		delete[] node->state;
		frontier.pop();
	}


	while (!explored.empty())
	{
		Node* node = explored.front();
		delete node->state;
		explored.pop();
	}

	delete[] goalNode->state;
	delete goalNode;
	delete[] goalState;

}
 

