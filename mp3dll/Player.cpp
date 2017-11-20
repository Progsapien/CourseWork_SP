#include "Player.h"

Player::Player(void)
{
	mciData = new char[100];
	current_command = new char[100];
	playlist = new vector<string*>();
	current_position = -1;
}

Player::~Player(void)
{

}

void Player::next() {

	if(current_position < playlist->size()-1) {
		current_position++;
	} else {
		current_position = 0;
	}

	stop();

	sprintf(current_command, "open %s alias mp3file", playlist->at(current_position));
	mciSendStringA(current_command, NULL, 0, NULL);
	mciSendStringA("play mp3file", NULL, 0, NULL);

	ZeroMemory(current_command, sizeof(current_command));
	current_command = new char[100];
}

void Player::prev() {
	if(current_position > 0) {
		current_position--;
	} else {
		current_position = playlist->size()-1;
	}

	stop();

	sprintf(current_command, "open %s alias mp3file", playlist->at(current_position));
	mciSendStringA(current_command, NULL, 0, NULL);
	mciSendStringA("play mp3file", NULL, 0, NULL);

	ZeroMemory(current_command, sizeof(current_command));
	current_command = new char[100];
}

void Player::stop() {
	mciSendStringA("stop mp3file", NULL, 0, NULL);
	mciSendStringA("close mp3file", NULL, 0, NULL);
}

void Player::play(int position) {

	stop();
	current_position = position;
	sprintf(current_command, "open %s alias mp3file", playlist->at(position));
	mciSendStringA(current_command, NULL, 0, NULL);
	mciSendStringA("play mp3file", NULL, 0, NULL);
	ZeroMemory(current_command, sizeof(current_command));
	current_command = new char[100];

}

void Player::loadFile(string *path) {
	playlist->push_back(path);
	current_position = 0;
}


string* Player::currentFile() {
	return playlist->at(current_position);
}

int* Player::currentPosition() {

	mciSendStringA("status mp3file position",mciData,strlen(mciData),NULL);
	int* played = new int(atoi(mciData));
	ZeroMemory(mciData, sizeof(mciData));
	mciData = new char[100];
	return played;
}

int* Player::length() {
	mciSendStringA("status mp3file length",mciData,strlen(mciData),NULL);
	int *music_file_length = new int(atoi(mciData));
	ZeroMemory(mciData, sizeof(mciData));
	mciData = new char[100];
	return music_file_length;
}

void Player::setCurrentPosition(string *position) {
	sprintf(current_command, "play mp3file from %s", position);
	mciSendStringA(current_command,NULL,0,NULL);
	ZeroMemory(current_command, sizeof(current_command));
	current_command = new char[100];
}