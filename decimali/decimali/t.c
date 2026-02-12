#include <stdio.h>
int binToDec(char* b) {
	int m = 0x80;
	int dec = 0;
	for (int i = 0;i<9; i++)
	{
		if(b[i])
		dec = (dec | m);
		m=m >> 1;
	}
	return dec;
}



void main() {
	char num[9] = { 0,1,0,1,0,1,1,0 };
	int x = binToDec(num);
	printf("%d", x);
}