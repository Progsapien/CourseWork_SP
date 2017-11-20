#include "runner.h"

Player* createPlayer() {
	return new Player();
}

void runNext(Player* player) {
	player->next();
}

void runPrev(Player* player) {
	player->prev();
}

void runPlay(Player* player, int position = 0) {
	player->play(position);
}

void runStop(Player* player) {
	player->stop();
}

void runLoadFile(Player* player, string *path) {
	player->loadFile(path);
}

string* runCurrentFile(Player *player) {
	return player->currentFile();
}
