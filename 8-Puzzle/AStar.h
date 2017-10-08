/*
Author: Archit Parnami
ITCS 6150 : Project 1
*/

#ifndef ASTAR_H
#define ASTAR_H
#endif // !ASTAR_H
#define D 3

#include <queue>
#include <stack>
#include <functional>

class Node
{
public:
	int cost, level;
	int** state;
	Node* parent;
};

struct CompareNode : public std::binary_function<Node*, Node*, bool>
{
	bool operator()(const Node* lhs, const Node* rhs) const
	{
		return lhs->cost > rhs->cost;
	}
};

class AStar {

private:
	int** goalState;
	int** initialState;
	int** goalPosition;

	Node* goalNode;

	std::priority_queue<Node*, std::vector<Node*>, CompareNode> frontier;
	std::queue<Node*> explored;
	std::stack<Node*> solutionStack;

	int computeCost(int level, int** state);
	int computeDistance(int** state);
	int** computePosition(int** state);
	bool isGoalState(int** state);
	void addState(int** state, Node* parent);
	void expandNode(Node* node);
	int* findEmptyCell(Node* node);
	int** copyState(int** state);
	int** generateState(int** state, int* emptyCell, int* newEmptyCell);

public:
	AStar(int** initialState, int** goalState);
	~AStar();
	void start();
	std::stack<Node*> getSolution();
	int getNumberOfStatesExpanded();
	int getNumberofStatesGenerated();
};