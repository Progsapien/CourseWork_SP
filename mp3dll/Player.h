#pragma once
#include <string>
#include <vector>
#include <Windows.h>

using namespace std;
class Player
{
public:
	Player(void);
	~Player(void);

	void play(int position);
	void stop();
	void next();
	void prev();
	void loadFile(string *path);
	string* currentFile();


private:
	char *mciData;
	char *current_command;
	int current_position;
	vector<string*> *playlist;
};

