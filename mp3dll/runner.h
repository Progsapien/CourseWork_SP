#include "Player.h"
#include <string>
#define EXPORT_FUNCTION extern __declspec(dllexport)

extern "C" {
	EXPORT_FUNCTION Player* createPlayer();
	EXPORT_FUNCTION void runNext(Player*);
	EXPORT_FUNCTION void runPrev(Player*);
	EXPORT_FUNCTION void runStop(Player*);
	EXPORT_FUNCTION void runPlay(Player*, int);
	EXPORT_FUNCTION void runLoadFile(Player*, string*);
	EXPORT_FUNCTION string* runCurrentFile(Player*);
	EXPORT_FUNCTION int* runCurrentPosition(Player*);
	EXPORT_FUNCTION int* runLength(Player*);
	EXPORT_FUNCTION void runSetCurrentPosition(Player*, string*);
}
