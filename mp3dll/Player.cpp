#include "Player.h"

Player::Player(void)
{
	mciData = new char[100];
	current_command = new char[100];
	playlist = new vector<string*>();
	current_position = -1;
	last_error = new int;
	result_execute_command = 0;
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
	result_execute_command = mciSendStringA(current_command, NULL, 0, NULL);
	result_execute_command = mciSendStringA("play mp3file", NULL, 0, NULL);
	findError();

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
	result_execute_command = mciSendStringA(current_command, NULL, 0, NULL);
	result_execute_command = mciSendStringA("play mp3file", NULL, 0, NULL);
	findError();

	ZeroMemory(current_command, sizeof(current_command));
	current_command = new char[100];
}

void Player::stop() {
	mciSendStringA("stop mp3file", NULL, 0, NULL);
	mciSendStringA("close mp3file", NULL, 0, NULL);
}

void Player::play(int position) {

	if(current_position != -1) {
		stop();
	}
	current_position = position;
	sprintf(current_command, "open %s alias mp3file", playlist->at(position));
	result_execute_command = mciSendStringA(current_command, NULL, 0, NULL);
	findError();
	result_execute_command = mciSendStringA("play mp3file", NULL, 0, NULL);
	findError();
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

	result_execute_command = mciSendStringA("status mp3file position",mciData,strlen(mciData),NULL);
	int* played = new int(atoi(mciData));
	ZeroMemory(mciData, sizeof(mciData));
	mciData = new char[100];
	return played;
}

int* Player::length() {
	result_execute_command = mciSendStringA("status mp3file length",mciData,strlen(mciData),NULL);
	int *music_file_length = new int(atoi(mciData));
	ZeroMemory(mciData, sizeof(mciData));
	mciData = new char[100];
	return music_file_length;
}

void Player::setCurrentPosition(string *position) {
	sprintf(current_command, "play mp3file from %s", position);
	result_execute_command = mciSendStringA(current_command,NULL,0,NULL);
	findError();
	ZeroMemory(current_command, sizeof(current_command));
	current_command = new char[100];
}

int* Player::lastError() {
	int error = *last_error;
	*last_error = 0;
	return &error;
}

void Player::findError() {
	if(result_execute_command != 0) {
		*last_error = result_execute_command;
	};
}