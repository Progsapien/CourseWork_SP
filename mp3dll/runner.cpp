#include "runner.h"

Player* createPlayer() {
	return new Player();
}

void playTest(Player* player) {
	player->next();
}