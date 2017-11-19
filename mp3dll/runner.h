#include "Player.h"
extern "C" {

	extern __declspec(dllexport) Player* createPlayer();
	extern __declspec(dllexport) void playTest(Player*);

}
