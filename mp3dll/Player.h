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
	int* currentPosition();
	int* length();
	void setCurrentPosition(string *position);
	int* lastError();
	void findError();


private:
	char *mciData;
	char *current_command;
	int current_position;
	int result_execute_command;
	int *last_error;
	vector<string*> *playlist;
};

